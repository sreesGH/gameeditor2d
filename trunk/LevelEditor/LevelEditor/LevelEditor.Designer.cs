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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LevelEditor));
            this.menuStripLevelEditor = new System.Windows.Forms.MenuStrip();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripLevelEditor = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonAddLayer = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonTilePicker = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonPanMap = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonMoveObject = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonZoom = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonGrid = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAddTrigger = new System.Windows.Forms.ToolStripButton();
            this.treeViewSprite = new System.Windows.Forms.TreeView();
            this.treeViewLevel = new System.Windows.Forms.TreeView();
            this.treeViewTileImages = new System.Windows.Forms.TreeView();
            this.textBoxSpriteFolder = new System.Windows.Forms.TextBox();
            this.buttonBrowseSprite = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.buttonBrowseTilesetFolder = new System.Windows.Forms.Button();
            this.textBoxTilesetFolder = new System.Windows.Forms.TextBox();
            this.groupBoxObjectProperties = new System.Windows.Forms.GroupBox();
            this.dataGridViewLayer = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.visibility = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pbViewer = new System.Windows.Forms.PictureBox();
            this.pbTileViewer = new System.Windows.Forms.PictureBox();
            this.imageListTreeViewSprite = new System.Windows.Forms.ImageList(this.components);
            this.imageListTreeViewTileSet = new System.Windows.Forms.ImageList(this.components);
            this.hScrollBarPbViewerTileSet = new System.Windows.Forms.HScrollBar();
            this.vScrollBarPbViewerTileSet = new System.Windows.Forms.VScrollBar();
            this.timerUpdate = new System.Windows.Forms.Timer(this.components);
            this.menuStripLevelEditor.SuspendLayout();
            this.toolStripLevelEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbViewer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTileViewer)).BeginInit();
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
            this.toolStripButtonGrid,
            this.toolStripButtonAddTrigger});
            this.toolStripLevelEditor.Location = new System.Drawing.Point(0, 24);
            this.toolStripLevelEditor.Name = "toolStripLevelEditor";
            this.toolStripLevelEditor.Size = new System.Drawing.Size(1272, 50);
            this.toolStripLevelEditor.TabIndex = 1;
            this.toolStripLevelEditor.Text = "toolStrip1";
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
            // toolStripButtonAddTrigger
            // 
            this.toolStripButtonAddTrigger.AutoSize = false;
            this.toolStripButtonAddTrigger.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAddTrigger.Image = global::LevelEditor.Properties.Resources.trigger;
            this.toolStripButtonAddTrigger.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonAddTrigger.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddTrigger.Name = "toolStripButtonAddTrigger";
            this.toolStripButtonAddTrigger.Size = new System.Drawing.Size(48, 48);
            this.toolStripButtonAddTrigger.Text = "Add Trigger";
            // 
            // treeViewSprite
            // 
            this.treeViewSprite.Location = new System.Drawing.Point(5, 99);
            this.treeViewSprite.Name = "treeViewSprite";
            this.treeViewSprite.Size = new System.Drawing.Size(262, 267);
            this.treeViewSprite.TabIndex = 2;
            this.treeViewSprite.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.treeViewSprite_AfterCollapse);
            this.treeViewSprite.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewSprite_AfterSelect);
            this.treeViewSprite.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeViewSprite_AfterExpand);
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
            this.treeViewTileImages.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.treeViewTileImages_AfterCollapse);
            this.treeViewTileImages.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewTileImages_AfterSelect);
            this.treeViewTileImages.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeViewTileImages_AfterExpand);
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
            this.dataGridViewLayer.Location = new System.Drawing.Point(1004, 588);
            this.dataGridViewLayer.Name = "dataGridViewLayer";
            this.dataGridViewLayer.RowHeadersVisible = false;
            this.dataGridViewLayer.Size = new System.Drawing.Size(264, 166);
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
            // pbViewer
            // 
            this.pbViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbViewer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbViewer.Location = new System.Drawing.Point(280, 77);
            this.pbViewer.Name = "pbViewer";
            this.pbViewer.Size = new System.Drawing.Size(714, 496);
            this.pbViewer.TabIndex = 12;
            this.pbViewer.TabStop = false;
            // 
            // pbTileViewer
            // 
            this.pbTileViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbTileViewer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbTileViewer.Location = new System.Drawing.Point(1000, 282);
            this.pbTileViewer.Name = "pbTileViewer";
            this.pbTileViewer.Size = new System.Drawing.Size(255, 255);
            this.pbTileViewer.TabIndex = 5;
            this.pbTileViewer.TabStop = false;
            // 
            // imageListTreeViewSprite
            // 
            this.imageListTreeViewSprite.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListTreeViewSprite.ImageStream")));
            this.imageListTreeViewSprite.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListTreeViewSprite.Images.SetKeyName(0, "folderClosed.png");
            this.imageListTreeViewSprite.Images.SetKeyName(1, "folderOpned.png");
            this.imageListTreeViewSprite.Images.SetKeyName(2, "GEditorRed.png");
            this.imageListTreeViewSprite.Images.SetKeyName(3, "GEditorBlue.png");
            // 
            // imageListTreeViewTileSet
            // 
            this.imageListTreeViewTileSet.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListTreeViewTileSet.ImageStream")));
            this.imageListTreeViewTileSet.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListTreeViewTileSet.Images.SetKeyName(0, "folderClosed.png");
            this.imageListTreeViewTileSet.Images.SetKeyName(1, "folderOpned.png");
            this.imageListTreeViewTileSet.Images.SetKeyName(2, "tile_red.png");
            this.imageListTreeViewTileSet.Images.SetKeyName(3, "tile_yellow.png");
            // 
            // hScrollBarPbViewerTileSet
            // 
            this.hScrollBarPbViewerTileSet.Location = new System.Drawing.Point(1000, 540);
            this.hScrollBarPbViewerTileSet.Name = "hScrollBarPbViewerTileSet";
            this.hScrollBarPbViewerTileSet.Size = new System.Drawing.Size(255, 11);
            this.hScrollBarPbViewerTileSet.TabIndex = 14;
            this.hScrollBarPbViewerTileSet.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBarPbViewerTileSet_Scroll);
            // 
            // vScrollBarPbViewerTileSet
            // 
            this.vScrollBarPbViewerTileSet.Location = new System.Drawing.Point(1258, 282);
            this.vScrollBarPbViewerTileSet.Name = "vScrollBarPbViewerTileSet";
            this.vScrollBarPbViewerTileSet.Size = new System.Drawing.Size(10, 255);
            this.vScrollBarPbViewerTileSet.TabIndex = 15;
            this.vScrollBarPbViewerTileSet.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
            // 
            // timerUpdate
            // 
            this.timerUpdate.Tick += new System.EventHandler(this.timerUpdate_Tick);
            // 
            // LevelEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1272, 766);
            this.Controls.Add(this.vScrollBarPbViewerTileSet);
            this.Controls.Add(this.hScrollBarPbViewerTileSet);
            this.Controls.Add(this.dataGridViewLayer);
            this.Controls.Add(this.pbViewer);
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
            this.Load += new System.EventHandler(this.LevelEditor_Load);
            this.Resize += new System.EventHandler(this.LevelEditor_Resize);
            this.menuStripLevelEditor.ResumeLayout(false);
            this.menuStripLevelEditor.PerformLayout();
            this.toolStripLevelEditor.ResumeLayout(false);
            this.toolStripLevelEditor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbViewer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTileViewer)).EndInit();
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
        private System.Windows.Forms.PictureBox pbViewer;
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
        private System.Windows.Forms.ToolStripButton toolStripButtonAddTrigger;
        private System.Windows.Forms.ImageList imageListTreeViewSprite;
        private System.Windows.Forms.ImageList imageListTreeViewTileSet;
        private System.Windows.Forms.HScrollBar hScrollBarPbViewerTileSet;
        private System.Windows.Forms.VScrollBar vScrollBarPbViewerTileSet;
        private System.Windows.Forms.Timer timerUpdate;
    }
}

