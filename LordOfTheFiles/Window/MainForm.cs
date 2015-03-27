using LordOfTheFiles.Manager;
using LordOfTheFiles.Model;
using LordOfTheFiles.Utility;
using NChordLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace LordOfTheFiles.Window
{
    public partial class MainForm : Form
    {
        private ListViewItem focusedItem;

        private List<string[]> items;

        private StorageManager storageManager;

        public MainForm()
        {
            InitializeComponent();

            items = new List<string[]>();

            storageManager = new StorageManager();

            ChordNode local = ChordServer.LocalNode;
            storageManager.Instance.Join(null, local.Host, local.PortNumber);

            SynchronizeLocalDHTToNetwork();
            UpdateFileList();
        }

        private void mnuSearch_Click(object sender, EventArgs e)
        {
            SearchForm searchForm = new SearchForm();
            searchForm.ShowDialog();

            string search = searchForm.SearchText;
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

        private void mnuAddNode_Click(object sender, EventArgs e)
        {
            ListViewItem item = lvFiles.Items[0];
            storageManager.DeleteFile(items[item.Index][0] + "." + items[item.Index][1]);

            UpdateFileList();
        }

        private void cmsFileDownload_Click(object sender, EventArgs e)
        {
            ListViewItem item = focusedItem;
            storageManager.FindFile(items[item.Index][0] + "." + items[item.Index][1]);

            UpdateFileList();
        }

        private void cmsFileDelete_Click(object sender, EventArgs e)
        {
            ListViewItem item = focusedItem;
            storageManager.DeleteFile(items[item.Index][0] + "." + items[item.Index][1]);

            UpdateFileList();
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
                    items.Add(new string[] { Path.GetFileNameWithoutExtension(value), Path.GetExtension(value).Substring(1) });
                }
            }

            lvFiles.Items.Clear();

            foreach (string[] item in items)
            {
                lvFiles.Items.Add(new ListViewItem(new string[] { item[0], item[1], (item[2] != null ? item[2] : "") }));
            }
        }

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
