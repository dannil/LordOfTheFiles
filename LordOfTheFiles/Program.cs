using System;
using System.Collections.Generic;
using System.Text;

using NChordLib;
using System.Net;
using System.Net.NetworkInformation;

namespace LordOfTheFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            int port = 8861;

            string host = Dns.GetHostName();
            IPHostEntry ipHost = Dns.GetHostEntry(host);
            string ip = ipHost.AddressList[ipHost.AddressList.Length - 2].ToString();

            ChordServer.LocalNode = new ChordNode(ip, port);

            System.Diagnostics.Debug.WriteLine(ChordServer.GetHash("hej"));

            if (ChordServer.RegisterService(port))
            {
                ChordInstance instance = ChordServer.GetInstance(ChordServer.LocalNode);
                
                List<string> addresses = new List<string> { "10.2.16.25", "10.2.15.95", "10.1.22.246", "10.2.13.209" };
                List<string> failures = new List<string>();
                Ping ping = new Ping();
                foreach (string address in addresses)
                {
                    if (address != ip)
                    {
                        PingReply reply = ping.Send(address);
                        if (reply.Status.ToString() == "Success")
                        {
                            instance.Join(new ChordNode(address, port), ip, port);
                        }
                        else
                        {
                            failures.Add(address);
                        }
                    }
                }
                if (failures.Count == addresses.Count)
                {
                    instance.Join(null, ChordServer.LocalNode.Host, ChordServer.LocalNode.PortNumber);
                }

                //String test = instance.FindKey(ChordServer.GetHash("hej"));
                //System.Diagnostics.Debug.WriteLine(test);

                Console.ReadLine();

                for (int i = 0; i < 1; i++)
                {
                    instance.AddKey("hej" + i);
                    instance.AddKey("abcdefg" + i);
                    instance.AddKey("tjenare hassan" + i);
                    instance.AddKey("detta e ball" + i);
                    instance.AddKey("12345" + i);
                    instance.AddKey("etttvåtrefyra" + i);
                    instance.AddKey("aloevero" + i);
                    instance.AddKey("marker" + i);
                    instance.AddKey("mus" + i);
                    instance.AddKey("skärm" + i);
                    instance.AddKey("bertil" + i);
                    instance.AddKey("stikkan" + i);
                    instance.AddKey("eluttag" + i);
                    instance.AddKey("edding361" + i);
                    instance.AddKey("b-kraft" + i);
                    instance.AddKey("TrAnSfOrMaToR" + i);
                    instance.AddKey("zebra" + i);
                    instance.AddKey("zorro" + i);
                    instance.AddKey("xylofon" + i);
                    instance.AddKey("äppelpaj" + i);
                    instance.AddKey("grodanboll" + i);
                    instance.AddKey("walter" + i);
                    instance.AddKey("tangentbord" + i);
                    instance.AddKey("stilton" + i);
                    instance.AddKey("chips" + i);
                    instance.AddKey("gouda" + i);
                    instance.AddKey("ägg" + i);
                    instance.AddKey("gurka" + i);
                    instance.AddKey("nämen hejsan" + i);
                    instance.AddKey("pizza" + i);
                    instance.AddKey("turtles" + i);
                    instance.AddKey("raphael" + i);
                }

                instance.FindKey(ChordServer.GetHash("babbababbabbabba"));

                Console.ReadLine();
            }
        }
    }
}
