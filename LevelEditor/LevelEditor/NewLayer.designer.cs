namespace NewLayer
{
    partial class frmNewLayer
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
            this.comboBoxLayerType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbNbHTiles = new System.Windows.Forms.TextBox();
            this.lblMapSize = new System.Windows.Forms.Label();
            this.tbNbVTiles = new System.Windows.Forms.TextBox();
            this.tbTileWidth = new System.Windows.Forms.TextBox();
            this.tbTileHeight = new System.Windows.Forms.TextBox();
            this.gbLayer = new System.Windows.Forms.GroupBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbLayerName = new System.Windows.Forms.TextBox();
            this.gbLayer.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxLayerType
            // 
            this.comboBoxLayerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLayerType.FormattingEnabled = true;
            this.comboBoxLayerType.Items.AddRange(new object[] {
            "TILE LAYER",
            "OBJECT LAYER"});
            this.comboBoxLayerType.Location = new System.Drawing.Point(47, 12);
            this.comboBoxLayerType.Name = "comboBoxLayerType";
            this.comboBoxLayerType.Size = new System.Drawing.Size(374, 21);
            this.comboBoxLayerType.TabIndex = 0;
            this.comboBoxLayerType.SelectedIndexChanged += new System.EventHandler(this.comboBoxLayerType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nb. Of Horizontal Tiles";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nb. Of Vertical Tiles";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(259, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tile Width";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(259, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Tile Height";
            // 
            // tbNbHTiles
            // 
            this.tbNbHTiles.Location = new System.Drawing.Point(144, 48);
            this.tbNbHTiles.Name = "tbNbHTiles";
            this.tbNbHTiles.Size = new System.Drawing.Size(100, 20);
            this.tbNbHTiles.TabIndex = 5;
            this.tbNbHTiles.TextChanged += new System.EventHandler(this.tbNbHTiles_TextChanged);
            // 
            // lblMapSize
            // 
            this.lblMapSize.AutoSize = true;
            this.lblMapSize.Location = new System.Drawing.Point(141, 152);
            this.lblMapSize.Name = "lblMapSize";
            this.lblMapSize.Size = new System.Drawing.Size(60, 13);
            this.lblMapSize.TabIndex = 6;
            this.lblMapSize.Text = "Map Size : ";
            // 
            // tbNbVTiles
            // 
            this.tbNbVTiles.Location = new System.Drawing.Point(144, 110);
            this.tbNbVTiles.Name = "tbNbVTiles";
            this.tbNbVTiles.Size = new System.Drawing.Size(100, 20);
            this.tbNbVTiles.TabIndex = 7;
            // 
            // tbTileWidth
            // 
            this.tbTileWidth.Location = new System.Drawing.Point(329, 48);
            this.tbTileWidth.Name = "tbTileWidth";
            this.tbTileWidth.Size = new System.Drawing.Size(100, 20);
            this.tbTileWidth.TabIndex = 8;
            // 
            // tbTileHeight
            // 
            this.tbTileHeight.Location = new System.Drawing.Point(329, 110);
            this.tbTileHeight.Name = "tbTileHeight";
            this.tbTileHeight.Size = new System.Drawing.Size(100, 20);
            this.tbTileHeight.TabIndex = 9;
            // 
            // gbLayer
            // 
            this.gbLayer.Controls.Add(this.tbTileWidth);
            this.gbLayer.Controls.Add(this.tbTileHeight);
            this.gbLayer.Controls.Add(this.tbNbVTiles);
            this.gbLayer.Controls.Add(this.lblMapSize);
            this.gbLayer.Controls.Add(this.tbNbHTiles);
            this.gbLayer.Controls.Add(this.label4);
            this.gbLayer.Controls.Add(this.label3);
            this.gbLayer.Controls.Add(this.label2);
            this.gbLayer.Controls.Add(this.label1);
            this.gbLayer.Location = new System.Drawing.Point(12, 71);
            this.gbLayer.Name = "gbLayer";
            this.gbLayer.Size = new System.Drawing.Size(443, 168);
            this.gbLayer.TabIndex = 10;
            this.gbLayer.TabStop = false;
            this.gbLayer.Text = "Layer Properties";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(97, 253);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(274, 253);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tbLayerName
            // 
            this.tbLayerName.Location = new System.Drawing.Point(47, 45);
            this.tbLayerName.Name = "tbLayerName";
            this.tbLayerName.Size = new System.Drawing.Size(374, 20);
            this.tbLayerName.TabIndex = 13;
            // 
            // frmNewLayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 288);
            this.Controls.Add(this.tbLayerName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gbLayer);
            this.Controls.Add(this.comboBoxLayerType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNewLayer";
            this.Text = "New Layer";
            this.Load += new System.EventHandler(this.frmNewLayer_Load);
            this.gbLayer.ResumeLayout(false);
            this.gbLayer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxLayerType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbNbHTiles;
        private System.Windows.Forms.Label lblMapSize;
        private System.Windows.Forms.TextBox tbNbVTiles;
        private System.Windows.Forms.TextBox tbTileWidth;
        private System.Windows.Forms.TextBox tbTileHeight;
        private System.Windows.Forms.GroupBox gbLayer;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tbLayerName;
    }
}

