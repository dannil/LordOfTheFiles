using LordOfTheFiles.Manager;
using LordOfTheFiles.Utility;
using NChordLib;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LordOfTheFiles_Test
{
    [TestFixture]
    public class Test
    {
        private int testIndex;

        private StorageManager storageManager;

        private SortedList<ulong, string> dht;

        /// <summary>
        /// As almost all of these are system tests, an advanced setup
        /// procedure is required
        /// </summary>
        [SetUp]
        public void Init()
        {
            testIndex++;

            dht = new SortedList<ulong, string>();

            ChordServer.RegisterService(8861);

            IPAddressUtility ipAddressUtility = new IPAddressUtility();

            ChordServer.LocalNode = new ChordNode(ipAddressUtility.LocalIPv4.ToString(), ipAddressUtility.Port);

            storageManager = new StorageManager();
            storageManager.Instance.Join(null, ChordServer.LocalNode.Host, ChordServer.LocalNode.PortNumber);

            Directory.CreateDirectory(FileUtility.FILES_DIR);
            Directory.CreateDirectory(FileUtility.REF_DIR);
        }

        /// <summary>
        /// Test-ID 1
        /// 
        /// Retrieve the distributed hash table
        /// </summary>
        [TestCase]
        public void GetDHT()
        {
            storageManager.AddKey("test" + testIndex);

            dht = storageManager.GetDHT();

            ulong key = ChordServer.GetHash("test" + testIndex);
            Assert.IsNotNull(dht.ContainsKey(key));
        }

        /// <summary>
        /// Test-ID 2
        /// 
        /// Add a key to the distibuted hash table
        /// </summary>
        [TestCase]
        public void AddKey()
        {
            storageManager.AddKey("test" + testIndex);

            dht = storageManager.GetDHT();

            ulong key = ChordServer.GetHash("test" + testIndex);
            Assert.IsNotNull(dht.ContainsKey(key));
        }

        /// <summary>
        /// Test-ID 3
        /// 
        /// Retrieves a key from the distributed hash table
        /// </summary>
        [TestCase]
        public void FindKey()
        {
            storageManager.AddKey("test" + testIndex);

            ulong key = ChordServer.GetHash("test" + testIndex);
            string value = storageManager.FindKey(key);

            Assert.AreNotEqual(value, string.Empty);
        }

        /// <summary>
        /// Test-ID 4
        /// 
        /// Retrieve a non-existing key from the distributed hash table
        /// </summary>
        [TestCase]
        public void FindNonExistingKey()
        {
            ulong key = ChordServer.GetHash("nonexistingkey" + testIndex);
            string value = storageManager.FindKey(key);

            Assert.AreEqual(value, string.Empty);
        }

        /// <summary>
        /// Test-ID 5
        /// 
        /// Delete a key from the distributed hash table
        /// </summary>
        [TestCase]
        public void DeleteKey()
        {
            storageManager.AddKey("test" + testIndex);

            ulong key = ChordServer.GetHash("test" + testIndex);
            storageManager.DeleteKey(key);

            dht = storageManager.GetDHT();

            Assert.IsFalse(dht.ContainsKey(key));
        }

        /// <summary>
        /// Test-ID 6
        /// 
        /// Delete a non-existing key from the distributed hash table
        /// </summary>
        [TestCase]
        public void DeleteNonExistingKey()
        {
            ulong key = ChordServer.GetHash("test" + testIndex);
            storageManager.DeleteKey(key);

            dht = storageManager.GetDHT();

            Assert.IsFalse(dht.ContainsKey(key));
        }

        /// <summary>
        /// Test-ID 7
        /// 
        /// Add a file to the distributed hash table
        /// </summary>
        [TestCase]
        public void AddFile()
        {
            string filename = "test" + testIndex + ".txt";
            File.Create("files/" + filename);

            LordOfTheFiles.Model.File file = new LordOfTheFiles.Model.File(filename, FileUtility.ReadBytes(filename));
            storageManager.AddFile(file);

            dht = storageManager.GetDHT();

            ulong key = ChordServer.GetHash(filename);

            Assert.IsTrue(dht.ContainsKey(key));
            Assert.IsTrue(File.Exists("files/" + filename));
        }

        /// <summary>
        /// Test-ID 8
        /// 
        /// Find a file on the network
        /// </summary>
        [TestCase]
        public void FindFile()
        {
            string filename = "test" + testIndex + ".txt";
            File.Create("files/" + filename);

            LordOfTheFiles.Model.File file = new LordOfTheFiles.Model.File(filename, FileUtility.ReadBytes(filename));
            storageManager.AddFile(file);

            LordOfTheFiles.Model.File foundFile = storageManager.FindFile(filename);

            Assert.IsNotNull(foundFile);
        }

        /// <summary>
        /// Test-ID 9
        /// 
        /// Find a non-existing file on the network
        /// </summary>
        [TestCase]
        public void FindNonExistingFile()
        {
            string filename = "test" + testIndex + ".txt";

            LordOfTheFiles.Model.File file = new LordOfTheFiles.Model.File(filename, FileUtility.ReadBytes(filename));
            storageManager.AddFile(file);

            LordOfTheFiles.Model.File foundFile = storageManager.FindFile(filename);

            Assert.IsNotNull(foundFile);
        }

        /// <summary>
        /// Test-ID 10
        /// 
        /// Delete a file from the network
        /// </summary>
        [TestCase]
        public void DeleteFile()
        {
            string filename = "test" + testIndex + ".txt";
            File.Create("files/" + filename);

            LordOfTheFiles.Model.File file = new LordOfTheFiles.Model.File(filename, FileUtility.ReadBytes(filename));
            storageManager.AddFile(file);

            storageManager.DeleteFile(filename);

            LordOfTheFiles.Model.File foundFile = storageManager.FindFile(filename);

            Assert.IsNull(foundFile);
        }

        [TestCase]
        public void SaveDHTToXML()
        {

        }

        [TestCase]
        public void GetDHTFromXML()
        {

        }
    }
}
