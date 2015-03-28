namespace LordOfTheFiles.Window
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mnuMenu = new System.Windows.Forms.MenuStrip();
            this.mnuMenuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMenuNodes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddNode = new System.Windows.Forms.ToolStripMenuItem();
            this.lvFiles = new System.Windows.Forms.ListView();
            this.chFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_FileExtension = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chFileSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmsFile = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsFileDownload = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsFileDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMenu.SuspendLayout();
            this.cmsFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMenu
            // 
            this.mnuMenu.BackColor = System.Drawing.Color.White;
            this.mnuMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMenuFile,
            this.mnuMenuNodes});
            this.mnuMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMenu.Name = "mnuMenu";
            this.mnuMenu.Size = new System.Drawing.Size(517, 24);
            this.mnuMenu.TabIndex = 0;
            this.mnuMenu.Text = "menuStrip1";
            // 
            // mnuMenuFile
            // 
            this.mnuMenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAdd,
            this.mnuRefresh,
            this.mnuSearch,
            this.toolStripSeparator1,
            this.mnuExit});
            this.mnuMenuFile.Name = "mnuMenuFile";
            this.mnuMenuFile.Size = new System.Drawing.Size(46, 20);
            this.mnuMenuFile.Text = "File...";
            // 
            // mnuAdd
            // 
            this.mnuAdd.Name = "mnuAdd";
            this.mnuAdd.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.mnuAdd.Size = new System.Drawing.Size(158, 22);
            this.mnuAdd.Text = "Add...";
            this.mnuAdd.Click += new System.EventHandler(this.mnuAdd_Click);
            // 
            // mnuRefresh
            // 
            this.mnuRefresh.Name = "mnuRefresh";
            this.mnuRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.mnuRefresh.Size = new System.Drawing.Size(158, 22);
            this.mnuRefresh.Text = "Refresh";
            this.mnuRefresh.Click += new System.EventHandler(this.mnuRefresh_Click);
            // 
            // mnuSearch
            // 
            this.mnuSearch.Name = "mnuSearch";
            this.mnuSearch.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuSearch.Size = new System.Drawing.Size(158, 22);
            this.mnuSearch.Text = "Search...";
            this.mnuSearch.Click += new System.EventHandler(this.mnuSearch_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(155, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(158, 22);
            this.mnuExit.Text = "Exit";
            // 
            // mnuMenuNodes
            // 
            this.mnuMenuNodes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddNode});
            this.mnuMenuNodes.Name = "mnuMenuNodes";
            this.mnuMenuNodes.Size = new System.Drawing.Size(62, 20);
            this.mnuMenuNodes.Text = "Nodes...";
            // 
            // mnuAddNode
            // 
            this.mnuAddNode.Name = "mnuAddNode";
            this.mnuAddNode.Size = new System.Drawing.Size(126, 22);
            this.mnuAddNode.Text = "Add node";
            this.mnuAddNode.Click += new System.EventHandler(this.mnuAddNode_Click);
            // 
            // lvFiles
            // 
            this.lvFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chFileName,
            this.ch_FileExtension,
            this.chFileSize});
            this.lvFiles.FullRowSelect = true;
            this.lvFiles.Location = new System.Drawing.Point(0, 27);
            this.lvFiles.Name = "lvFiles";
            this.lvFiles.Size = new System.Drawing.Size(517, 263);
            this.lvFiles.TabIndex = 1;
            this.lvFiles.UseCompatibleStateImageBehavior = false;
            this.lvFiles.View = System.Windows.Forms.View.Details;
            this.lvFiles.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvFiles_MouseClick);
            // 
            // chFileName
            // 
            this.chFileName.Text = "Filename";
            this.chFileName.Width = 345;
            // 
            // ch_FileExtension
            // 
            this.ch_FileExtension.Text = "Extension";
            this.ch_FileExtension.Width = 81;
            // 
            // chFileSize
            // 
            this.chFileSize.Text = "Size";
            this.chFileSize.Width = 87;
            // 
            // cmsFile
            // 
            this.cmsFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsFileOpen,
            this.cmsFileDownload,
            this.cmsFileDelete});
            this.cmsFile.Name = "contextMenuStrip1";
            this.cmsFile.Size = new System.Drawing.Size(153, 92);
            // 
            // cmsFileDownload
            // 
            this.cmsFileDownload.Name = "cmsFileDownload";
            this.cmsFileDownload.Size = new System.Drawing.Size(152, 22);
            this.cmsFileDownload.Text = "Download";
            this.cmsFileDownload.Click += new System.EventHandler(this.cmsFileDownload_Click);
            // 
            // cmsFileDelete
            // 
            this.cmsFileDelete.Name = "cmsFileDelete";
            this.cmsFileDelete.Size = new System.Drawing.Size(152, 22);
            this.cmsFileDelete.Text = "Delete";
            this.cmsFileDelete.Click += new System.EventHandler(this.cmsFileDelete_Click);
            // 
            // cmsFileOpen
            // 
            this.cmsFileOpen.Name = "cmsFileOpen";
            this.cmsFileOpen.Size = new System.Drawing.Size(152, 22);
            this.cmsFileOpen.Text = "Open";
            this.cmsFileOpen.Click += new System.EventHandler(this.cmsFileOpen_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 290);
            this.Controls.Add(this.lvFiles);
            this.Controls.Add(this.mnuMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuMenu;
            this.Name = "MainForm";
            this.Text = "Lord Of The Files";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.mnuMenu.ResumeLayout(false);
            this.mnuMenu.PerformLayout();
            this.cmsFile.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuMenuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuAdd;
        private System.Windows.Forms.ToolStripMenuItem mnuRefresh;
        private System.Windows.Forms.ToolStripMenuItem mnuSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ListView lvFiles;
        private System.Windows.Forms.ColumnHeader chFileName;
        private System.Windows.Forms.ColumnHeader ch_FileExtension;
        private System.Windows.Forms.ColumnHeader chFileSize;
        private System.Windows.Forms.ContextMenuStrip cmsFile;
        private System.Windows.Forms.ToolStripMenuItem cmsFileDownload;
        private System.Windows.Forms.ToolStripMenuItem mnuMenuNodes;
        private System.Windows.Forms.ToolStripMenuItem mnuAddNode;
        private System.Windows.Forms.ToolStripMenuItem cmsFileDelete;
        private System.Windows.Forms.ToolStripMenuItem cmsFileOpen;
    }
}