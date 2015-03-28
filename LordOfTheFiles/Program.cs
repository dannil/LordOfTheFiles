using System;
using System.Collections.Generic;
using System.Text;

using NChordLib;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using LordOfTheFiles.Manager;
using LordOfTheFiles.Utility;
using LordOfTheFiles.Model;
using LordOfTheFiles.Window;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace LordOfTheFiles
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            // Initialize directories
            Directory.CreateDirectory(FileUtility.FILES_DIR);
            Directory.CreateDirectory(FileUtility.REF_DIR);

            IPAddressUtility ipAddressUtility = new IPAddressUtility();

            ChordServer.LocalNode = new ChordNode(ipAddressUtility.LocalIPv4.ToString(), ipAddressUtility.Port);

            // Try to initialize the Chord service on the specified port
            if (ChordServer.RegisterService(ChordServer.LocalNode.PortNumber))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());

                // Debugging code

                //StorageManager storageManager = new StorageManager();
                //storageManager.Instance.Join(null, ChordServer.LocalNode.Host, ChordServer.LocalNode.PortNumber);

                //Console.ReadLine();

                //for (int i = 0; i < 1; i++)
                //{
                //    storageManager.AddKey("hej" + i);
                //    storageManager.AddKey("abcdefg" + i);
                //    storageManager.AddKey("tjenare hassan" + i);
                //    storageManager.AddKey("detta e ball" + i);
                //    storageManager.AddKey("12345" + i);
                //    storageManager.AddKey("etttvåtrefyra" + i);
                //    storageManager.AddKey("aloevero" + i);
                //    storageManager.AddKey("marker" + i);
                //    storageManager.AddKey("mus" + i);
                //    storageManager.AddKey("skärm" + i);
                //    storageManager.AddKey("bertil" + i);
                //    storageManager.AddKey("stikkan" + i);
                //}

                //SortedList<ulong, string> list = new SortedList<ulong,string>()
                //{
                //    { 1234, "test" },
                //};
                //System.IO.File.WriteAllText("dht.xml", XMLUtility.DHTToXML(list));

                Console.ReadLine();

                Console.ReadLine();
                Console.ReadLine();
                Console.ReadLine();
                Console.ReadLine();
            }
        }

        //{
        //    IPAddressUtility ipAddressUtility = new IPAddressUtility();

        //    ChordServer.LocalNode = new ChordNode(ipAddressUtility.LocalIPv4.ToString(), ipAddressUtility.Port);

        //    System.Diagnostics.Debug.WriteLine(ipAddressUtility.LocalIPv4);
        //    System.Diagnostics.Debug.WriteLine(ipAddressUtility.LocalIPv6);

        //    //System.Diagnostics.Debug.WriteLine(ipAddressUtility.ExternalIPv4);
        //    //System.Diagnostics.Debug.WriteLine(ipAddressUtility.ExternalIPv6);

        //    if (ChordServer.RegisterService(ChordServer.LocalNode.PortNumber))
        //    {
        //        StorageManager storageManager = new StorageManager();
        //        storageManager.Instance.Join(null, ChordServer.LocalNode.Host, ChordServer.LocalNode.PortNumber);

        //        Console.ReadLine();

        //        SortedList<ulong, string> temp = storageManager.GetDHT();

        //        foreach (KeyValuePair<ulong, string> pair in temp)
        //        {
        //            System.Diagnostics.Debug.WriteLine(pair.Key + " : " + pair.Value);
        //        }

        //        //String test = instance.FindKey(ChordServer.GetHash("hej"));
        //        //System.Diagnostics.Debug.WriteLine(test);

        //        Console.ReadLine();

        //        for (int i = 0; i < 1; i++)
        //        {
        //            storageManager.AddKey("hej" + i);
        //            storageManager.AddKey("abcdefg" + i);
        //            storageManager.AddKey("tjenare hassan" + i);
        //            storageManager.AddKey("detta e ball" + i);
        //            storageManager.AddKey("12345" + i);
        //            storageManager.AddKey("etttvåtrefyra" + i);
        //            storageManager.AddKey("aloevero" + i);
        //            storageManager.AddKey("marker" + i);
        //            storageManager.AddKey("mus" + i);
        //            storageManager.AddKey("skärm" + i);
        //            storageManager.AddKey("bertil" + i);
        //            storageManager.AddKey("stikkan" + i);
        //            storageManager.AddKey("eluttag" + i);
        //            storageManager.AddKey("edding361" + i);
        //            storageManager.AddKey("b-kraft" + i);
        //            storageManager.AddKey("TrAnSfOrMaToR" + i);
        //            storageManager.AddKey("zebra" + i);
        //            storageManager.AddKey("zorro" + i);
        //            storageManager.AddKey("xylofon" + i);
        //            storageManager.AddKey("äppelpaj" + i);
        //            storageManager.AddKey("grodanboll" + i);
        //            storageManager.AddKey("walter" + i);
        //            storageManager.AddKey("tangentbord" + i);
        //            storageManager.AddKey("stilton" + i);
        //            storageManager.AddKey("chips" + i);
        //            storageManager.AddKey("gouda" + i);
        //            storageManager.AddKey("ägg" + i);
        //            storageManager.AddKey("gurka" + i);
        //            storageManager.AddKey("nämen hejsan" + i);
        //            storageManager.AddKey("pizza" + i);
        //            storageManager.AddKey("turtles" + i);
        //            storageManager.AddKey("raphael" + i);
        //        }

        //        storageManager.FindKey(ChordServer.GetHash("babbababbabbabba"));
        //        storageManager.FindKey(ChordServer.GetHash("zorro0"));

        //        storageManager.DeleteKey(ChordServer.GetHash("awijdaoiwd"));

        //        Console.ReadLine();

        //        //string filename = "helloworld.txt";

        //        //byte[] file = instance.GetFile(filename);

        //        //if (file != null)
        //        //{
        //        //    string path = Environment.CurrentDirectory + "/files/" + filename;
        //        //    File.WriteAllBytes(path, file);
        //        //}

        //        File file = new File("helloworld.txt", FileUtility.ReadBytes(Environment.CurrentDirectory + "/files/" + "helloworld.txt"));
        //        storageManager.AddFile(file);

        //        File file2 = storageManager.FindFile("helloworld.txt");

        //        Console.ReadLine();

        //        storageManager.DeleteFile("helloworld.txt");

        //        Console.ReadLine();
        //    }
    }
}
