using System;
using System.Collections.Generic;
using System.Text;
using NChordLib;
using System.Threading;
using LordOfTheFiles.Model;

namespace LordOfTheFiles.Manager
{
    public class StorageManager
    {
        private ChordInstance instance;

        public StorageManager()
        {
            instance = ChordServer.GetInstance(ChordServer.LocalNode);
        }

        public void AddKey(string value)
        {
            instance.AddKey(value);
        }

        public string FindKey(ulong key)
        {
            return instance.FindKey(key);
        }

        public void AddFile(File file)
        {
            Thread keyThread = new Thread(() => instance.AddKey(file.Name));
            keyThread.Start();

            Thread fileThread = new Thread(() => instance.ReplicateFile(file.Name, file.Content));
            fileThread.Start();
        }

        public byte[] FindFile(string name)
        {
            return instance.FindFile(name);
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
