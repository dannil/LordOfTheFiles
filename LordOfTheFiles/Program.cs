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
using System.Linq;
using System.Threading;

namespace LordOfTheFiles
{
    public class Program
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
                ChordInstance instance = ChordServer.GetInstance(ChordServer.LocalNode);

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                if (!System.IO.File.Exists(FileUtility.REF_DIR + "nodes.txt"))
                {
                    DialogResult result = MessageBox.Show("It seems that you don't have a saved list of nodes. Do you want to connect to an existing node?", "Missing nodes", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        AddNodeForm addNodeForm = new AddNodeForm();
                        addNodeForm.ShowDialog();

                        string nodeIP = addNodeForm.NodeIP;

                        System.IO.File.AppendAllLines(FileUtility.REF_DIR + "nodes.txt", new string[] { nodeIP });
                    }
                }
                LoadingForm loadingForm = new LoadingForm();
                loadingForm.Status = "Please wait, checking for nodes...";
                loadingForm.Show();

                string seedNodeIp = ipAddressUtility.GetSeedNodeIP();
                if (seedNodeIp != null)
                {
                    instance.Join(new ChordNode(seedNodeIp, ipAddressUtility.Port), ChordServer.LocalNode.Host, ChordServer.LocalNode.PortNumber);
                }
                else
                {
                    instance.Join(null, ChordServer.LocalNode.Host, ChordServer.LocalNode.PortNumber);
                }

                loadingForm.Close();

                Application.Run(new MainForm(instance));
            }
            else
            {
                MessageBox.Show("There was a problem initializing the Chord service. Please make sure port 8861 isn't being used by another application.");
            }
        }
    }
}
