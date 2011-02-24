namespace LevelEditor
{
    partial class LevelEditor
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
            this.menuStripLevelEditor = new System.Windows.Forms.MenuStrip();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripLevelEditor = new System.Windows.Forms.ToolStrip();
            this.treeViewSprite = new System.Windows.Forms.TreeView();
            this.treeViewLevel = new System.Windows.Forms.TreeView();
            this.treeViewTileImages = new System.Windows.Forms.TreeView();
            this.pbTileViewer = new System.Windows.Forms.PictureBox();
            this.listBoxLayers = new System.Windows.Forms.ListBox();
            this.textBoxSpriteFolder = new System.Windows.Forms.TextBox();
            this.buttonBrowseSprite = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.buttonBrowseTilesetFolder = new System.Windows.Forms.Button();
            this.textBoxTilesetFolder = new System.Windows.Forms.TextBox();
            this.groupBoxObjectProperties = new System.Windows.Forms.GroupBox();
            this.pictureBoxViewer = new System.Windows.Forms.PictureBox();
            this.menuStripLevelEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTileViewer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxViewer)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStripLevelEditor
            // 
            this.menuStripLevelEditor.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem});
            this.menuStripLevelEditor.Location = new System.Drawing.Point(0, 0);
            this.menuStripLevelEditor.Name = "menuStripLevelEditor";
            this.menuStripLevelEditor.Size = new System.Drawing.Size(1272, 24);
            this.menuStripLevelEditor.TabIndex = 0;
            this.menuStripLevelEditor.Text = "menuStrip1";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem1,
            this.openToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.newToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem1
            // 
            this.newToolStripMenuItem1.Name = "newToolStripMenuItem1";
            this.newToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem1.Text = "New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // toolStripLevelEditor
            // 
            this.toolStripLevelEditor.Location = new System.Drawing.Point(0, 24);
            this.toolStripLevelEditor.Name = "toolStripLevelEditor";
            this.toolStripLevelEditor.Size = new System.Drawing.Size(1272, 25);
            this.toolStripLevelEditor.TabIndex = 1;
            this.toolStripLevelEditor.Text = "toolStrip1";
            // 
            // treeViewSprite
            // 
            this.treeViewSprite.Location = new System.Drawing.Point(5, 80);
            this.treeViewSprite.Name = "treeViewSprite";
            this.treeViewSprite.Size = new System.Drawing.Size(200, 267);
            this.treeViewSprite.TabIndex = 2;
            // 
            // treeViewLevel
            // 
            this.treeViewLevel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.treeViewLevel.Location = new System.Drawing.Point(5, 353);
            this.treeViewLevel.Name = "treeViewLevel";
            this.treeViewLevel.Size = new System.Drawing.Size(200, 321);
            this.treeViewLevel.TabIndex = 3;
            // 
            // treeViewTileImages
            // 
            this.treeViewTileImages.Location = new System.Drawing.Point(1072, 85);
            this.treeViewTileImages.Name = "treeViewTileImages";
            this.treeViewTileImages.Size = new System.Drawing.Size(189, 157);
            this.treeViewTileImages.TabIndex = 4;
            // 
            // pbTileViewer
            // 
            this.pbTileViewer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbTileViewer.Location = new System.Drawing.Point(1070, 263);
            this.pbTileViewer.Name = "pbTileViewer";
            this.pbTileViewer.Size = new System.Drawing.Size(189, 271);
            this.pbTileViewer.TabIndex = 5;
            this.pbTileViewer.TabStop = false;
            this.pbTileViewer.Click += new System.EventHandler(this.pbTileViewer_Click);
            // 
            // listBoxLayers
            // 
            this.listBoxLayers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxLayers.FormattingEnabled = true;
            this.listBoxLayers.Location = new System.Drawing.Point(1072, 552);
            this.listBoxLayers.Name = "listBoxLayers";
            this.listBoxLayers.Size = new System.Drawing.Size(187, 121);
            this.listBoxLayers.TabIndex = 6;
            // 
            // textBoxSpriteFolder
            // 
            this.textBoxSpriteFolder.Location = new System.Drawing.Point(5, 57);
            this.textBoxSpriteFolder.Name = "textBoxSpriteFolder";
            this.textBoxSpriteFolder.Size = new System.Drawing.Size(138, 20);
            this.textBoxSpriteFolder.TabIndex = 7;
            // 
            // buttonBrowseSprite
            // 
            this.buttonBrowseSprite.Location = new System.Drawing.Point(149, 55);
            this.buttonBrowseSprite.Name = "buttonBrowseSprite";
            this.buttonBrowseSprite.Size = new System.Drawing.Size(56, 23);
            this.buttonBrowseSprite.TabIndex = 8;
            this.buttonBrowseSprite.Text = "Browse";
            this.buttonBrowseSprite.UseVisualStyleBackColor = true;
            this.buttonBrowseSprite.Click += new System.EventHandler(this.buttonBrowseSprite_Click);
            // 
            // buttonBrowseTilesetFolder
            // 
            this.buttonBrowseTilesetFolder.Location = new System.Drawing.Point(1214, 56);
            this.buttonBrowseTilesetFolder.Name = "buttonBrowseTilesetFolder";
            this.buttonBrowseTilesetFolder.Size = new System.Drawing.Size(56, 23);
            this.buttonBrowseTilesetFolder.TabIndex = 10;
            this.buttonBrowseTilesetFolder.Text = "Browse";
            this.buttonBrowseTilesetFolder.UseVisualStyleBackColor = true;
            this.buttonBrowseTilesetFolder.Click += new System.EventHandler(this.buttonBrowseTilesetFolder_Click);
            // 
            // textBoxTilesetFolder
            // 
            this.textBoxTilesetFolder.Location = new System.Drawing.Point(1070, 58);
            this.textBoxTilesetFolder.Name = "textBoxTilesetFolder";
            this.textBoxTilesetFolder.Size = new System.Drawing.Size(138, 20);
            this.textBoxTilesetFolder.TabIndex = 9;
            // 
            // groupBoxObjectProperties
            // 
            this.groupBoxObjectProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxObjectProperties.Location = new System.Drawing.Point(215, 514);
            this.groupBoxObjectProperties.Name = "groupBoxObjectProperties";
            this.groupBoxObjectProperties.Size = new System.Drawing.Size(830, 158);
            this.groupBoxObjectProperties.TabIndex = 11;
            this.groupBoxObjectProperties.TabStop = false;
            this.groupBoxObjectProperties.Text = "ObjectProperties";
            // 
            // pictureBoxViewer
            // 
            this.pictureBoxViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxViewer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxViewer.Location = new System.Drawing.Point(215, 58);
            this.pictureBoxViewer.Name = "pictureBoxViewer";
            this.pictureBoxViewer.Size = new System.Drawing.Size(830, 450);
            this.pictureBoxViewer.TabIndex = 12;
            this.pictureBoxViewer.TabStop = false;
            // 
            // LevelEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1272, 686);
            this.Controls.Add(this.pictureBoxViewer);
            this.Controls.Add(this.groupBoxObjectProperties);
            this.Controls.Add(this.buttonBrowseTilesetFolder);
            this.Controls.Add(this.textBoxTilesetFolder);
            this.Controls.Add(this.buttonBrowseSprite);
            this.Controls.Add(this.textBoxSpriteFolder);
            this.Controls.Add(this.listBoxLayers);
            this.Controls.Add(this.pbTileViewer);
            this.Controls.Add(this.treeViewTileImages);
            this.Controls.Add(this.treeViewLevel);
            this.Controls.Add(this.treeViewSprite);
            this.Controls.Add(this.toolStripLevelEditor);
            this.Controls.Add(this.menuStripLevelEditor);
            this.MainMenuStrip = this.menuStripLevelEditor;
            this.Name = "LevelEditor";
            this.Text = "Level Editor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStripLevelEditor.ResumeLayout(false);
            this.menuStripLevelEditor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTileViewer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxViewer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripLevelEditor;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStripLevelEditor;
        private System.Windows.Forms.TreeView treeViewSprite;
        private System.Windows.Forms.TreeView treeViewLevel;
        private System.Windows.Forms.TreeView treeViewTileImages;
        private System.Windows.Forms.PictureBox pbTileViewer;
        private System.Windows.Forms.ListBox listBoxLayers;
        private System.Windows.Forms.TextBox textBoxSpriteFolder;
        private System.Windows.Forms.Button buttonBrowseSprite;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button buttonBrowseTilesetFolder;
        private System.Windows.Forms.TextBox textBoxTilesetFolder;
        private System.Windows.Forms.GroupBox groupBoxObjectProperties;
        private System.Windows.Forms.PictureBox pictureBoxViewer;
    }
}

