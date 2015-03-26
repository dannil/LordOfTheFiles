using LordOfTheFiles.Manager;
using NChordLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LordOfTheFiles.Window
{
    public partial class MainForm : Form
    {
        private StorageManager storageManager;

        public MainForm()
        {
            InitializeComponent();

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
            //Exemple på hur man addar till listView och adda till alla sub columens 
            //string[] row1 =     {"File Type" , "File Size"};
            //lvFiles.Items.Add("File Namn").SubItems.AddRange(row1);
        
        }


    }
}
