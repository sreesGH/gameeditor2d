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
        string SpriteRootDirectory = null;
        string TileRootDirectory = null;

        public LevelEditor()
        {
            InitializeComponent();
        }

        private void buttonBrowseSprite_Click(object sender, EventArgs e)
        {
            DialogResult result=this.folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                SpriteRootDirectory = folderBrowserDialog.SelectedPath;
            }
            else
            {
                SpriteRootDirectory = null;
            }

        }

        private void pbTileViewer_Click(object sender, EventArgs e)
        {

        }

        private void buttonBrowseTilesetFolder_Click(object sender, EventArgs e)
        {
            DialogResult result = this.folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                TileRootDirectory = folderBrowserDialog.SelectedPath;
            }
            else
            {
                TileRootDirectory = null;
            }
        }

        private void folderBrowserDialog_HelpRequest(object sender, EventArgs e)
        {
        }
    }
}
