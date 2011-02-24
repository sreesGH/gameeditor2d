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
    public partial class LevelEditor : Form
    {
        public LevelEditor()
        {
            InitializeComponent();
        }

        private void buttonBrowseSprite_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.ShowDialog();
        }

        private void pbTileViewer_Click(object sender, EventArgs e)
        {

        }

        private void buttonBrowseTilesetFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.ShowDialog();
        }
    }
}
