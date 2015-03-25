using System;
using System.Collections.Generic;
using System.Text;
using NChordLib;
using System.Threading;
using LordOfTheFiles.Model;

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

        public SortedList<ulong, string> GetDHT()
        {
            return instance.GetDHT();
        }

        /// <summary>
        /// Add a key to the storage
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

            Thread fileThread = new Thread(() => instance.ReplicateFile(file.Name, file.Content));
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
