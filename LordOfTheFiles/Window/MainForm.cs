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
        private List<ListViewItem> items;

        private StorageManager storageManager;

        public MainForm()
        {
            InitializeComponent();

            items = new List<ListViewItem>();

            storageManager = new StorageManager();

            ChordNode local = ChordServer.LocalNode;
            storageManager.Instance.Join(null, local.Host, local.PortNumber);
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
                if (lvFiles.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    cms_Download.Show(Cursor.Position);

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

            //File file = new File("helloworld.txt", FileUtility.ReadBytes(Environment.CurrentDirectory + "/files/" + "helloworld.txt"));

            //Exemple på hur man addar till listView och adda till alla sub columens 
            //string[] row1 =     {"File Type" , "File Size"};
            //lvFiles.Items.Add("File Namn").SubItems.AddRange(row1);
        
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void UpdateFileList()
        {
            SortedList<ulong, string> tempDht = storageManager.GetDHT();

            foreach (string value in tempDht.Values)
            {
                ListViewItem item = new ListViewItem(new string[] { Path.GetFileNameWithoutExtension(value), Path.GetExtension(value) });
                if (!items.Contains(item))
                {
                    items.Add(item);
                }
            }

            lvFiles.Items.Clear();

            foreach (ListViewItem item in items)
            {
                lvFiles.Items.Add(item);
            }
        }


    }
}
