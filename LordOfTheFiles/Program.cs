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
            }

            Console.ReadLine();
        }
    }
}
