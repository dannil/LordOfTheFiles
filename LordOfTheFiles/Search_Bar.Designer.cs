namespace LordOfTheFiles
{
    partial class Search_Bar
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
            this.bt_Search = new System.Windows.Forms.Button();
            this.tb_Search = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // bt_Search
            // 
            this.bt_Search.BackgroundImage = global::LordOfTheFiles.Properties.Resources.HighligtedButtom;
            this.bt_Search.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_Search.ForeColor = System.Drawing.Color.Red;
            this.bt_Search.Location = new System.Drawing.Point(197, 12);
            this.bt_Search.Name = "bt_Search";
            this.bt_Search.Size = new System.Drawing.Size(75, 23);
            this.bt_Search.TabIndex = 0;
            this.bt_Search.Text = "Search";
            this.bt_Search.UseVisualStyleBackColor = true;
            this.bt_Search.Click += new System.EventHandler(this.bt_Search_Click);
            // 
            // tb_Search
            // 
            this.tb_Search.Location = new System.Drawing.Point(12, 14);
            this.tb_Search.Name = "tb_Search";
            this.tb_Search.Size = new System.Drawing.Size(179, 20);
            this.tb_Search.TabIndex = 1;
            // 
            // Search_Bar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LordOfTheFiles.Properties.Resources.Background;
            this.ClientSize = new System.Drawing.Size(284, 48);
            this.Controls.Add(this.tb_Search);
            this.Controls.Add(this.bt_Search);
            this.Name = "Search_Bar";
            this.Text = "Search_Bar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_Search;
        private System.Windows.Forms.TextBox tb_Search;
    }
}