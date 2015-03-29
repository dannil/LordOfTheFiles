using LordOfTheFiles.Utility;
using LordOfTheFiles.Window;
using NChordLib;
using System;
using System.IO;
using System.Windows.Forms;

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

            // Initialize files
            if (!File.Exists(FileUtility.REF_DIR + "dht.xml"))
            {
                File.Create(FileUtility.REF_DIR + "dht.xml");
            }

            if (!File.Exists(FileUtility.REF_DIR + "nodes.txt"))
            {
                File.Create(FileUtility.REF_DIR + "nodes.txt");
            }

            IPAddressUtility ipAddressUtility = new IPAddressUtility();

            ChordServer.LocalNode = new ChordNode(ipAddressUtility.LocalIPv4.ToString(), ipAddressUtility.Port);

            // Try to initialize the Chord service on the specified port
            if (ChordServer.RegisterService(ChordServer.LocalNode.PortNumber))
            {
                ChordInstance instance = ChordServer.GetInstance(ChordServer.LocalNode);

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                if (FileUtility.ReadLines(FileUtility.REF_DIR + "nodes.txt").Count <= 0)
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
                MessageBox.Show("There was a problem initializing the Chord service. Please make sure port " + ipAddressUtility.Port + " isn't being used by another application.");
            }
        }
    }
}
