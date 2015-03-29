namespace LordOfTheFiles.Window
{
    partial class AddNodeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddNodeForm));
            this.lblNodeIP = new System.Windows.Forms.Label();
            this.txtNodeIP = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNodeIP
            // 
            this.lblNodeIP.AutoSize = true;
            this.lblNodeIP.Location = new System.Drawing.Point(12, 9);
            this.lblNodeIP.Name = "lblNodeIP";
            this.lblNodeIP.Size = new System.Drawing.Size(52, 13);
            this.lblNodeIP.TabIndex = 0;
            this.lblNodeIP.Text = "Node IP: ";
            // 
            // txtNodeIP
            // 
            this.txtNodeIP.Location = new System.Drawing.Point(70, 6);
            this.txtNodeIP.Name = "txtNodeIP";
            this.txtNodeIP.Size = new System.Drawing.Size(207, 20);
            this.txtNodeIP.TabIndex = 1;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(283, 4);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 2;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // AddNodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 33);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtNodeIP);
            this.Controls.Add(this.lblNodeIP);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddNodeForm";
            this.Text = "Add node";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNodeIP;
        private System.Windows.Forms.TextBox txtNodeIP;
        private System.Windows.Forms.Button btnSubmit;
    }
}