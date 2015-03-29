using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LordOfTheFiles.Window
{
    public partial class AddNodeForm : Form
    {
        public AddNodeForm()
        {
            InitializeComponent();
        }

        public string NodeIP
        {
            get { return txtNodeIP.Text; }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
