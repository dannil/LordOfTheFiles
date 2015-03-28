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
            }
            else
            {
                MessageBox.Show("There was a problem initializing the Chord service. Please make sure port 8861 isn't being used by another application.");
            }
        }
    }
}
