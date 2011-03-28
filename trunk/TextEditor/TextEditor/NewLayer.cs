using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;

namespace NewLayer
{
    public partial class frmNewLayer : Form
    {
        public int m_selectedLanguage = 0;
        public string m_apiKey = null;

        public frmNewLayer()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            // create a writer and open the file
            TextWriter tw = new StreamWriter("apikey.txt");

            // write a line of text to the file
            tw.WriteLine(textBoxKey.Text);

            // close the stream
            tw.Close();

            buttonSave.Enabled = false;
            textBoxKey.Enabled = false;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmNewLayer_Load(object sender, EventArgs e)
        {
            comboBoxLanguage.SelectedIndex = 0;

            TextReader tr = null;
            // create reader & open file
            try
            {
                tr = new StreamReader("apikey.txt");
            }
            catch
            {

            }
            if (tr == null)
            {
                buttonSave.Enabled = true;
                textBoxKey.Enabled = true;
            }
            else
            {
                // read a line of text
                m_apiKey = tr.ReadLine();

                // close the stream
                tr.Close();

                textBoxKey.Text = m_apiKey;
                buttonSave.Enabled = false;
                textBoxKey.Enabled = false;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            m_selectedLanguage = comboBoxLanguage.SelectedIndex;
            this.Close();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            buttonSave.Enabled = true;
            textBoxKey.Enabled = true;
        }
    }
}
