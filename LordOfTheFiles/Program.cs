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

namespace LordOfTheFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddressUtility ipAddressUtility = new IPAddressUtility();

            ChordServer.LocalNode = new ChordNode(ipAddressUtility.LocalIPv4.ToString(), ipAddressUtility.Port);

            System.Diagnostics.Debug.WriteLine(ipAddressUtility.LocalIPv4);
            System.Diagnostics.Debug.WriteLine(ipAddressUtility.LocalIPv6);

            System.Diagnostics.Debug.WriteLine(ipAddressUtility.ExternalIPv4);
            System.Diagnostics.Debug.WriteLine(ipAddressUtility.ExternalIPv6);

            if (ChordServer.RegisterService(ChordServer.LocalNode.PortNumber))
            {
                StorageManager storageManager = new StorageManager();
                storageManager.Instance.Join(null, ChordServer.LocalNode.Host, ChordServer.LocalNode.PortNumber);

                //String test = instance.FindKey(ChordServer.GetHash("hej"));
                //System.Diagnostics.Debug.WriteLine(test);

                Console.ReadLine();

                for (int i = 0; i < 1; i++)
                {
                    storageManager.AddKey("hej" + i);
                    storageManager.AddKey("abcdefg" + i);
                    storageManager.AddKey("tjenare hassan" + i);
                    storageManager.AddKey("detta e ball" + i);
                    storageManager.AddKey("12345" + i);
                    storageManager.AddKey("etttvåtrefyra" + i);
                    storageManager.AddKey("aloevero" + i);
                    storageManager.AddKey("marker" + i);
                    storageManager.AddKey("mus" + i);
                    storageManager.AddKey("skärm" + i);
                    storageManager.AddKey("bertil" + i);
                    storageManager.AddKey("stikkan" + i);
                    storageManager.AddKey("eluttag" + i);
                    storageManager.AddKey("edding361" + i);
                    storageManager.AddKey("b-kraft" + i);
                    storageManager.AddKey("TrAnSfOrMaToR" + i);
                    storageManager.AddKey("zebra" + i);
                    storageManager.AddKey("zorro" + i);
                    storageManager.AddKey("xylofon" + i);
                    storageManager.AddKey("äppelpaj" + i);
                    storageManager.AddKey("grodanboll" + i);
                    storageManager.AddKey("walter" + i);
                    storageManager.AddKey("tangentbord" + i);
                    storageManager.AddKey("stilton" + i);
                    storageManager.AddKey("chips" + i);
                    storageManager.AddKey("gouda" + i);
                    storageManager.AddKey("ägg" + i);
                    storageManager.AddKey("gurka" + i);
                    storageManager.AddKey("nämen hejsan" + i);
                    storageManager.AddKey("pizza" + i);
                    storageManager.AddKey("turtles" + i);
                    storageManager.AddKey("raphael" + i);
                }

                storageManager.FindKey(ChordServer.GetHash("babbababbabbabba"));
                storageManager.FindKey(ChordServer.GetHash("zorro0"));

                //string filename = "helloworld.txt";

                //byte[] file = instance.GetFile(filename);

                //if (file != null)
                //{
                //    string path = Environment.CurrentDirectory + "/files/" + filename;
                //    File.WriteAllBytes(path, file);
                //}

                File file = new File("helloworld.txt", FileUtility.ReadBytes(Environment.CurrentDirectory + "/files/" + "helloworld.txt"));
                storageManager.AddFile(file);

                Console.ReadLine();
            }
        }
    }
}
