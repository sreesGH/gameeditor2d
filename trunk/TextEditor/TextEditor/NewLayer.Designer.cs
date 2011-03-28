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
            this.buttonConvert = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.textBoxKey = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonConvert
            // 
            this.buttonConvert.Location = new System.Drawing.Point(69, 122);
            this.buttonConvert.Name = "buttonConvert";
            this.buttonConvert.Size = new System.Drawing.Size(81, 23);
            this.buttonConvert.TabIndex = 0;
            this.buttonConvert.Text = "TRANSLATE";
            this.buttonConvert.UseVisualStyleBackColor = true;
            this.buttonConvert.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(244, 122);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "CANCEL";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // comboBoxLanguage
            // 
            this.comboBoxLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLanguage.FormattingEnabled = true;
            this.comboBoxLanguage.Items.AddRange(new object[] {
            "AFRIKAANS",
            "ALBANIAN",
            "AMHARIC\t",
            "ARABIC",
            "ARMENIAN",
            "AZERBAIJANI",
            "BASQUE",
            "BELARUSIAN",
            "BENGALI",
            "BIHARI",
            "BRETON",
            "BULGARIAN",
            "BURMESE\t",
            "CATALAN\t",
            "CHEROKEE",
            "CHINESE",
            "CHINESE_SIMPLIFIED",
            "CHINESE_TRADITIONAL",
            "CORSICAN",
            "CROATIAN",
            "CZECH",
            "DANISH",
            "DHIVEHI",
            "DUTCH",
            "ENGLISH",
            "ESPERANTO",
            "ESTONIAN",
            "FAROESE",
            "FILIPINO",
            "FINNISH",
            "FRENCH",
            "FRISIAN",
            "GALICIAN",
            "GEORGIAN",
            "GERMAN",
            "GREEK",
            "GUJARATI",
            "HAITIAN_CREOLE",
            "HEBREW",
            "HINDI",
            "HUNGARIAN",
            "ICELANDIC",
            "INDONESIAN",
            "INUKTITUT",
            "IRISH",
            "ITALIAN",
            "JAPANESE",
            "JAVANESE",
            "KANNADA",
            "KAZAKH",
            "KHMER",
            "KOREAN",
            "KURDISH",
            "KYRGYZ",
            "LAO",
            "LATIN",
            "LATVIAN",
            "LITHUANIAN",
            "LUXEMBOURGISH",
            "MACEDONIAN",
            "MALAY",
            "MALAYALAM",
            "MALTESE",
            "MAORI",
            "MARATHI",
            "MONGOLIAN",
            "NEPALI",
            "NORWEGIAN",
            "OCCITAN\t",
            "ORIYA",
            "PASHTO",
            "PERSIAN",
            "POLISH",
            "PORTUGUESE",
            "PORTUGUESE_PORTUGAL",
            "PUNJABI",
            "QUECHUA",
            "ROMANIAN",
            "RUSSIAN",
            "SANSKRIT",
            "SCOTS_GAELIC",
            "SERBIAN",
            "SINDHI",
            "SINHALESE",
            "SLOVAK",
            "SLOVENIAN",
            "SPANISH",
            "SUNDANESE",
            "SWAHILI",
            "SWEDISH",
            "SYRIAC",
            "TAJIK",
            "TAMIL",
            "TATAR",
            "TELUGU",
            "THAI",
            "TIBETAN",
            "TONGA",
            "TURKISH",
            "UKRAINIAN",
            "URDU",
            "UZBEK",
            "UIGHUR",
            "VIETNAMESE",
            "WELSH",
            "YIDDISH",
            "YORUBA"});
            this.comboBoxLanguage.Location = new System.Drawing.Point(12, 88);
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            this.comboBoxLanguage.Size = new System.Drawing.Size(369, 21);
            this.comboBoxLanguage.TabIndex = 2;
            this.comboBoxLanguage.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // textBoxKey
            // 
            this.textBoxKey.Location = new System.Drawing.Point(12, 12);
            this.textBoxKey.Name = "textBoxKey";
            this.textBoxKey.Size = new System.Drawing.Size(369, 20);
            this.textBoxKey.TabIndex = 3;
            this.textBoxKey.Text = "Enter your Google API Key";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(69, 47);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "SAVE";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(244, 47);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 5;
            this.buttonReset.Text = "RESET";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // frmNewLayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 157);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxKey);
            this.Controls.Add(this.comboBoxLanguage);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonConvert);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNewLayer";
            this.Text = "New Layer";
            this.Load += new System.EventHandler(this.frmNewLayer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonConvert;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ComboBox comboBoxLanguage;
        private System.Windows.Forms.TextBox textBoxKey;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonReset;
    }
}

