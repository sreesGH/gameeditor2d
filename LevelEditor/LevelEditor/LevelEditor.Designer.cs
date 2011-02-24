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
            this.textBoxSpriteFolder = new System.Windows.Forms.TextBox();
            this.buttonBrowseSprite = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.buttonBrowseTilesetFolder = new System.Windows.Forms.Button();
            this.textBoxTilesetFolder = new System.Windows.Forms.TextBox();
            this.groupBoxObjectProperties = new System.Windows.Forms.GroupBox();
            this.pictureBoxViewer = new System.Windows.Forms.PictureBox();
            this.dataGridViewLayer = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.visibility = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.toolStripButtonAddLayer = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonTilePicker = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonPanMap = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonMoveObject = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonZoom = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonGrid = new System.Windows.Forms.ToolStripButton();
            this.menuStripLevelEditor.SuspendLayout();
            this.toolStripLevelEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTileViewer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxViewer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLayer)).BeginInit();
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
            this.newToolStripMenuItem1.Size = new System.Drawing.Size(117, 22);
            this.newToolStripMenuItem1.Text = "New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // toolStripLevelEditor
            // 
            this.toolStripLevelEditor.AutoSize = false;
            this.toolStripLevelEditor.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAddLayer,
            this.toolStripButtonTilePicker,
            this.toolStripButtonPanMap,
            this.toolStripButtonMoveObject,
            this.toolStripButtonZoom,
            this.toolStripButtonGrid});
            this.toolStripLevelEditor.Location = new System.Drawing.Point(0, 24);
            this.toolStripLevelEditor.Name = "toolStripLevelEditor";
            this.toolStripLevelEditor.Size = new System.Drawing.Size(1272, 50);
            this.toolStripLevelEditor.TabIndex = 1;
            this.toolStripLevelEditor.Text = "toolStrip1";
            // 
            // treeViewSprite
            // 
            this.treeViewSprite.Location = new System.Drawing.Point(5, 99);
            this.treeViewSprite.Name = "treeViewSprite";
            this.treeViewSprite.Size = new System.Drawing.Size(262, 267);
            this.treeViewSprite.TabIndex = 2;
            // 
            // treeViewLevel
            // 
            this.treeViewLevel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.treeViewLevel.Location = new System.Drawing.Point(5, 372);
            this.treeViewLevel.Name = "treeViewLevel";
            this.treeViewLevel.Size = new System.Drawing.Size(262, 382);
            this.treeViewLevel.TabIndex = 3;
            // 
            // treeViewTileImages
            // 
            this.treeViewTileImages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewTileImages.Location = new System.Drawing.Point(1006, 104);
            this.treeViewTileImages.Name = "treeViewTileImages";
            this.treeViewTileImages.Size = new System.Drawing.Size(257, 157);
            this.treeViewTileImages.TabIndex = 4;
            // 
            // pbTileViewer
            // 
            this.pbTileViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbTileViewer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbTileViewer.Location = new System.Drawing.Point(1006, 282);
            this.pbTileViewer.Name = "pbTileViewer";
            this.pbTileViewer.Size = new System.Drawing.Size(255, 255);
            this.pbTileViewer.TabIndex = 5;
            this.pbTileViewer.TabStop = false;
            this.pbTileViewer.Click += new System.EventHandler(this.pbTileViewer_Click);
            // 
            // textBoxSpriteFolder
            // 
            this.textBoxSpriteFolder.Location = new System.Drawing.Point(5, 76);
            this.textBoxSpriteFolder.Name = "textBoxSpriteFolder";
            this.textBoxSpriteFolder.Size = new System.Drawing.Size(204, 20);
            this.textBoxSpriteFolder.TabIndex = 7;
            // 
            // buttonBrowseSprite
            // 
            this.buttonBrowseSprite.Location = new System.Drawing.Point(211, 74);
            this.buttonBrowseSprite.Name = "buttonBrowseSprite";
            this.buttonBrowseSprite.Size = new System.Drawing.Size(56, 23);
            this.buttonBrowseSprite.TabIndex = 8;
            this.buttonBrowseSprite.Text = "Browse";
            this.buttonBrowseSprite.UseVisualStyleBackColor = true;
            this.buttonBrowseSprite.Click += new System.EventHandler(this.buttonBrowseSprite_Click);
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.HelpRequest += new System.EventHandler(this.folderBrowserDialog_HelpRequest);
            // 
            // buttonBrowseTilesetFolder
            // 
            this.buttonBrowseTilesetFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowseTilesetFolder.Location = new System.Drawing.Point(1214, 75);
            this.buttonBrowseTilesetFolder.Name = "buttonBrowseTilesetFolder";
            this.buttonBrowseTilesetFolder.Size = new System.Drawing.Size(56, 23);
            this.buttonBrowseTilesetFolder.TabIndex = 10;
            this.buttonBrowseTilesetFolder.Text = "Browse";
            this.buttonBrowseTilesetFolder.UseVisualStyleBackColor = true;
            this.buttonBrowseTilesetFolder.Click += new System.EventHandler(this.buttonBrowseTilesetFolder_Click);
            // 
            // textBoxTilesetFolder
            // 
            this.textBoxTilesetFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTilesetFolder.Location = new System.Drawing.Point(1006, 77);
            this.textBoxTilesetFolder.Name = "textBoxTilesetFolder";
            this.textBoxTilesetFolder.Size = new System.Drawing.Size(204, 20);
            this.textBoxTilesetFolder.TabIndex = 9;
            // 
            // groupBoxObjectProperties
            // 
            this.groupBoxObjectProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxObjectProperties.Location = new System.Drawing.Point(280, 579);
            this.groupBoxObjectProperties.Name = "groupBoxObjectProperties";
            this.groupBoxObjectProperties.Size = new System.Drawing.Size(714, 175);
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
            this.pictureBoxViewer.Location = new System.Drawing.Point(280, 77);
            this.pictureBoxViewer.Name = "pictureBoxViewer";
            this.pictureBoxViewer.Size = new System.Drawing.Size(714, 496);
            this.pictureBoxViewer.TabIndex = 12;
            this.pictureBoxViewer.TabStop = false;
            // 
            // dataGridViewLayer
            // 
            this.dataGridViewLayer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewLayer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLayer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.name,
            this.type,
            this.visibility});
            this.dataGridViewLayer.Location = new System.Drawing.Point(1004, 543);
            this.dataGridViewLayer.Name = "dataGridViewLayer";
            this.dataGridViewLayer.RowHeadersVisible = false;
            this.dataGridViewLayer.Size = new System.Drawing.Size(264, 211);
            this.dataGridViewLayer.TabIndex = 13;
            // 
            // id
            // 
            this.id.HeaderText = "Id";
            this.id.Name = "id";
            this.id.Width = 20;
            // 
            // name
            // 
            this.name.HeaderText = "Name";
            this.name.Name = "name";
            // 
            // type
            // 
            this.type.HeaderText = "Type";
            this.type.Items.AddRange(new object[] {
            "TILE LAYER",
            "OBJECT LAYER"});
            this.type.Name = "type";
            this.type.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // visibility
            // 
            this.visibility.HeaderText = "Visible";
            this.visibility.Name = "visibility";
            this.visibility.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.visibility.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.visibility.Width = 40;
            // 
            // toolStripButtonAddLayer
            // 
            this.toolStripButtonAddLayer.AutoSize = false;
            this.toolStripButtonAddLayer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAddLayer.Image = global::LevelEditor.Properties.Resources.addLayer;
            this.toolStripButtonAddLayer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonAddLayer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddLayer.Name = "toolStripButtonAddLayer";
            this.toolStripButtonAddLayer.Size = new System.Drawing.Size(48, 48);
            this.toolStripButtonAddLayer.Text = "Add Layer";
            // 
            // toolStripButtonTilePicker
            // 
            this.toolStripButtonTilePicker.AutoSize = false;
            this.toolStripButtonTilePicker.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonTilePicker.Image = global::LevelEditor.Properties.Resources.pickTile;
            this.toolStripButtonTilePicker.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonTilePicker.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonTilePicker.Name = "toolStripButtonTilePicker";
            this.toolStripButtonTilePicker.Size = new System.Drawing.Size(48, 48);
            this.toolStripButtonTilePicker.Text = "Pick Tile";
            // 
            // toolStripButtonPanMap
            // 
            this.toolStripButtonPanMap.AutoSize = false;
            this.toolStripButtonPanMap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonPanMap.Image = global::LevelEditor.Properties.Resources.mapmover;
            this.toolStripButtonPanMap.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonPanMap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPanMap.Name = "toolStripButtonPanMap";
            this.toolStripButtonPanMap.Size = new System.Drawing.Size(48, 48);
            this.toolStripButtonPanMap.Text = "Pan Map";
            // 
            // toolStripButtonMoveObject
            // 
            this.toolStripButtonMoveObject.AutoSize = false;
            this.toolStripButtonMoveObject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonMoveObject.Image = global::LevelEditor.Properties.Resources.objectMover;
            this.toolStripButtonMoveObject.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonMoveObject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonMoveObject.Name = "toolStripButtonMoveObject";
            this.toolStripButtonMoveObject.Size = new System.Drawing.Size(48, 48);
            this.toolStripButtonMoveObject.Text = "Move Object";
            // 
            // toolStripButtonZoom
            // 
            this.toolStripButtonZoom.AutoSize = false;
            this.toolStripButtonZoom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonZoom.Image = global::LevelEditor.Properties.Resources.zoom;
            this.toolStripButtonZoom.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonZoom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonZoom.Name = "toolStripButtonZoom";
            this.toolStripButtonZoom.Size = new System.Drawing.Size(48, 48);
            this.toolStripButtonZoom.Text = "Zoom IN / OUT";
            // 
            // toolStripButtonGrid
            // 
            this.toolStripButtonGrid.AutoSize = false;
            this.toolStripButtonGrid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonGrid.Image = global::LevelEditor.Properties.Resources.grid;
            this.toolStripButtonGrid.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonGrid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonGrid.Name = "toolStripButtonGrid";
            this.toolStripButtonGrid.Size = new System.Drawing.Size(48, 48);
            this.toolStripButtonGrid.Text = "Grid ON / OFF";
            // 
            // LevelEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1272, 766);
            this.Controls.Add(this.dataGridViewLayer);
            this.Controls.Add(this.pictureBoxViewer);
            this.Controls.Add(this.groupBoxObjectProperties);
            this.Controls.Add(this.buttonBrowseTilesetFolder);
            this.Controls.Add(this.textBoxTilesetFolder);
            this.Controls.Add(this.buttonBrowseSprite);
            this.Controls.Add(this.textBoxSpriteFolder);
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
            this.toolStripLevelEditor.ResumeLayout(false);
            this.toolStripLevelEditor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTileViewer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxViewer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLayer)).EndInit();
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
        private System.Windows.Forms.TextBox textBoxSpriteFolder;
        private System.Windows.Forms.Button buttonBrowseSprite;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button buttonBrowseTilesetFolder;
        private System.Windows.Forms.TextBox textBoxTilesetFolder;
        private System.Windows.Forms.GroupBox groupBoxObjectProperties;
        private System.Windows.Forms.PictureBox pictureBoxViewer;
        private System.Windows.Forms.DataGridView dataGridViewLayer;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewComboBoxColumn type;
        private System.Windows.Forms.DataGridViewCheckBoxColumn visibility;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddLayer;
        private System.Windows.Forms.ToolStripButton toolStripButtonTilePicker;
        private System.Windows.Forms.ToolStripButton toolStripButtonPanMap;
        private System.Windows.Forms.ToolStripButton toolStripButtonMoveObject;
        private System.Windows.Forms.ToolStripButton toolStripButtonZoom;
        private System.Windows.Forms.ToolStripButton toolStripButtonGrid;
    }
}

