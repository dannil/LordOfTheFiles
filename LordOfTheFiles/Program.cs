using System;
using System.Collections.Generic;
using System.Text;

using NChordLib;

namespace LordOfTheFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            ChordInstance instance = ChordServer.GetInstance(ChordServer.LocalNode);
            instance.AddKey("hej");
        }
    }
}
