namespace GameEditor
{
    partial class Form1
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
            this.mnsp = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.pbViewer = new System.Windows.Forms.PictureBox();
            this.timerUpdate = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblMouseY = new System.Windows.Forms.Label();
            this.lblMouseX = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlMaskColor = new System.Windows.Forms.Panel();
            this.pnlViewerBgColor = new System.Windows.Forms.Panel();
            this.chkboxShowModule = new System.Windows.Forms.CheckBox();
            this.chkboxShowGrid = new System.Windows.Forms.CheckBox();
            this.clrDlg = new System.Windows.Forms.ColorDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblImageBpp = new System.Windows.Forms.Label();
            this.lblImageDpi = new System.Windows.Forms.Label();
            this.lblImageHeight = new System.Windows.Forms.Label();
            this.lblImageWidth = new System.Windows.Forms.Label();
            this.btnImageLoad = new System.Windows.Forms.Button();
            this.txtboxImageName = new System.Windows.Forms.TextBox();
            this.openFileDialogImage = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabModule = new System.Windows.Forms.TabPage();
            this.dgViewModule = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.X = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Width = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Height = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabFrame = new System.Windows.Forms.TabPage();
            this.tabAnimation = new System.Windows.Forms.TabPage();
            this.tabMap = new System.Windows.Forms.TabPage();
            this.mnsp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbViewer)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabModule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewModule)).BeginInit();
            this.SuspendLayout();
            // 
            // mnsp
            // 
            this.mnsp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.mnsp.Location = new System.Drawing.Point(0, 0);
            this.mnsp.Name = "mnsp";
            this.mnsp.Size = new System.Drawing.Size(1144, 24);
            this.mnsp.TabIndex = 0;
            this.mnsp.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.closeToolStripMenuItem.Text = "Exit";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1144, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // pbViewer
            // 
            this.pbViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbViewer.Location = new System.Drawing.Point(6, 55);
            this.pbViewer.Name = "pbViewer";
            this.pbViewer.Size = new System.Drawing.Size(600, 480);
            this.pbViewer.TabIndex = 2;
            this.pbViewer.TabStop = false;
            this.pbViewer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbViewer_MouseMove);
            this.pbViewer.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbViewer_MouseClick);
            this.pbViewer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbViewer_MouseDown);
            this.pbViewer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbViewer_MouseUp);
            // 
            // timerUpdate
            // 
            this.timerUpdate.Tick += new System.EventHandler(this.timerUpdate_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.lblMouseY);
            this.groupBox1.Controls.Add(this.lblMouseX);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.pnlMaskColor);
            this.groupBox1.Controls.Add(this.pnlViewerBgColor);
            this.groupBox1.Controls.Add(this.chkboxShowModule);
            this.groupBox1.Controls.Add(this.chkboxShowGrid);
            this.groupBox1.ForeColor = System.Drawing.Color.DarkBlue;
            this.groupBox1.Location = new System.Drawing.Point(10, 540);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(596, 81);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Viewer Settings";
            // 
            // lblMouseY
            // 
            this.lblMouseY.AutoSize = true;
            this.lblMouseY.Location = new System.Drawing.Point(361, 44);
            this.lblMouseY.Name = "lblMouseY";
            this.lblMouseY.Size = new System.Drawing.Size(58, 13);
            this.lblMouseY.TabIndex = 7;
            this.lblMouseY.Text = "Mouse Y : ";
            // 
            // lblMouseX
            // 
            this.lblMouseX.AutoSize = true;
            this.lblMouseX.Location = new System.Drawing.Point(361, 24);
            this.lblMouseX.Name = "lblMouseX";
            this.lblMouseX.Size = new System.Drawing.Size(58, 13);
            this.lblMouseX.TabIndex = 6;
            this.lblMouseX.Text = "Mouse X : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(227, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Mask Color";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(227, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "BG Color";
            // 
            // pnlMaskColor
            // 
            this.pnlMaskColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlMaskColor.Location = new System.Drawing.Point(205, 45);
            this.pnlMaskColor.Name = "pnlMaskColor";
            this.pnlMaskColor.Size = new System.Drawing.Size(16, 17);
            this.pnlMaskColor.TabIndex = 4;
            // 
            // pnlViewerBgColor
            // 
            this.pnlViewerBgColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlViewerBgColor.Location = new System.Drawing.Point(205, 22);
            this.pnlViewerBgColor.Name = "pnlViewerBgColor";
            this.pnlViewerBgColor.Size = new System.Drawing.Size(16, 17);
            this.pnlViewerBgColor.TabIndex = 2;
            this.pnlViewerBgColor.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnlViewerBgColor_MouseClick);
            // 
            // chkboxShowModule
            // 
            this.chkboxShowModule.AutoSize = true;
            this.chkboxShowModule.Location = new System.Drawing.Point(15, 42);
            this.chkboxShowModule.Name = "chkboxShowModule";
            this.chkboxShowModule.Size = new System.Drawing.Size(91, 17);
            this.chkboxShowModule.TabIndex = 1;
            this.chkboxShowModule.Text = "Show Module";
            this.chkboxShowModule.UseVisualStyleBackColor = true;
            // 
            // chkboxShowGrid
            // 
            this.chkboxShowGrid.AutoSize = true;
            this.chkboxShowGrid.Location = new System.Drawing.Point(15, 19);
            this.chkboxShowGrid.Name = "chkboxShowGrid";
            this.chkboxShowGrid.Size = new System.Drawing.Size(75, 17);
            this.chkboxShowGrid.TabIndex = 0;
            this.chkboxShowGrid.Text = "Show Grid";
            this.chkboxShowGrid.UseVisualStyleBackColor = true;
            // 
            // clrDlg
            // 
            this.clrDlg.Color = System.Drawing.Color.White;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lblImageBpp);
            this.groupBox2.Controls.Add(this.lblImageDpi);
            this.groupBox2.Controls.Add(this.lblImageHeight);
            this.groupBox2.Controls.Add(this.lblImageWidth);
            this.groupBox2.Controls.Add(this.btnImageLoad);
            this.groupBox2.Controls.Add(this.txtboxImageName);
            this.groupBox2.ForeColor = System.Drawing.Color.DarkBlue;
            this.groupBox2.Location = new System.Drawing.Point(10, 627);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(594, 73);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Load Image";
            // 
            // lblImageBpp
            // 
            this.lblImageBpp.AutoSize = true;
            this.lblImageBpp.Location = new System.Drawing.Point(290, 57);
            this.lblImageBpp.Name = "lblImageBpp";
            this.lblImageBpp.Size = new System.Drawing.Size(35, 13);
            this.lblImageBpp.TabIndex = 5;
            this.lblImageBpp.Text = "Bpp : ";
            // 
            // lblImageDpi
            // 
            this.lblImageDpi.AutoSize = true;
            this.lblImageDpi.Location = new System.Drawing.Point(416, 57);
            this.lblImageDpi.Name = "lblImageDpi";
            this.lblImageDpi.Size = new System.Drawing.Size(32, 13);
            this.lblImageDpi.TabIndex = 4;
            this.lblImageDpi.Text = "Dpi : ";
            // 
            // lblImageHeight
            // 
            this.lblImageHeight.AutoSize = true;
            this.lblImageHeight.Location = new System.Drawing.Point(152, 57);
            this.lblImageHeight.Name = "lblImageHeight";
            this.lblImageHeight.Size = new System.Drawing.Size(47, 13);
            this.lblImageHeight.TabIndex = 3;
            this.lblImageHeight.Text = "Height : ";
            // 
            // lblImageWidth
            // 
            this.lblImageWidth.AutoSize = true;
            this.lblImageWidth.Location = new System.Drawing.Point(17, 57);
            this.lblImageWidth.Name = "lblImageWidth";
            this.lblImageWidth.Size = new System.Drawing.Size(44, 13);
            this.lblImageWidth.TabIndex = 2;
            this.lblImageWidth.Text = "Width : ";
            // 
            // btnImageLoad
            // 
            this.btnImageLoad.Location = new System.Drawing.Point(513, 21);
            this.btnImageLoad.Name = "btnImageLoad";
            this.btnImageLoad.Size = new System.Drawing.Size(75, 23);
            this.btnImageLoad.TabIndex = 1;
            this.btnImageLoad.Text = "Load";
            this.btnImageLoad.UseVisualStyleBackColor = true;
            this.btnImageLoad.Click += new System.EventHandler(this.btnImageLoad_Click);
            // 
            // txtboxImageName
            // 
            this.txtboxImageName.Location = new System.Drawing.Point(14, 21);
            this.txtboxImageName.Name = "txtboxImageName";
            this.txtboxImageName.Size = new System.Drawing.Size(484, 20);
            this.txtboxImageName.TabIndex = 0;
            // 
            // openFileDialogImage
            // 
            this.openFileDialogImage.FileName = "openFileDialog1";
            this.openFileDialogImage.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialogImage_FileOk);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabModule);
            this.tabControl1.Controls.Add(this.tabFrame);
            this.tabControl1.Controls.Add(this.tabAnimation);
            this.tabControl1.Controls.Add(this.tabMap);
            this.tabControl1.Location = new System.Drawing.Point(622, 55);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(510, 645);
            this.tabControl1.TabIndex = 6;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabModule
            // 
            this.tabModule.Controls.Add(this.dgViewModule);
            this.tabModule.Location = new System.Drawing.Point(4, 22);
            this.tabModule.Name = "tabModule";
            this.tabModule.Padding = new System.Windows.Forms.Padding(3);
            this.tabModule.Size = new System.Drawing.Size(502, 619);
            this.tabModule.TabIndex = 0;
            this.tabModule.Text = "Module";
            this.tabModule.UseVisualStyleBackColor = true;
            // 
            // dgViewModule
            // 
            this.dgViewModule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgViewModule.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.X,
            this.Y,
            this.Width,
            this.Height,
            this.Desc});
            this.dgViewModule.Location = new System.Drawing.Point(5, 7);
            this.dgViewModule.Name = "dgViewModule";
            this.dgViewModule.Size = new System.Drawing.Size(491, 537);
            this.dgViewModule.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Width = 50;
            // 
            // X
            // 
            this.X.HeaderText = "X";
            this.X.Name = "X";
            this.X.Width = 50;
            // 
            // Y
            // 
            this.Y.HeaderText = "Y";
            this.Y.Name = "Y";
            this.Y.Width = 50;
            // 
            // Width
            // 
            this.Width.HeaderText = "Width";
            this.Width.Name = "Width";
            this.Width.Width = 50;
            // 
            // Height
            // 
            this.Height.HeaderText = "Height";
            this.Height.Name = "Height";
            this.Height.Width = 50;
            // 
            // Desc
            // 
            this.Desc.HeaderText = "Desc.";
            this.Desc.Name = "Desc";
            this.Desc.Width = 198;
            // 
            // tabFrame
            // 
            this.tabFrame.Location = new System.Drawing.Point(4, 22);
            this.tabFrame.Name = "tabFrame";
            this.tabFrame.Padding = new System.Windows.Forms.Padding(3);
            this.tabFrame.Size = new System.Drawing.Size(502, 619);
            this.tabFrame.TabIndex = 1;
            this.tabFrame.Text = "Frame";
            this.tabFrame.UseVisualStyleBackColor = true;
            // 
            // tabAnimation
            // 
            this.tabAnimation.Location = new System.Drawing.Point(4, 22);
            this.tabAnimation.Name = "tabAnimation";
            this.tabAnimation.Size = new System.Drawing.Size(502, 619);
            this.tabAnimation.TabIndex = 2;
            this.tabAnimation.Text = "Animation";
            this.tabAnimation.UseVisualStyleBackColor = true;
            // 
            // tabMap
            // 
            this.tabMap.Location = new System.Drawing.Point(4, 22);
            this.tabMap.Name = "tabMap";
            this.tabMap.Size = new System.Drawing.Size(502, 619);
            this.tabMap.TabIndex = 3;
            this.tabMap.Text = "Map";
            this.tabMap.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 830);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pbViewer);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.mnsp);
            this.MainMenuStrip = this.mnsp;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.mnsp.ResumeLayout(false);
            this.mnsp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbViewer)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabModule.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgViewModule)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnsp;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.PictureBox pbViewer;
        private System.Windows.Forms.Timer timerUpdate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkboxShowModule;
        private System.Windows.Forms.CheckBox chkboxShowGrid;
        private System.Windows.Forms.Panel pnlViewerBgColor;
        private System.Windows.Forms.ColorDialog clrDlg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlMaskColor;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtboxImageName;
        private System.Windows.Forms.Button btnImageLoad;
        private System.Windows.Forms.Label lblMouseY;
        private System.Windows.Forms.Label lblMouseX;
        private System.Windows.Forms.Label lblImageBpp;
        private System.Windows.Forms.Label lblImageDpi;
        private System.Windows.Forms.Label lblImageHeight;
        private System.Windows.Forms.Label lblImageWidth;
        private System.Windows.Forms.OpenFileDialog openFileDialogImage;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabModule;
        private System.Windows.Forms.TabPage tabFrame;
        private System.Windows.Forms.TabPage tabAnimation;
        private System.Windows.Forms.TabPage tabMap;
        private System.Windows.Forms.DataGridView dgViewModule;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn X;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y;
        private System.Windows.Forms.DataGridViewTextBoxColumn Width;
        private System.Windows.Forms.DataGridViewTextBoxColumn Height;
        private System.Windows.Forms.DataGridViewTextBoxColumn Desc;
    }
}

