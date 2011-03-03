using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace LevelEditor
{
    public partial class LevelEditor : Form
    {

        const int TREE_VIEW_SPRITE = 0;
        const int TREE_VIEW_TILESET = 1;
        const int TREE_VIEW_LEVEL = 2;

        string m_spriteRootDirectory = null;
        string m_tileRootDirectory = null;

        string substringDirectory;
        string substringFile;

        public LevelEditor()
        {
            InitializeComponent();
            InitializeLevelEditor();
        }

        private void InitializeLevelEditor()
        {
            treeViewSprite.ImageList = imageListTreeViewSprite;
            treeViewTileImages.ImageList = imageListTreeViewTileSet;
            return;
        }

        private void buttonBrowseSprite_Click(object sender, EventArgs e)
        {
            DialogResult result = this.folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                m_spriteRootDirectory = folderBrowserDialog.SelectedPath;
                treeViewSprite.Nodes.Add(m_spriteRootDirectory);
                PopulateTreeView(m_spriteRootDirectory, treeViewSprite.Nodes[0], TREE_VIEW_SPRITE);
            }
            else
            {
                m_spriteRootDirectory = null;
            }

        }

        private void buttonBrowseTilesetFolder_Click(object sender, EventArgs e)
        {
            DialogResult result = this.folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                m_tileRootDirectory = folderBrowserDialog.SelectedPath;
                treeViewTileImages.Nodes.Add(m_tileRootDirectory);
                PopulateTreeView(m_tileRootDirectory, treeViewTileImages.Nodes[0], TREE_VIEW_TILESET);
            }
            else
            {
                m_tileRootDirectory = null;
            }
        }

        public void PopulateTreeView(string directoryValue, TreeNode parentNode, int type)
        {
            string[] directoryArray =
             Directory.GetDirectories(directoryValue);

            try
            {
                if (directoryArray.Length != 0)
                {
                    foreach (string directory in directoryArray)
                    {
                        substringDirectory = directory.Substring(
                        directory.LastIndexOf('\\') + 1,
                        directory.Length - directory.LastIndexOf('\\') - 1);

                        TreeNode myNode = new TreeNode(substringDirectory);
                        myNode.ImageIndex = 0;
                        parentNode.Nodes.Add(myNode);

                        string[] fileFilter = null;
                        if (type == TREE_VIEW_SPRITE)
                        {
                            fileFilter = Directory.GetFiles(@directory, "*.gfx");
                        }
                        else if (type == TREE_VIEW_TILESET)
                        {
                            fileFilter = Directory.GetFiles(@directory, "*.bmp");
                        }
                        else if (type == TREE_VIEW_LEVEL)
                        {
                            fileFilter = Directory.GetFiles(@directory, "*.lvl");
                        }

                        foreach (string file in fileFilter)
                        {
                            substringFile = file.Substring(
                            file.LastIndexOf('\\') + 1,
                            file.Length - file.LastIndexOf('\\') - 1);
                            TreeNode myNode1 = new TreeNode(substringFile);
                            myNode1.ImageIndex = 2;
                            myNode.Nodes.Add(myNode1);
                        }

                        PopulateTreeView(directory, myNode, type);
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                parentNode.Nodes.Add("Access denied");
            } // end catch
        }

        private void treeViewSprite_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            e.Node.ImageIndex = 0;
        }

        private void treeViewSprite_AfterExpand(object sender, TreeViewEventArgs e)
        {
            e.Node.ImageIndex = 1;
        }

        private void treeViewSprite_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.ToString().IndexOf(".gfx") != -1)
            {
               e.Node.SelectedImageIndex = 3;
            }
        }

        private void treeViewTileImages_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            e.Node.ImageIndex = 0;
        }

        private void treeViewTileImages_AfterExpand(object sender, TreeViewEventArgs e)
        {
            e.Node.ImageIndex = 1;
        }

        private void treeViewTileImages_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.ToString().IndexOf(".bmp") != -1
                || e.Node.ToString().IndexOf(".png") != -1
                || e.Node.ToString().IndexOf(".tga") != -1)
            {
                e.Node.SelectedImageIndex = 3;

                string path = null;

                TreeNode n = e.Node.Parent;
                while(n != null)
                {
                    path = (n.Text + "\\" + path);
                    n = n.Parent;
                }

                path += e.Node.Text;
                pbTileViewer.Image = new Bitmap(path);
            }
        }
    }
}
