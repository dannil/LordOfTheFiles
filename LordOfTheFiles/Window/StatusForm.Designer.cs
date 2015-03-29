namespace LordOfTheFiles.Window
{
    partial class StatusForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatusForm));
            this.lblInternalIP = new System.Windows.Forms.Label();
            this.lblExternalIP = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtInternalIP = new System.Windows.Forms.TextBox();
            this.txtExternalIP = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblInternalIP
            // 
            this.lblInternalIP.AutoSize = true;
            this.lblInternalIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInternalIP.Location = new System.Drawing.Point(12, 9);
            this.lblInternalIP.Name = "lblInternalIP";
            this.lblInternalIP.Size = new System.Drawing.Size(72, 16);
            this.lblInternalIP.TabIndex = 0;
            this.lblInternalIP.Text = "Internal IP: ";
            // 
            // lblExternalIP
            // 
            this.lblExternalIP.AutoSize = true;
            this.lblExternalIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExternalIP.Location = new System.Drawing.Point(12, 35);
            this.lblExternalIP.Name = "lblExternalIP";
            this.lblExternalIP.Size = new System.Drawing.Size(77, 16);
            this.lblExternalIP.TabIndex = 1;
            this.lblExternalIP.Text = "External IP: ";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPort.Location = new System.Drawing.Point(12, 61);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(107, 16);
            this.lblPort.TabIndex = 2;
            this.lblPort.Text = "Running on port: ";
            // 
            // txtInternalIP
            // 
            this.txtInternalIP.Location = new System.Drawing.Point(90, 8);
            this.txtInternalIP.Name = "txtInternalIP";
            this.txtInternalIP.Size = new System.Drawing.Size(290, 20);
            this.txtInternalIP.TabIndex = 3;
            // 
            // txtExternalIP
            // 
            this.txtExternalIP.Location = new System.Drawing.Point(90, 34);
            this.txtExternalIP.Name = "txtExternalIP";
            this.txtExternalIP.Size = new System.Drawing.Size(290, 20);
            this.txtExternalIP.TabIndex = 4;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(125, 60);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(255, 20);
            this.txtPort.TabIndex = 5;
            // 
            // StatusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 88);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtExternalIP);
            this.Controls.Add(this.txtInternalIP);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.lblExternalIP);
            this.Controls.Add(this.lblInternalIP);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StatusForm";
            this.Text = "Status";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInternalIP;
        private System.Windows.Forms.Label lblExternalIP;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtInternalIP;
        private System.Windows.Forms.TextBox txtExternalIP;
        private System.Windows.Forms.TextBox txtPort;
    }
}