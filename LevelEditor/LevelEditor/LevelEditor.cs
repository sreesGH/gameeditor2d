﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using NewLayer;

namespace LevelEditor
{
    public partial class LevelEditor : Form
    {

        // Commands to do actions
        const int ACTION_ADD_LAYER = 0;


        // Types of layers
        const int LAYER_TILE = 0;
        const int LAYER_OBJECT = 1;

        // Different tree views to populate corresponding trees
        const int TREE_VIEW_SPRITE = 0;
        const int TREE_VIEW_TILESET = 1;
        const int TREE_VIEW_LEVEL = 2;

        string m_spriteRootDirectory = null;
        string m_tileRootDirectory = null;

        string substringDirectory;
        string substringFile;

        //Viewer settings
        Graphics gViewerGraphics;
        Bitmap gViewerBuffer;
        int pbViewerWidth = 800;
        int pbViewerHeight = 480;
        Color pbViewerBGcolor = Color.White;

        Graphics gTileViewerGraphics;
        Bitmap gTileViewerBuffer;
        int pbTileViewerWidth = 800;
        int pbTileViewerHeight = 480;
        Color pbTileViewerBGcolor = Color.Magenta;

        int hScrollBarPbViewerTileSetX = 0;
        int vScrollBarPbViewerTileSetY = 0;

        Bitmap m_selectedTileSet = null;

        int m_layerID = 0;
        int m_layerType;
        string m_layerName;
        int m_mapWidth;
        int m_mapHeight;
        int m_tileWidth;
        int m_tileHeight;
        int m_nbHTiles;
        int m_nbVTiles;

        Pen gPen;
        Boolean m_bShowMapGrid = false;

        public LevelEditor()
        {
            InitializeComponent();
            InitializeLevelEditor();
        }

        private void InitializeLevelEditor()
        {
            treeViewSprite.ImageList = imageListTreeViewSprite;
            treeViewTileImages.ImageList = imageListTreeViewTileSet;

            gPen = new Pen(Color.Gray, 1);

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
                m_selectedTileSet = new Bitmap(path);
                hScrollBarPbViewerTileSet.Maximum = m_selectedTileSet.Width - pbTileViewer.Width;
                vScrollBarPbViewerTileSet.Maximum = m_selectedTileSet.Height - pbTileViewer.Height;
            }
        }

        private void hScrollBarPbViewerTileSet_Scroll(object sender, ScrollEventArgs e)
        {
            hScrollBarPbViewerTileSetX = e.NewValue;
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            vScrollBarPbViewerTileSetY = e.NewValue;
        }

        private void timerUpdate_Tick(object sender, EventArgs e)
        {
            UpdatePictureBoxes();
            DrawPictureBoxes();
            pbViewer.Refresh();
            pbTileViewer.Refresh();
        }

        private void UpdatePictureBoxes()
        {

        }

        private void DrawPictureBoxes()
        {
            //Clear it
            gViewerGraphics.Clear(pbViewerBGcolor);
            gTileViewerGraphics.Clear(pbTileViewerBGcolor);

            if (m_selectedTileSet != null)
            {
                gTileViewerGraphics.DrawImage(m_selectedTileSet, -hScrollBarPbViewerTileSetX, -vScrollBarPbViewerTileSetY);
            }

            if (m_bShowMapGrid)
            {
                if (m_tileHeight <= 0 || m_tileWidth <= 0)
                {
                    m_tileHeight = 16;
                    m_tileWidth = 16;
                }

                int nbHlines = pbViewerWidth / m_tileHeight + 1;
                int nbVlines = pbViewerWidth / m_tileWidth + 1;

                for(int i = 0; i < nbHlines; i++)
                {
                    gViewerGraphics.DrawLine(gPen, 0, i * m_tileHeight, pbViewerWidth, i * m_tileHeight);
                }
                for (int j = 0; j < nbVlines; j++)
                {
                    gViewerGraphics.DrawLine(gPen, j * m_tileWidth, 0, j * m_tileWidth, pbViewerHeight);
                }
            }

            if (checkBoxShowTileGrid.Checked)
            {
                if (m_tileHeight <= 0 || m_tileWidth <= 0)
                {
                    m_tileHeight = 16;
                    m_tileWidth = 16;
                }

                int nbHlines = pbTileViewerWidth / m_tileHeight + 1;
                int nbVlines = pbTileViewerWidth / m_tileWidth + 1;

                for (int i = 0; i < nbHlines; i++)
                {
                    gTileViewerGraphics.DrawLine(gPen, 0, i * m_tileHeight - vScrollBarPbViewerTileSetY, pbViewerWidth, i * m_tileHeight - vScrollBarPbViewerTileSetY);
                }
                for (int j = 0; j < nbVlines; j++)
                {
                    gTileViewerGraphics.DrawLine(gPen, j * m_tileWidth - hScrollBarPbViewerTileSetX, 0, j * m_tileWidth - hScrollBarPbViewerTileSetX, pbViewerHeight);
                }
            }
        }

        private void LevelEditor_Load(object sender, EventArgs e)
        {
            // Resize will be called already, so need to create buffer again here
            // May be because of start maximised is set in from property
            
            // start timer
            timerUpdate.Enabled = true;
        }

        private void LevelEditor_Resize(object sender, EventArgs e)
        {
            pbViewerWidth = pbViewer.Width;
            pbViewerHeight = pbViewer.Height;

            if (pbViewerWidth <= 0 || pbViewerHeight <= 0) return;

            if (gViewerBuffer != null)
            {
                gViewerBuffer.Dispose();
            }
            if (gViewerGraphics != null)
            {
                gViewerGraphics.Dispose();
            }
            gViewerBuffer = new Bitmap(pbViewerWidth, pbViewerHeight);
            gViewerGraphics = Graphics.FromImage(gViewerBuffer);
            pbViewer.Image = gViewerBuffer;

            pbTileViewerWidth = pbTileViewer.Width;
            pbTileViewerHeight = pbTileViewer.Height;

            if (pbTileViewerWidth <= 0 || pbTileViewerHeight <= 0) return;

            if (gTileViewerBuffer != null)
            {
                gTileViewerBuffer.Dispose();
            }
            if (gTileViewerGraphics != null)
            {
                gTileViewerGraphics.Dispose();
            }

            gTileViewerBuffer = new Bitmap(pbTileViewerWidth, pbTileViewerHeight);
            gTileViewerGraphics = Graphics.FromImage(gTileViewerBuffer);
            pbTileViewer.Image = gTileViewerBuffer;
        }

        private void toolStripButtonAddLayer_Click(object sender, EventArgs e)
        {
            frmNewLayer childWindow = new frmNewLayer();
            childWindow.ShowDialog();

            m_layerType = childWindow.m_layerType;
            m_layerName = childWindow.m_layerName;

            if (childWindow.m_mapWidth > 0 && childWindow.m_mapHeight > 0)
            {
                m_mapWidth = childWindow.m_mapWidth;
                m_mapHeight = childWindow.m_mapHeight;
                m_tileWidth = childWindow.m_tileWidth;
                m_tileHeight = childWindow.m_tileHeight;
                m_nbHTiles = childWindow.m_nbHTiles;
                m_nbVTiles = childWindow.m_nbVTiles;
            }
            if (m_layerType != -1)
            {
                DoAction(ACTION_ADD_LAYER);
            }
        }

        private void DoAction(int command )
        {
            switch(command)
            {
                case ACTION_ADD_LAYER:
                    AddLayer();
                    break;
            }
        }

        private void AddLayer()
        {
            switch (m_layerType)
            {
                case LAYER_TILE:
                    break;
                
                case LAYER_OBJECT:
                    break;
            }

            int n = dataGridViewLayer.Rows.Add();
            dataGridViewLayer.Rows[n].Cells[0].Value = "" + m_layerID;
            m_layerID++;
            dataGridViewLayer.Rows[n].Cells[1].Value = "" + m_layerName;
            dataGridViewLayer.Rows[n].Cells[2].Value = "" + (m_layerType == 0 ? "TILE LAYER" : "OBJECT LAYER");
            //dataGridViewLayer.Rows[n].Cells[3].Value = "" + m_layerID;

        }

        private void toolStripButtonGrid_Click(object sender, EventArgs e)
        {
            m_bShowMapGrid = !m_bShowMapGrid;
        }
    }
}
