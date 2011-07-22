using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LevelEditor
{
    public partial class NewObject : Form
    {
        public NewObject()
        {
            InitializeComponent();
        }

        private void NewObject_Load(object sender, EventArgs e)
        {
            comboBoxObjectType.SelectedIndex = 0;
        }
    }
}
