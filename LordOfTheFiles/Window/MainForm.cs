﻿using LordOfTheFiles.Manager;
using LordOfTheFiles.Utility;
using NChordLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace LordOfTheFiles.Window
{
    public partial class MainForm : Form
    {
        private ListViewItem focusedItem;

        private List<string[]> items;

        private IPAddressUtility ipAddressUtility;
        private StorageManager storageManager;

        private MainForm()
        {
            InitializeComponent();

            items = new List<string[]>();

            ipAddressUtility = new IPAddressUtility();
            storageManager = new StorageManager();
        }

        public MainForm(ChordInstance instance) : this()
        {
            storageManager.Instance = instance;

            SynchronizeLocalDHTToNetwork();
            UpdateFileList();
        }

        private void mnuSearch_Click(object sender, EventArgs e)
        {
            SearchForm searchForm = new SearchForm();
            searchForm.ShowDialog();

            string search = searchForm.SearchText.ToLower();

            lvFiles.Items.Clear();

            foreach (string[] item in items)
            {
                if (item[0].ToLower().Contains(search) || item[1].ToLower().Contains(search) || (FileUtility.Combine(item[0], item[1])).ToLower().Contains(search))
                {
                    lvFiles.Items.Add(new ListViewItem(new string[] { item[0], item[1], item[2] }));
                }
            }
        }

        private void lvFiles_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ListViewItem focusedItem = lvFiles.FocusedItem;
                if (focusedItem.Bounds.Contains(e.Location) == true)
                {
                    this.focusedItem = focusedItem;
                    cmsFile.Show(Cursor.Position);
                }
            }
        }

        private void mnuAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdAddFile = new OpenFileDialog();
            DialogResult result = ofdAddFile.ShowDialog();

            if (result == DialogResult.OK)
            {
                LordOfTheFiles.Model.File file = new LordOfTheFiles.Model.File(ofdAddFile.SafeFileName, FileUtility.ReadBytes(ofdAddFile.FileName));

                storageManager.AddFile(file);
                UpdateFileList();
            }
        }

        private void mnuRefresh_Click(object sender, EventArgs e)
        {
            UpdateFileList();
        }

        private void cmsFileOpen_Click(object sender, EventArgs e)
        {
            ListViewItem item = focusedItem;

            string path = FileUtility.ToValidPath(FileUtility.FILES_DIR + FileUtility.Combine(items[item.Index][0], items[item.Index][1]));
            if (!System.IO.File.Exists(path))
            {
                MessageBox.Show("This file doesn't exist locally; please download it first.");
                return;
            }
            Process.Start("explorer.exe", "/select," + path);
        }

        private void cmsFileDownload_Click(object sender, EventArgs e)
        {
            ListViewItem item = focusedItem;
            storageManager.FindFile(FileUtility.Combine(items[item.Index][0], items[item.Index][1]));

            UpdateFileList();
        }

        private void cmsFileDelete_Click(object sender, EventArgs e)
        {
            ListViewItem item = focusedItem;
            storageManager.DeleteFile(FileUtility.Combine(items[item.Index][0], items[item.Index][1]));

            UpdateFileList();
        }

        private void mnuAddNode_Click(object sender, EventArgs e)
        {
            AddNodeForm addNodeForm = new AddNodeForm();
            addNodeForm.ShowDialog();

            string nodeIP = addNodeForm.NodeIP;

            if (nodeIP != string.Empty)
            {
                List<string> addresses = FileUtility.ReadLines(FileUtility.REF_DIR + "nodes.txt");
                if (!addresses.Contains(nodeIP))
                {
                    System.IO.File.AppendAllLines(FileUtility.REF_DIR + "nodes.txt", new string[] { nodeIP });
                }
            }
        }

        private void mnuNodesRefresh_Click(object sender, EventArgs e)
        {
            //DialogResult result = MessageBox.Show("Notice: refreshing the node list can take some depending on the amount of nodes. Do you want to continue?");
            //if (result == DialogResult.OK)
            //{
            //    LoadingForm loadingForm = new LoadingForm();
            //    loadingForm.Status = "Please wait, checking for nodes...";
            //    loadingForm.Show();

            //    string seedNodeIp = ipAddressUtility.GetSeedNodeIP();
            //    if (seedNodeIp != null)
            //    {
            //        storageManager.Instance.Join(new ChordNode(seedNodeIp, ipAddressUtility.Port), ChordServer.LocalNode.Host, ChordServer.LocalNode.PortNumber);
            //    }
            //    else
            //    {
            //        storageManager.Instance.Join(null, ChordServer.LocalNode.Host, ChordServer.LocalNode.PortNumber);
            //    }

            //    loadingForm.Close();
            //}
        }

        private void mnuSettingsStatus_Click(object sender, EventArgs e)
        {
            StatusForm statusForm = new StatusForm();
            statusForm.ShowDialog();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void UpdateFileList()
        {
            SortedList<ulong, string> tempDht = storageManager.GetDHT();

            items = new List<string[]>();

            foreach (string value in tempDht.Values)
            {
                if (System.IO.File.Exists(FileUtility.FILES_DIR + value))
                {
                    items.Add(new string[] { Path.GetFileNameWithoutExtension(value), Path.GetExtension(value).Substring(1), FileUtility.GetFileSize(FileUtility.FILES_DIR + value).ToString() });
                }
                else
                {
                    items.Add(new string[] { Path.GetFileNameWithoutExtension(value), Path.GetExtension(value).Substring(1), "Not downloaded" });
                }
            }

            lvFiles.Items.Clear();

            foreach (string[] item in items)
            {
                lvFiles.Items.Add(new ListViewItem(new string[] { item[0], item[1], item[2] }));
            }
        }

        /// <summary>
        /// Synchronize the local DHT to the network
        /// </summary>
        private void SynchronizeLocalDHTToNetwork()
        {
            if (System.IO.File.Exists(FileUtility.REF_DIR + "dht.xml"))
            {
                SortedList<ulong, string> localDht = XMLUtility.DHTFromXML(FileUtility.REF_DIR + "dht.xml");
                foreach (string value in localDht.Values)
                {
                    storageManager.AddKey(value);
                }
            }
        }

    }
}
