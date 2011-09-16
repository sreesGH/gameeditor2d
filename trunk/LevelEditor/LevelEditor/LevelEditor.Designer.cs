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
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.previewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setCameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripLevelEditor = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAddLEvel = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAddLayer = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonTilePicker = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonPanMap = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonMoveObject = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonZoom = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonGrid = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAddObject = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonPlay = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCamera = new System.Windows.Forms.ToolStripButton();
            this.treeViewSprite = new System.Windows.Forms.TreeView();
            this.treeViewLevel = new System.Windows.Forms.TreeView();
            this.treeViewTileImages = new System.Windows.Forms.TreeView();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBoxObjectProperties = new System.Windows.Forms.GroupBox();
            this.dataGridViewLayer = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.visibility = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.imageListTreeViewSprite = new System.Windows.Forms.ImageList(this.components);
            this.imageListTreeViewTileSet = new System.Windows.Forms.ImageList(this.components);
            this.timerUpdate = new System.Windows.Forms.Timer(this.components);
            this.checkBoxShowTileGrid = new System.Windows.Forms.CheckBox();
            this.saveFileDialogLevel = new System.Windows.Forms.SaveFileDialog();
            this.tabControlLevelEditor = new System.Windows.Forms.TabControl();
            this.tabPageLevel = new System.Windows.Forms.TabPage();
            this.tabPageSprtie = new System.Windows.Forms.TabPage();
            this.tabPageSound = new System.Windows.Forms.TabPage();
            this.tabPageText = new System.Windows.Forms.TabPage();
            this.panelTileMap = new System.Windows.Forms.Panel();
            this.pbTileViewer = new System.Windows.Forms.PictureBox();
            this.panelMainViewer = new System.Windows.Forms.Panel();
            this.pbViewer = new System.Windows.Forms.PictureBox();
            this.buttonDeleteLayer = new System.Windows.Forms.Button();
            this.menuStripLevelEditor.SuspendLayout();
            this.toolStripLevelEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLayer)).BeginInit();
            this.tabControlLevelEditor.SuspendLayout();
            this.tabPageLevel.SuspendLayout();
            this.tabPageSprtie.SuspendLayout();
            this.panelTileMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTileViewer)).BeginInit();
            this.panelMainViewer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbViewer)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStripLevelEditor
            // 
            this.menuStripLevelEditor.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.editToolStripMenuItem,
            this.projectToolStripMenuItem});
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
            this.saveToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.newToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem1
            // 
            this.newToolStripMenuItem1.Name = "newToolStripMenuItem1";
            this.newToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem1.Size = new System.Drawing.Size(151, 22);
            this.newToolStripMenuItem1.Text = "New";
            this.newToolStripMenuItem1.Click += new System.EventHandler(this.newToolStripMenuItem1_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.refreshToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // projectToolStripMenuItem
            // 
            this.projectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.previewToolStripMenuItem,
            this.setCameraToolStripMenuItem});
            this.projectToolStripMenuItem.Name = "projectToolStripMenuItem";
            this.projectToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.projectToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.projectToolStripMenuItem.Text = "Project";
            // 
            // previewToolStripMenuItem
            // 
            this.previewToolStripMenuItem.Name = "previewToolStripMenuItem";
            this.previewToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.previewToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.previewToolStripMenuItem.Text = "Preview";
            this.previewToolStripMenuItem.Click += new System.EventHandler(this.previewToolStripMenuItem_Click);
            // 
            // setCameraToolStripMenuItem
            // 
            this.setCameraToolStripMenuItem.Name = "setCameraToolStripMenuItem";
            this.setCameraToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.setCameraToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.setCameraToolStripMenuItem.Text = "Set Camera";
            this.setCameraToolStripMenuItem.Click += new System.EventHandler(this.setCameraToolStripMenuItem_Click);
            // 
            // toolStripLevelEditor
            // 
            this.toolStripLevelEditor.AutoSize = false;
            this.toolStripLevelEditor.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonOpen,
            this.toolStripButtonAddLEvel,
            this.toolStripButtonAddLayer,
            this.toolStripButtonTilePicker,
            this.toolStripButtonPanMap,
            this.toolStripButtonMoveObject,
            this.toolStripButtonZoom,
            this.toolStripButtonGrid,
            this.toolStripButtonAddObject,
            this.toolStripButtonPlay,
            this.toolStripButtonRefresh,
            this.toolStripButtonCamera});
            this.toolStripLevelEditor.Location = new System.Drawing.Point(0, 24);
            this.toolStripLevelEditor.Name = "toolStripLevelEditor";
            this.toolStripLevelEditor.Size = new System.Drawing.Size(1272, 50);
            this.toolStripLevelEditor.TabIndex = 1;
            this.toolStripLevelEditor.Text = "toolStrip1";
            // 
            // toolStripButtonOpen
            // 
            this.toolStripButtonOpen.AutoSize = false;
            this.toolStripButtonOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonOpen.Image = global::LevelEditor.Properties.Resources.open;
            this.toolStripButtonOpen.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOpen.Name = "toolStripButtonOpen";
            this.toolStripButtonOpen.Size = new System.Drawing.Size(48, 48);
            this.toolStripButtonOpen.Text = "Open";
            this.toolStripButtonOpen.Click += new System.EventHandler(this.toolStripButtonOpen_Click);
            // 
            // toolStripButtonAddLEvel
            // 
            this.toolStripButtonAddLEvel.AutoSize = false;
            this.toolStripButtonAddLEvel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAddLEvel.Image = global::LevelEditor.Properties.Resources.addLevel;
            this.toolStripButtonAddLEvel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonAddLEvel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddLEvel.Name = "toolStripButtonAddLEvel";
            this.toolStripButtonAddLEvel.Size = new System.Drawing.Size(48, 48);
            this.toolStripButtonAddLEvel.Text = "Add Level";
            this.toolStripButtonAddLEvel.Click += new System.EventHandler(this.toolStripButtonAddLEvel_Click);
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
            this.toolStripButtonAddLayer.Click += new System.EventHandler(this.toolStripButtonAddLayer_Click);
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
            this.toolStripButtonGrid.Click += new System.EventHandler(this.toolStripButtonGrid_Click);
            // 
            // toolStripButtonAddObject
            // 
            this.toolStripButtonAddObject.AutoSize = false;
            this.toolStripButtonAddObject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAddObject.Image = global::LevelEditor.Properties.Resources.trigger;
            this.toolStripButtonAddObject.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonAddObject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddObject.Name = "toolStripButtonAddObject";
            this.toolStripButtonAddObject.Size = new System.Drawing.Size(48, 48);
            this.toolStripButtonAddObject.Text = "Add Object";
            this.toolStripButtonAddObject.Click += new System.EventHandler(this.toolStripButtonAddObject_Click);
            // 
            // toolStripButtonPlay
            // 
            this.toolStripButtonPlay.AutoSize = false;
            this.toolStripButtonPlay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonPlay.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPlay.Image")));
            this.toolStripButtonPlay.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonPlay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPlay.Name = "toolStripButtonPlay";
            this.toolStripButtonPlay.Size = new System.Drawing.Size(48, 48);
            this.toolStripButtonPlay.Text = "Play";
            this.toolStripButtonPlay.Click += new System.EventHandler(this.toolStripButtonPlay_Click);
            // 
            // toolStripButtonRefresh
            // 
            this.toolStripButtonRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRefresh.Image = global::LevelEditor.Properties.Resources.refresh;
            this.toolStripButtonRefresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRefresh.Name = "toolStripButtonRefresh";
            this.toolStripButtonRefresh.Size = new System.Drawing.Size(52, 47);
            this.toolStripButtonRefresh.Text = "Reload";
            this.toolStripButtonRefresh.Click += new System.EventHandler(this.toolStripButtonRefresh_Click);
            // 
            // toolStripButtonCamera
            // 
            this.toolStripButtonCamera.AutoSize = false;
            this.toolStripButtonCamera.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCamera.Image = global::LevelEditor.Properties.Resources.camera;
            this.toolStripButtonCamera.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonCamera.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCamera.Name = "toolStripButtonCamera";
            this.toolStripButtonCamera.Size = new System.Drawing.Size(48, 48);
            this.toolStripButtonCamera.Text = "Camera";
            this.toolStripButtonCamera.Click += new System.EventHandler(this.toolStripButtonCamera_Click);
            // 
            // treeViewSprite
            // 
            this.treeViewSprite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.treeViewSprite.Location = new System.Drawing.Point(0, 6);
            this.treeViewSprite.Name = "treeViewSprite";
            this.treeViewSprite.Size = new System.Drawing.Size(241, 624);
            this.treeViewSprite.TabIndex = 2;
            this.treeViewSprite.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.treeViewSprite_AfterCollapse);
            this.treeViewSprite.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewSprite_AfterSelect);
            this.treeViewSprite.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeViewSprite_AfterExpand);
            // 
            // treeViewLevel
            // 
            this.treeViewLevel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.treeViewLevel.Location = new System.Drawing.Point(3, 6);
            this.treeViewLevel.Name = "treeViewLevel";
            this.treeViewLevel.Size = new System.Drawing.Size(238, 632);
            this.treeViewLevel.TabIndex = 3;
            // 
            // treeViewTileImages
            // 
            this.treeViewTileImages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewTileImages.Location = new System.Drawing.Point(992, 81);
            this.treeViewTileImages.Name = "treeViewTileImages";
            this.treeViewTileImages.Size = new System.Drawing.Size(257, 195);
            this.treeViewTileImages.TabIndex = 4;
            this.treeViewTileImages.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.treeViewTileImages_AfterCollapse);
            this.treeViewTileImages.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewTileImages_AfterSelect);
            this.treeViewTileImages.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeViewTileImages_AfterExpand);
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
            this.dataGridViewLayer.Size = new System.Drawing.Size(264, 134);
            this.dataGridViewLayer.TabIndex = 13;
            // 
            // id
            // 
            this.id.HeaderText = "Id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
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
            this.type.Name = "type";
            this.type.ReadOnly = true;
            this.type.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // visibility
            // 
            this.visibility.HeaderText = "Visible";
            this.visibility.Name = "visibility";
            this.visibility.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.visibility.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.visibility.Width = 40;
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
            // timerUpdate
            // 
            this.timerUpdate.Tick += new System.EventHandler(this.timerUpdate_Tick);
            // 
            // checkBoxShowTileGrid
            // 
            this.checkBoxShowTileGrid.AutoSize = true;
            this.checkBoxShowTileGrid.Location = new System.Drawing.Point(1004, 560);
            this.checkBoxShowTileGrid.Name = "checkBoxShowTileGrid";
            this.checkBoxShowTileGrid.Size = new System.Drawing.Size(75, 17);
            this.checkBoxShowTileGrid.TabIndex = 16;
            this.checkBoxShowTileGrid.Text = "Show Grid";
            this.checkBoxShowTileGrid.UseVisualStyleBackColor = true;
            // 
            // saveFileDialogLevel
            // 
            this.saveFileDialogLevel.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialogLevel_FileOk);
            // 
            // tabControlLevelEditor
            // 
            this.tabControlLevelEditor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControlLevelEditor.Controls.Add(this.tabPageLevel);
            this.tabControlLevelEditor.Controls.Add(this.tabPageSprtie);
            this.tabControlLevelEditor.Controls.Add(this.tabPageSound);
            this.tabControlLevelEditor.Controls.Add(this.tabPageText);
            this.tabControlLevelEditor.Location = new System.Drawing.Point(11, 81);
            this.tabControlLevelEditor.Name = "tabControlLevelEditor";
            this.tabControlLevelEditor.SelectedIndex = 0;
            this.tabControlLevelEditor.Size = new System.Drawing.Size(255, 670);
            this.tabControlLevelEditor.TabIndex = 17;
            // 
            // tabPageLevel
            // 
            this.tabPageLevel.Controls.Add(this.treeViewLevel);
            this.tabPageLevel.Location = new System.Drawing.Point(4, 22);
            this.tabPageLevel.Name = "tabPageLevel";
            this.tabPageLevel.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLevel.Size = new System.Drawing.Size(247, 644);
            this.tabPageLevel.TabIndex = 1;
            this.tabPageLevel.Text = "Levels";
            this.tabPageLevel.UseVisualStyleBackColor = true;
            // 
            // tabPageSprtie
            // 
            this.tabPageSprtie.Controls.Add(this.treeViewSprite);
            this.tabPageSprtie.Location = new System.Drawing.Point(4, 22);
            this.tabPageSprtie.Name = "tabPageSprtie";
            this.tabPageSprtie.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSprtie.Size = new System.Drawing.Size(247, 644);
            this.tabPageSprtie.TabIndex = 0;
            this.tabPageSprtie.Text = "Sprites";
            this.tabPageSprtie.UseVisualStyleBackColor = true;
            // 
            // tabPageSound
            // 
            this.tabPageSound.Location = new System.Drawing.Point(4, 22);
            this.tabPageSound.Name = "tabPageSound";
            this.tabPageSound.Size = new System.Drawing.Size(247, 644);
            this.tabPageSound.TabIndex = 2;
            this.tabPageSound.Text = "Sounds";
            this.tabPageSound.UseVisualStyleBackColor = true;
            // 
            // tabPageText
            // 
            this.tabPageText.Location = new System.Drawing.Point(4, 22);
            this.tabPageText.Name = "tabPageText";
            this.tabPageText.Size = new System.Drawing.Size(247, 644);
            this.tabPageText.TabIndex = 3;
            this.tabPageText.Text = "Texts";
            this.tabPageText.UseVisualStyleBackColor = true;
            // 
            // panelTileMap
            // 
            this.panelTileMap.AutoScroll = true;
            this.panelTileMap.Controls.Add(this.pbTileViewer);
            this.panelTileMap.Location = new System.Drawing.Point(994, 291);
            this.panelTileMap.Name = "panelTileMap";
            this.panelTileMap.Size = new System.Drawing.Size(274, 263);
            this.panelTileMap.TabIndex = 18;
            // 
            // pbTileViewer
            // 
            this.pbTileViewer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbTileViewer.Location = new System.Drawing.Point(10, 3);
            this.pbTileViewer.Name = "pbTileViewer";
            this.pbTileViewer.Size = new System.Drawing.Size(256, 256);
            this.pbTileViewer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbTileViewer.TabIndex = 5;
            this.pbTileViewer.TabStop = false;
            // 
            // panelMainViewer
            // 
            this.panelMainViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMainViewer.AutoScroll = true;
            this.panelMainViewer.Controls.Add(this.pbViewer);
            this.panelMainViewer.Location = new System.Drawing.Point(276, 85);
            this.panelMainViewer.Name = "panelMainViewer";
            this.panelMainViewer.Size = new System.Drawing.Size(710, 488);
            this.panelMainViewer.TabIndex = 19;
            // 
            // pbViewer
            // 
            this.pbViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbViewer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbViewer.Location = new System.Drawing.Point(4, 3);
            this.pbViewer.Name = "pbViewer";
            this.pbViewer.Size = new System.Drawing.Size(703, 482);
            this.pbViewer.TabIndex = 12;
            this.pbViewer.TabStop = false;
            // 
            // buttonDeleteLayer
            // 
            this.buttonDeleteLayer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDeleteLayer.Location = new System.Drawing.Point(1005, 728);
            this.buttonDeleteLayer.Name = "buttonDeleteLayer";
            this.buttonDeleteLayer.Size = new System.Drawing.Size(262, 25);
            this.buttonDeleteLayer.TabIndex = 20;
            this.buttonDeleteLayer.Text = "Delete Layer";
            this.buttonDeleteLayer.UseVisualStyleBackColor = true;
            this.buttonDeleteLayer.Click += new System.EventHandler(this.buttonDeleteLayer_Click);
            // 
            // LevelEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1272, 766);
            this.Controls.Add(this.buttonDeleteLayer);
            this.Controls.Add(this.panelMainViewer);
            this.Controls.Add(this.checkBoxShowTileGrid);
            this.Controls.Add(this.panelTileMap);
            this.Controls.Add(this.tabControlLevelEditor);
            this.Controls.Add(this.dataGridViewLayer);
            this.Controls.Add(this.groupBoxObjectProperties);
            this.Controls.Add(this.treeViewTileImages);
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
            this.tabControlLevelEditor.ResumeLayout(false);
            this.tabPageLevel.ResumeLayout(false);
            this.tabPageSprtie.ResumeLayout(false);
            this.panelTileMap.ResumeLayout(false);
            this.panelTileMap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTileViewer)).EndInit();
            this.panelMainViewer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbViewer)).EndInit();
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
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.GroupBox groupBoxObjectProperties;
        private System.Windows.Forms.PictureBox pbViewer;
        private System.Windows.Forms.DataGridView dataGridViewLayer;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddLayer;
        private System.Windows.Forms.ToolStripButton toolStripButtonTilePicker;
        private System.Windows.Forms.ToolStripButton toolStripButtonPanMap;
        private System.Windows.Forms.ToolStripButton toolStripButtonMoveObject;
        private System.Windows.Forms.ToolStripButton toolStripButtonZoom;
        private System.Windows.Forms.ToolStripButton toolStripButtonGrid;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddObject;
        private System.Windows.Forms.ImageList imageListTreeViewSprite;
        private System.Windows.Forms.ImageList imageListTreeViewTileSet;
        private System.Windows.Forms.Timer timerUpdate;
        private System.Windows.Forms.CheckBox checkBoxShowTileGrid;
        private System.Windows.Forms.ToolStripButton toolStripButtonPlay;
        private System.Windows.Forms.SaveFileDialog saveFileDialogLevel;
        private System.Windows.Forms.ToolStripButton toolStripButtonRefresh;
        private System.Windows.Forms.TabControl tabControlLevelEditor;
        private System.Windows.Forms.TabPage tabPageSprtie;
        private System.Windows.Forms.TabPage tabPageLevel;
        private System.Windows.Forms.TabPage tabPageSound;
        private System.Windows.Forms.TabPage tabPageText;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonCamera;
        private System.Windows.Forms.PictureBox pbTileViewer;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem previewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setCameraToolStripMenuItem;
        private System.Windows.Forms.Panel panelTileMap;
        private System.Windows.Forms.Panel panelMainViewer;
        private System.Windows.Forms.ToolStripButton toolStripButtonOpen;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewCheckBoxColumn visibility;
        private System.Windows.Forms.Button buttonDeleteLayer;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddLEvel;
    }
}

