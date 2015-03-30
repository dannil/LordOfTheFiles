using LordOfTheFiles.Utility;
using NChordLib;
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
    public partial class StatusForm : Form
    {
        private IPAddressUtility ipAddressUtility;

        public StatusForm()
        {
            InitializeComponent();

            ipAddressUtility = new IPAddressUtility();

            txtInternalIP.Text = ipAddressUtility.LocalIPv4.ToString();
            txtExternalIP.Text = ipAddressUtility.ExternalIPv4.ToString();
            txtPort.Text = ipAddressUtility.Port.ToString();

            txtPredecessor.Text = ChordServer.GetPredecessor(ChordServer.LocalNode).Host;
            txtSuccessor.Text = ChordServer.GetSuccessor(ChordServer.LocalNode).Host;
        }
    }
}
