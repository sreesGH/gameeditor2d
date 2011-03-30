namespace TextEditor
{
    partial class frmTextEditor
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
            this.toolStripTextEditor = new System.Windows.Forms.ToolStrip();
            this.menuStripTextEditor = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewTextEditor = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Language1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.saveFileDialogExport = new System.Windows.Forms.SaveFileDialog();
            this.toolStripButtonAddLanguage = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCopy = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonPaste = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonExport = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonUndo = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRedo = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonInsert = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonchangecase = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonShowFontDialog = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonTranslate = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCreateSprite = new System.Windows.Forms.ToolStripButton();
            this.toolStripTextEditor.SuspendLayout();
            this.menuStripTextEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTextEditor)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripTextEditor
            // 
            this.toolStripTextEditor.AutoSize = false;
            this.toolStripTextEditor.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAddLanguage,
            this.toolStripButtonCopy,
            this.toolStripButtonPaste,
            this.toolStripButtonExport,
            this.toolStripButtonUndo,
            this.toolStripButtonRedo,
            this.toolStripButtonInsert,
            this.toolStripButtonchangecase,
            this.toolStripButtonShowFontDialog,
            this.toolStripButtonTranslate,
            this.toolStripButtonCreateSprite});
            this.toolStripTextEditor.Location = new System.Drawing.Point(0, 24);
            this.toolStripTextEditor.Name = "toolStripTextEditor";
            this.toolStripTextEditor.Size = new System.Drawing.Size(792, 32);
            this.toolStripTextEditor.TabIndex = 0;
            this.toolStripTextEditor.Text = "toolStrip1";
            // 
            // menuStripTextEditor
            // 
            this.menuStripTextEditor.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStripTextEditor.Location = new System.Drawing.Point(0, 0);
            this.menuStripTextEditor.Name = "menuStripTextEditor";
            this.menuStripTextEditor.Size = new System.Drawing.Size(792, 24);
            this.menuStripTextEditor.TabIndex = 1;
            this.menuStripTextEditor.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.saveAsToolStripMenuItem.Text = "Save as";
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // dataGridViewTextEditor
            // 
            this.dataGridViewTextEditor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTextEditor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Language1});
            this.dataGridViewTextEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTextEditor.Location = new System.Drawing.Point(0, 56);
            this.dataGridViewTextEditor.Name = "dataGridViewTextEditor";
            this.dataGridViewTextEditor.Size = new System.Drawing.Size(792, 390);
            this.dataGridViewTextEditor.TabIndex = 2;
            this.dataGridViewTextEditor.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTextEditor_CellEndEdit);
            // 
            // ID
            // 
            this.ID.HeaderText = "Text ID";
            this.ID.Name = "ID";
            // 
            // Language1
            // 
            this.Language1.HeaderText = "Language 1";
            this.Language1.Name = "Language1";
            // 
            // fontDialog1
            // 
            this.fontDialog1.ShowColor = true;
            // 
            // saveFileDialogExport
            // 
            this.saveFileDialogExport.Filter = "(*.btxt)|*.btxt";
            // 
            // toolStripButtonAddLanguage
            // 
            this.toolStripButtonAddLanguage.AutoSize = false;
            this.toolStripButtonAddLanguage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAddLanguage.Image = global::TextEditor.Properties.Resources.add;
            this.toolStripButtonAddLanguage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddLanguage.Name = "toolStripButtonAddLanguage";
            this.toolStripButtonAddLanguage.Size = new System.Drawing.Size(32, 32);
            this.toolStripButtonAddLanguage.Text = "Add Language";
            this.toolStripButtonAddLanguage.Click += new System.EventHandler(this.toolStripButtonAddLanguage_Click);
            // 
            // toolStripButtonCopy
            // 
            this.toolStripButtonCopy.AutoSize = false;
            this.toolStripButtonCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCopy.Image = global::TextEditor.Properties.Resources.copy;
            this.toolStripButtonCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCopy.Name = "toolStripButtonCopy";
            this.toolStripButtonCopy.Size = new System.Drawing.Size(32, 32);
            this.toolStripButtonCopy.Text = "Copy";
            // 
            // toolStripButtonPaste
            // 
            this.toolStripButtonPaste.AutoSize = false;
            this.toolStripButtonPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonPaste.Image = global::TextEditor.Properties.Resources.paste;
            this.toolStripButtonPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPaste.Name = "toolStripButtonPaste";
            this.toolStripButtonPaste.Size = new System.Drawing.Size(32, 32);
            this.toolStripButtonPaste.Text = "Paste";
            // 
            // toolStripButtonExport
            // 
            this.toolStripButtonExport.AutoSize = false;
            this.toolStripButtonExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonExport.Image = global::TextEditor.Properties.Resources.export;
            this.toolStripButtonExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonExport.Name = "toolStripButtonExport";
            this.toolStripButtonExport.Size = new System.Drawing.Size(32, 32);
            this.toolStripButtonExport.Text = "Export";
            this.toolStripButtonExport.Click += new System.EventHandler(this.toolStripButtonExport_Click);
            // 
            // toolStripButtonUndo
            // 
            this.toolStripButtonUndo.AutoSize = false;
            this.toolStripButtonUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonUndo.Image = global::TextEditor.Properties.Resources.undo;
            this.toolStripButtonUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonUndo.Name = "toolStripButtonUndo";
            this.toolStripButtonUndo.Size = new System.Drawing.Size(32, 32);
            this.toolStripButtonUndo.Text = "Undo";
            this.toolStripButtonUndo.Click += new System.EventHandler(this.toolStripButtonUndo_Click);
            // 
            // toolStripButtonRedo
            // 
            this.toolStripButtonRedo.AutoSize = false;
            this.toolStripButtonRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRedo.Image = global::TextEditor.Properties.Resources.redo;
            this.toolStripButtonRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRedo.Name = "toolStripButtonRedo";
            this.toolStripButtonRedo.Size = new System.Drawing.Size(32, 32);
            this.toolStripButtonRedo.Text = "Redo";
            // 
            // toolStripButtonInsert
            // 
            this.toolStripButtonInsert.AutoSize = false;
            this.toolStripButtonInsert.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonInsert.Image = global::TextEditor.Properties.Resources.insert;
            this.toolStripButtonInsert.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonInsert.Name = "toolStripButtonInsert";
            this.toolStripButtonInsert.Size = new System.Drawing.Size(32, 32);
            this.toolStripButtonInsert.Text = "Insert";
            // 
            // toolStripButtonchangecase
            // 
            this.toolStripButtonchangecase.AutoSize = false;
            this.toolStripButtonchangecase.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonchangecase.Image = global::TextEditor.Properties.Resources._case;
            this.toolStripButtonchangecase.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonchangecase.Name = "toolStripButtonchangecase";
            this.toolStripButtonchangecase.Size = new System.Drawing.Size(32, 32);
            this.toolStripButtonchangecase.Text = "Change case";
            this.toolStripButtonchangecase.Click += new System.EventHandler(this.toolStripButtonchangecase_Click);
            // 
            // toolStripButtonShowFontDialog
            // 
            this.toolStripButtonShowFontDialog.AutoSize = false;
            this.toolStripButtonShowFontDialog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonShowFontDialog.Image = global::TextEditor.Properties.Resources.font;
            this.toolStripButtonShowFontDialog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonShowFontDialog.Name = "toolStripButtonShowFontDialog";
            this.toolStripButtonShowFontDialog.Size = new System.Drawing.Size(32, 32);
            this.toolStripButtonShowFontDialog.Text = "Select Font";
            this.toolStripButtonShowFontDialog.Click += new System.EventHandler(this.toolStripButtonShowFontDialog_Click);
            // 
            // toolStripButtonTranslate
            // 
            this.toolStripButtonTranslate.AutoSize = false;
            this.toolStripButtonTranslate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonTranslate.Image = global::TextEditor.Properties.Resources.translate;
            this.toolStripButtonTranslate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonTranslate.Name = "toolStripButtonTranslate";
            this.toolStripButtonTranslate.Size = new System.Drawing.Size(32, 32);
            this.toolStripButtonTranslate.Text = "Translate";
            this.toolStripButtonTranslate.Click += new System.EventHandler(this.toolStripButtonTranslate_Click);
            // 
            // toolStripButtonCreateSprite
            // 
            this.toolStripButtonCreateSprite.AutoSize = false;
            this.toolStripButtonCreateSprite.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCreateSprite.Image = global::TextEditor.Properties.Resources.sprite;
            this.toolStripButtonCreateSprite.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCreateSprite.Name = "toolStripButtonCreateSprite";
            this.toolStripButtonCreateSprite.Size = new System.Drawing.Size(32, 32);
            this.toolStripButtonCreateSprite.Text = "Create Sprite";
            this.toolStripButtonCreateSprite.Click += new System.EventHandler(this.toolStripButtonCreateSprite_Click);
            // 
            // frmTextEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 446);
            this.Controls.Add(this.dataGridViewTextEditor);
            this.Controls.Add(this.toolStripTextEditor);
            this.Controls.Add(this.menuStripTextEditor);
            this.MainMenuStrip = this.menuStripTextEditor;
            this.Name = "frmTextEditor";
            this.Text = "Text Editor";
            this.toolStripTextEditor.ResumeLayout(false);
            this.toolStripTextEditor.PerformLayout();
            this.menuStripTextEditor.ResumeLayout(false);
            this.menuStripTextEditor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTextEditor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripTextEditor;
        private System.Windows.Forms.MenuStrip menuStripTextEditor;
        private System.Windows.Forms.DataGridView dataGridViewTextEditor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Language1;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddLanguage;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonCopy;
        private System.Windows.Forms.ToolStripButton toolStripButtonPaste;
        private System.Windows.Forms.ToolStripButton toolStripButtonExport;
        private System.Windows.Forms.ToolStripButton toolStripButtonUndo;
        private System.Windows.Forms.ToolStripButton toolStripButtonRedo;
        private System.Windows.Forms.ToolStripButton toolStripButtonInsert;
        private System.Windows.Forms.ToolStripButton toolStripButtonShowFontDialog;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.ToolStripButton toolStripButtonchangecase;
        private System.Windows.Forms.ToolStripButton toolStripButtonTranslate;
        private System.Windows.Forms.SaveFileDialog saveFileDialogExport;
        private System.Windows.Forms.ToolStripButton toolStripButtonCreateSprite;
    }
}

