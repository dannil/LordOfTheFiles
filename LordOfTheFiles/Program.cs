using System;
using System.Collections.Generic;
using System.Text;

using NChordLib;
using System.Net;

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
                instance.Join(null, ChordServer.LocalNode.Host, ChordServer.LocalNode.PortNumber);
                //ChordInstance instance = ChordServer.GetInstance(ChordServer.LocalNode);

                //instance.AddKey("hej");


                //String test = instance.FindKey(ChordServer.GetHash("hej"));
                //System.Diagnostics.Debug.WriteLine(test);

                Console.ReadLine();

                instance.AddKey("hej");
                instance.AddKey("abcdefg");
                instance.AddKey("tjenare hassan");
                instance.AddKey("detta e ball");
                instance.AddKey("12345");
                instance.AddKey("etttvåtrefyra");
                instance.AddKey("aloevero");
                instance.AddKey("marker");
                instance.AddKey("mus");
                instance.AddKey("skärm");
                instance.AddKey("bertil");
                instance.AddKey("stikkan");
                instance.AddKey("eluttag");
                instance.AddKey("edding361");
                instance.AddKey("b-kraft");
                instance.AddKey("TrAnSfOrMaToR");
                instance.AddKey("zebra");
                instance.AddKey("zorro");
                instance.AddKey("xylofon");
                instance.AddKey("äppelpaj");
                instance.AddKey("grodanboll");
                instance.AddKey("walter");
                instance.AddKey("tangentbord");
                instance.AddKey("stilton");
                instance.AddKey("chips");
                instance.AddKey("gouda");
                instance.AddKey("ägg");
                instance.AddKey("gurka");
                instance.AddKey("nämen hejsan");
                instance.AddKey("pizza");
                instance.AddKey("turtles");
                instance.AddKey("raphael");
                Console.ReadLine();
            }
        }
    }
}
