using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LordOfTheFiles
{
    public partial class GUI : Form
    {
        public GUI()
        {
            InitializeComponent();
        }

        /// <summary>
        /// För högerclick på listviewn för att kunna få upp menun download
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lv_Item_List_MouseClick_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (lv_Item_List.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    cms_Download.Show(Cursor.Position);

                }
            }
        }

        /// <summary>
        /// Download knapp i contextmenu för listView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void downloadToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Add knapp i menustrip
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Exemple på hur man addar till listView och adda till alla sub columens 
            //string[] row1 =     {"File Type" , "File Size"};
            //lv_Item_List.Items.Add("File Namn").SubItems.AddRange(row1);
        }

        /// <summary>
        /// Refresh knapp i Menustrip
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Exit knapp i Menustrip
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Textbox kontroll för att kontrolla när användaren clickar i enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ts_Search_TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {

            }
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Search_Bar search_Bar = new Search_Bar();
            search_Bar.ShowDialog();
        }

        
    }
}