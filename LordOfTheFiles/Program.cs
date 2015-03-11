/*
 * Program.cs
 * 
 * A very basic example program that serves as an NChord server running on the command line.
 *
 * ****************************************************************************
 *  Copyright (c) 2008 Andrew Cencini
 *
 *  Permission is hereby granted, free of charge, to any person obtaining
 *  a copy of this software and associated documentation files (the
 *  "Software"), to deal in the Software without restriction, including
 *  without limitation the rights to use, copy, modify, merge, publish,
 *  distribute, sublicense, and/or sell copies of the Software, and to
 *  permit persons to whom the Software is furnished to do so, subject to
 *  the following conditions:
 *
 *  The above copyright notice and this permission notice shall be
 *  included in all copies or substantial portions of the Software.
 *
 *  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
 *  EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
 *  MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 *  NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
 *  LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
 *  OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
 *  WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 *
 * ****************************************************************************
 */

using System;
using System.Collections.Generic;
using System.Text;

using NChordLib;
using System.Net;

namespace TestNChord
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
