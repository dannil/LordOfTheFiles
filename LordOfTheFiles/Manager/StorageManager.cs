using System;
using System.Collections.Generic;
using System.Text;
using NChordLib;
using System.Threading;
using LordOfTheFiles.Model;
using LordOfTheFiles.Utility;
using System.Xml.Serialization;

namespace LordOfTheFiles.Manager
{
    /// <summary>
    /// Manager which handles all operations for storage. This includes finding a
    /// file, saving a file and searching the DHT (Distributed hash table). 
    /// 
    /// More essentially, this class serves as an abstraction layer between the 
    /// NChord library and the program itself.
    /// </summary>
    public class StorageManager
    {
        private ChordInstance instance;

        /// <summary>
        /// Default constructor
        /// </summary>
        public StorageManager()
        {
            instance = ChordServer.GetInstance(ChordServer.LocalNode);
        }

        /// <summary>
        /// Synchronizes the distributed hash table throughout the network. Besides fetching the distributed
        /// hash table, this method also synchronizes our local hash table to the network, as we can't be sure if
        /// this node is the creator of a new ring. Also helps consistency throughout the distributed hash table
        /// when traversing every node
        /// </summary>
        public SortedList<ulong, string> GetDHT()
        {
            SortedList<ulong, string> networkDht = instance.GetDHT();
            if (System.IO.File.Exists(FileUtility.REF_DIR + "dht.xml"))
            {
                // We already have a local DHT; we need to merge and sync this file to the network
                SortedList<ulong, string> localDht = XMLUtility.DHTFromXML(FileUtility.REF_DIR + "dht.xml");
                foreach (KeyValuePair<ulong, string> pair in networkDht)
                {
                    // Merge process: every key in the network DHT that isn't present
                    // in our local DHT should be added to our local DHT
                    if (!localDht.ContainsKey(pair.Key))
                    {
                        localDht.Add(pair.Key, pair.Value);
                    }
                }

                // Not sure if needed
                //if (localDht.Count < networkDht.Count)
                //{
                //    foreach (string value in localDht.Values)
                //    {
                //        AddKey(value);
                //    }
                //}
            }
            System.IO.File.WriteAllText(FileUtility.REF_DIR + "dht.xml", XMLUtility.DHTToXML(networkDht));

            return networkDht;
        }

        /// <summary>
        /// Add a key-value pair to the storage
        /// </summary>
        /// <param name="value">The value to be stored.</param>
        public void AddKey(string value)
        {
            instance.AddKey(value);
        }

        /// <summary>
        /// Find a key in the storage
        /// </summary>
        /// <param name="key">The key to search for.</param>
        /// <returns>The value associated with the specified key.</returns>
        public string FindKey(ulong key)
        {
            return instance.FindKey(key);
        }

        /// <summary>
        /// Delete a key from the storage
        /// </summary>
        /// <param name="value">The the key to be deleted.</param>
        public void DeleteKey(ulong key)
        {
            instance.DeleteKey(key);
        }

        /// <summary>
        /// Add a file to the storage
        /// </summary>
        /// <param name="file">The file to be stored.</param>
        public void AddFile(File file)
        {
            Thread keyThread = new Thread(() => instance.AddKey(file.Name));
            keyThread.Start();

            Thread fileThread = new Thread(() => instance.AddFile(file.Name, file.Content));
            fileThread.Start();

            keyThread.Join();
            fileThread.Join();
        }

        /// <summary>
        /// Find a file in the storage
        /// </summary>
        /// <param name="name">The name of the file.</param>
        /// <returns>A file if a file with the specified name exists; otherwise null.</returns>
        public File FindFile(string name)
        {
            byte[] content = instance.FindFile(name);
            if (content != null)
            {
                return new File(name, content);
            }
            return null;
        }

        /// <summary>
        /// Delete a file from the storage
        /// </summary>
        /// <param name="name">The name of the file.</param>
        public void DeleteFile(string name)
        {
            Thread keyThread = new Thread(() => instance.DeleteKey(ChordServer.GetHash(name)));
            keyThread.Start();

            Thread fileThread = new Thread(() => instance.DeleteFile(name));
            fileThread.Start();

            keyThread.Join();
            fileThread.Join();
        }

        /// <summary>
        /// Returns the instance of the local ChordNode
        /// </summary>
        public ChordInstance Instance
        {
            get { return instance; }
            set { instance = value; }
        }

    }
}
