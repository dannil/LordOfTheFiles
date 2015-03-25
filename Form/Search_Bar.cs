using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LordOfTheFiles
{
    public partial class Search_Bar : Form
    {
        string söktexten = "";

        public string Söktexten
        { get { return söktexten; } }
        
        public Search_Bar()
        {
            InitializeComponent();
        }

        private void bt_Search_Click(object sender, EventArgs e)
        {

        }
    }
}
