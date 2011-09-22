namespace TileMapEditor
{
    partial class frmTielMapEditor
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
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonExport = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonUndo = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRedo = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonShowGrid = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCut = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCopy = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonPaste = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSelect = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonErase = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonFlipX = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonFlipY = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRotateCW = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRotateCCW = new System.Windows.Forms.ToolStripButton();
            this.openFileDialogMap = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialogMap = new System.Windows.Forms.SaveFileDialog();
            this.panelTileSetViwer = new System.Windows.Forms.Panel();
            this.pictureBoxTileSetViewer = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBoxMapViewer = new System.Windows.Forms.PictureBox();
            this.gbTilest = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonBrowseTileSet = new System.Windows.Forms.Button();
            this.textBoxTileSetName = new System.Windows.Forms.TextBox();
            this.labelMapSize = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxMapHeight = new System.Windows.Forms.TextBox();
            this.textBoxMapWidth = new System.Windows.Forms.TextBox();
            this.textBoxTileHeight = new System.Windows.Forms.TextBox();
            this.textBoxTileWidth = new System.Windows.Forms.TextBox();
            this.checkBoxShowGrid = new System.Windows.Forms.CheckBox();
            this.openFileDialogTileSet = new System.Windows.Forms.OpenFileDialog();
            this.timerUpdate = new System.Windows.Forms.Timer(this.components);
            this.menuStripMain.SuspendLayout();
            this.toolStripMain.SuspendLayout();
            this.panelTileSetViwer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTileSetViewer)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMapViewer)).BeginInit();
            this.gbTilest.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(1016, 24);
            this.menuStripMain.TabIndex = 0;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.S)));
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // toolStripMain
            // 
            this.toolStripMain.AutoSize = false;
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonNew,
            this.toolStripButtonOpen,
            this.toolStripButtonSave,
            this.toolStripButtonExport,
            this.toolStripButtonUndo,
            this.toolStripButtonRedo,
            this.toolStripButtonShowGrid,
            this.toolStripButtonCut,
            this.toolStripButtonCopy,
            this.toolStripButtonPaste,
            this.toolStripButtonSelect,
            this.toolStripButtonErase,
            this.toolStripButtonFlipX,
            this.toolStripButtonFlipY,
            this.toolStripButtonRotateCW,
            this.toolStripButtonRotateCCW});
            this.toolStripMain.Location = new System.Drawing.Point(0, 24);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(1016, 42);
            this.toolStripMain.TabIndex = 1;
            this.toolStripMain.Text = "Undo";
            // 
            // toolStripButtonNew
            // 
            this.toolStripButtonNew.AutoSize = false;
            this.toolStripButtonNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonNew.Image = global::TileMapEditor.Properties.Resources._new;
            this.toolStripButtonNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonNew.Name = "toolStripButtonNew";
            this.toolStripButtonNew.Size = new System.Drawing.Size(32, 32);
            this.toolStripButtonNew.Text = "New";
            this.toolStripButtonNew.Click += new System.EventHandler(this.toolStripButtonNew_Click);
            // 
            // toolStripButtonOpen
            // 
            this.toolStripButtonOpen.AutoSize = false;
            this.toolStripButtonOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonOpen.Image = global::TileMapEditor.Properties.Resources.open;
            this.toolStripButtonOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOpen.Name = "toolStripButtonOpen";
            this.toolStripButtonOpen.Size = new System.Drawing.Size(32, 32);
            this.toolStripButtonOpen.Text = "Open";
            // 
            // toolStripButtonSave
            // 
            this.toolStripButtonSave.AutoSize = false;
            this.toolStripButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSave.Image = global::TileMapEditor.Properties.Resources.save;
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(32, 32);
            this.toolStripButtonSave.Text = "Save";
            // 
            // toolStripButtonExport
            // 
            this.toolStripButtonExport.AutoSize = false;
            this.toolStripButtonExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonExport.Image = global::TileMapEditor.Properties.Resources.export;
            this.toolStripButtonExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonExport.Name = "toolStripButtonExport";
            this.toolStripButtonExport.Size = new System.Drawing.Size(32, 32);
            this.toolStripButtonExport.Text = "Export";
            // 
            // toolStripButtonUndo
            // 
            this.toolStripButtonUndo.AutoSize = false;
            this.toolStripButtonUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonUndo.Image = global::TileMapEditor.Properties.Resources.undo;
            this.toolStripButtonUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonUndo.Name = "toolStripButtonUndo";
            this.toolStripButtonUndo.Size = new System.Drawing.Size(32, 32);
            this.toolStripButtonUndo.Text = "Undo";
            // 
            // toolStripButtonRedo
            // 
            this.toolStripButtonRedo.AutoSize = false;
            this.toolStripButtonRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRedo.Image = global::TileMapEditor.Properties.Resources.redo;
            this.toolStripButtonRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRedo.Name = "toolStripButtonRedo";
            this.toolStripButtonRedo.Size = new System.Drawing.Size(32, 32);
            this.toolStripButtonRedo.Text = "Redo";
            // 
            // toolStripButtonShowGrid
            // 
            this.toolStripButtonShowGrid.AutoSize = false;
            this.toolStripButtonShowGrid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonShowGrid.Image = global::TileMapEditor.Properties.Resources.grid;
            this.toolStripButtonShowGrid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonShowGrid.Name = "toolStripButtonShowGrid";
            this.toolStripButtonShowGrid.Size = new System.Drawing.Size(32, 32);
            this.toolStripButtonShowGrid.Text = "Show Grid";
            // 
            // toolStripButtonCut
            // 
            this.toolStripButtonCut.AutoSize = false;
            this.toolStripButtonCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCut.Image = global::TileMapEditor.Properties.Resources.cut;
            this.toolStripButtonCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCut.Name = "toolStripButtonCut";
            this.toolStripButtonCut.Size = new System.Drawing.Size(32, 32);
            this.toolStripButtonCut.Text = "Cut";
            // 
            // toolStripButtonCopy
            // 
            this.toolStripButtonCopy.AutoSize = false;
            this.toolStripButtonCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCopy.Image = global::TileMapEditor.Properties.Resources.copy;
            this.toolStripButtonCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCopy.Name = "toolStripButtonCopy";
            this.toolStripButtonCopy.Size = new System.Drawing.Size(32, 32);
            this.toolStripButtonCopy.Text = "Copy";
            // 
            // toolStripButtonPaste
            // 
            this.toolStripButtonPaste.AutoSize = false;
            this.toolStripButtonPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonPaste.Image = global::TileMapEditor.Properties.Resources.paste;
            this.toolStripButtonPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPaste.Name = "toolStripButtonPaste";
            this.toolStripButtonPaste.Size = new System.Drawing.Size(32, 32);
            this.toolStripButtonPaste.Text = "Paste";
            // 
            // toolStripButtonSelect
            // 
            this.toolStripButtonSelect.AutoSize = false;
            this.toolStripButtonSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSelect.Image = global::TileMapEditor.Properties.Resources.select;
            this.toolStripButtonSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSelect.Name = "toolStripButtonSelect";
            this.toolStripButtonSelect.Size = new System.Drawing.Size(32, 32);
            this.toolStripButtonSelect.Text = "Select";
            // 
            // toolStripButtonErase
            // 
            this.toolStripButtonErase.AutoSize = false;
            this.toolStripButtonErase.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonErase.Image = global::TileMapEditor.Properties.Resources.erase;
            this.toolStripButtonErase.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonErase.Name = "toolStripButtonErase";
            this.toolStripButtonErase.Size = new System.Drawing.Size(32, 32);
            this.toolStripButtonErase.Text = "Erase";
            // 
            // toolStripButtonFlipX
            // 
            this.toolStripButtonFlipX.AutoSize = false;
            this.toolStripButtonFlipX.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonFlipX.Image = global::TileMapEditor.Properties.Resources.flipHorizontal;
            this.toolStripButtonFlipX.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFlipX.Name = "toolStripButtonFlipX";
            this.toolStripButtonFlipX.Size = new System.Drawing.Size(32, 32);
            this.toolStripButtonFlipX.Text = "Flip Horizondal";
            // 
            // toolStripButtonFlipY
            // 
            this.toolStripButtonFlipY.AutoSize = false;
            this.toolStripButtonFlipY.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonFlipY.Image = global::TileMapEditor.Properties.Resources.flipVertical;
            this.toolStripButtonFlipY.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFlipY.Name = "toolStripButtonFlipY";
            this.toolStripButtonFlipY.Size = new System.Drawing.Size(32, 32);
            this.toolStripButtonFlipY.Text = "Flip Vertical";
            // 
            // toolStripButtonRotateCW
            // 
            this.toolStripButtonRotateCW.AutoSize = false;
            this.toolStripButtonRotateCW.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRotateCW.Image = global::TileMapEditor.Properties.Resources.rotate_cw;
            this.toolStripButtonRotateCW.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRotateCW.Name = "toolStripButtonRotateCW";
            this.toolStripButtonRotateCW.Size = new System.Drawing.Size(32, 32);
            this.toolStripButtonRotateCW.Text = "Rotate Clockwise";
            // 
            // toolStripButtonRotateCCW
            // 
            this.toolStripButtonRotateCCW.AutoSize = false;
            this.toolStripButtonRotateCCW.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRotateCCW.Image = global::TileMapEditor.Properties.Resources.rotate_ccw;
            this.toolStripButtonRotateCCW.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRotateCCW.Name = "toolStripButtonRotateCCW";
            this.toolStripButtonRotateCCW.Size = new System.Drawing.Size(32, 32);
            this.toolStripButtonRotateCCW.Text = "Rotate Counter Clockwise";
            // 
            // openFileDialogMap
            // 
            this.openFileDialogMap.FileName = "openFileDialog1";
            this.openFileDialogMap.Filter = "(*.mtm)|*.mtm";
            // 
            // panelTileSetViwer
            // 
            this.panelTileSetViwer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTileSetViwer.AutoScroll = true;
            this.panelTileSetViwer.Controls.Add(this.pictureBoxTileSetViewer);
            this.panelTileSetViwer.Location = new System.Drawing.Point(715, 77);
            this.panelTileSetViwer.Name = "panelTileSetViwer";
            this.panelTileSetViwer.Size = new System.Drawing.Size(289, 418);
            this.panelTileSetViwer.TabIndex = 3;
            // 
            // pictureBoxTileSetViewer
            // 
            this.pictureBoxTileSetViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxTileSetViewer.Location = new System.Drawing.Point(14, 3);
            this.pictureBoxTileSetViewer.Name = "pictureBoxTileSetViewer";
            this.pictureBoxTileSetViewer.Size = new System.Drawing.Size(256, 400);
            this.pictureBoxTileSetViewer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxTileSetViewer.TabIndex = 0;
            this.pictureBoxTileSetViewer.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBoxMapViewer);
            this.panel1.Location = new System.Drawing.Point(12, 77);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(697, 677);
            this.panel1.TabIndex = 4;
            // 
            // pictureBoxMapViewer
            // 
            this.pictureBoxMapViewer.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxMapViewer.Name = "pictureBoxMapViewer";
            this.pictureBoxMapViewer.Size = new System.Drawing.Size(679, 660);
            this.pictureBoxMapViewer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxMapViewer.TabIndex = 0;
            this.pictureBoxMapViewer.TabStop = false;
            // 
            // gbTilest
            // 
            this.gbTilest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.gbTilest.Controls.Add(this.label6);
            this.gbTilest.Controls.Add(this.buttonBrowseTileSet);
            this.gbTilest.Controls.Add(this.textBoxTileSetName);
            this.gbTilest.Controls.Add(this.labelMapSize);
            this.gbTilest.Controls.Add(this.label4);
            this.gbTilest.Controls.Add(this.label3);
            this.gbTilest.Controls.Add(this.label2);
            this.gbTilest.Controls.Add(this.label1);
            this.gbTilest.Controls.Add(this.textBoxMapHeight);
            this.gbTilest.Controls.Add(this.textBoxMapWidth);
            this.gbTilest.Controls.Add(this.textBoxTileHeight);
            this.gbTilest.Controls.Add(this.textBoxTileWidth);
            this.gbTilest.Location = new System.Drawing.Point(715, 524);
            this.gbTilest.Name = "gbTilest";
            this.gbTilest.Size = new System.Drawing.Size(289, 230);
            this.gbTilest.TabIndex = 5;
            this.gbTilest.TabStop = false;
            this.gbTilest.Text = "Map Info.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Browse Tile Set :";
            // 
            // buttonBrowseTileSet
            // 
            this.buttonBrowseTileSet.Location = new System.Drawing.Point(236, 42);
            this.buttonBrowseTileSet.Name = "buttonBrowseTileSet";
            this.buttonBrowseTileSet.Size = new System.Drawing.Size(38, 23);
            this.buttonBrowseTileSet.TabIndex = 10;
            this.buttonBrowseTileSet.Text = "...";
            this.buttonBrowseTileSet.UseVisualStyleBackColor = true;
            this.buttonBrowseTileSet.Click += new System.EventHandler(this.buttonBrowseTileSet_Click);
            // 
            // textBoxTileSetName
            // 
            this.textBoxTileSetName.Location = new System.Drawing.Point(14, 42);
            this.textBoxTileSetName.Name = "textBoxTileSetName";
            this.textBoxTileSetName.Size = new System.Drawing.Size(216, 20);
            this.textBoxTileSetName.TabIndex = 9;
            // 
            // labelMapSize
            // 
            this.labelMapSize.AutoSize = true;
            this.labelMapSize.Location = new System.Drawing.Point(54, 187);
            this.labelMapSize.Name = "labelMapSize";
            this.labelMapSize.Size = new System.Drawing.Size(60, 13);
            this.labelMapSize.TabIndex = 8;
            this.labelMapSize.Text = "Map Size : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(157, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Map Height [in Tiles]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Map Width [in Tiles]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(157, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tile Height [in Pixels]";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tile Width [in Pixels]";
            // 
            // textBoxMapHeight
            // 
            this.textBoxMapHeight.Location = new System.Drawing.Point(160, 144);
            this.textBoxMapHeight.Name = "textBoxMapHeight";
            this.textBoxMapHeight.Size = new System.Drawing.Size(100, 20);
            this.textBoxMapHeight.TabIndex = 3;
            // 
            // textBoxMapWidth
            // 
            this.textBoxMapWidth.Location = new System.Drawing.Point(14, 144);
            this.textBoxMapWidth.Name = "textBoxMapWidth";
            this.textBoxMapWidth.Size = new System.Drawing.Size(100, 20);
            this.textBoxMapWidth.TabIndex = 2;
            // 
            // textBoxTileHeight
            // 
            this.textBoxTileHeight.Location = new System.Drawing.Point(160, 93);
            this.textBoxTileHeight.Name = "textBoxTileHeight";
            this.textBoxTileHeight.Size = new System.Drawing.Size(100, 20);
            this.textBoxTileHeight.TabIndex = 1;
            // 
            // textBoxTileWidth
            // 
            this.textBoxTileWidth.Location = new System.Drawing.Point(14, 93);
            this.textBoxTileWidth.Name = "textBoxTileWidth";
            this.textBoxTileWidth.Size = new System.Drawing.Size(100, 20);
            this.textBoxTileWidth.TabIndex = 0;
            this.textBoxTileWidth.TextChanged += new System.EventHandler(this.textBoxTileWidth_TextChanged);
            // 
            // checkBoxShowGrid
            // 
            this.checkBoxShowGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxShowGrid.AutoSize = true;
            this.checkBoxShowGrid.Location = new System.Drawing.Point(817, 501);
            this.checkBoxShowGrid.Name = "checkBoxShowGrid";
            this.checkBoxShowGrid.Size = new System.Drawing.Size(75, 17);
            this.checkBoxShowGrid.TabIndex = 6;
            this.checkBoxShowGrid.Text = "Show Grid";
            this.checkBoxShowGrid.UseVisualStyleBackColor = true;
            // 
            // openFileDialogTileSet
            // 
            this.openFileDialogTileSet.FileName = "openFileDialog1";
            this.openFileDialogTileSet.Filter = "(*.BMP;*.PNG;*.TGA)|*.BMP;*.PNG;*.TGA";
            // 
            // timerUpdate
            // 
            this.timerUpdate.Interval = 33;
            this.timerUpdate.Tick += new System.EventHandler(this.timerUpdate_Tick);
            // 
            // frmTielMapEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 766);
            this.Controls.Add(this.checkBoxShowGrid);
            this.Controls.Add(this.gbTilest);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelTileSetViwer);
            this.Controls.Add(this.toolStripMain);
            this.Controls.Add(this.menuStripMain);
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "frmTielMapEditor";
            this.Text = "Tile Map Editor";
            this.Load += new System.EventHandler(this.frmTielMapEditor_Load);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.panelTileSetViwer.ResumeLayout(false);
            this.panelTileSetViwer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTileSetViewer)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMapViewer)).EndInit();
            this.gbTilest.ResumeLayout(false);
            this.gbTilest.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripButton toolStripButtonNew;
        private System.Windows.Forms.ToolStripButton toolStripButtonOpen;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.ToolStripButton toolStripButtonExport;
        private System.Windows.Forms.ToolStripButton toolStripButtonUndo;
        private System.Windows.Forms.OpenFileDialog openFileDialogMap;
        private System.Windows.Forms.SaveFileDialog saveFileDialogMap;
        private System.Windows.Forms.ToolStripButton toolStripButtonRedo;
        private System.Windows.Forms.ToolStripButton toolStripButtonShowGrid;
        private System.Windows.Forms.Panel panelTileSetViwer;
        private System.Windows.Forms.PictureBox pictureBoxTileSetViewer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBoxMapViewer;
        private System.Windows.Forms.GroupBox gbTilest;
        private System.Windows.Forms.CheckBox checkBoxShowGrid;
        private System.Windows.Forms.Label labelMapSize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxMapHeight;
        private System.Windows.Forms.TextBox textBoxMapWidth;
        private System.Windows.Forms.TextBox textBoxTileHeight;
        private System.Windows.Forms.TextBox textBoxTileWidth;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonBrowseTileSet;
        private System.Windows.Forms.TextBox textBoxTileSetName;
        private System.Windows.Forms.ToolStripButton toolStripButtonCopy;
        private System.Windows.Forms.ToolStripButton toolStripButtonPaste;
        private System.Windows.Forms.ToolStripButton toolStripButtonSelect;
        private System.Windows.Forms.ToolStripButton toolStripButtonErase;
        private System.Windows.Forms.ToolStripButton toolStripButtonCut;
        private System.Windows.Forms.ToolStripButton toolStripButtonFlipX;
        private System.Windows.Forms.ToolStripButton toolStripButtonFlipY;
        private System.Windows.Forms.ToolStripButton toolStripButtonRotateCW;
        private System.Windows.Forms.ToolStripButton toolStripButtonRotateCCW;
        private System.Windows.Forms.OpenFileDialog openFileDialogTileSet;
        private System.Windows.Forms.Timer timerUpdate;
    }
}

