﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

//using Tao.OpenGl;
//using Tao.Platform.Windows;

using OpenTK.Graphics.OpenGL;

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
        const int LAYER_PHYSICS = 2;

        // Different tree views to populate corresponding trees
        const int TREE_VIEW_MAP = 0;
        const int TREE_VIEW_SPRITE = 1;
        const int TREE_VIEW_SOUND = 2;
        const int TREE_VIEW_TEXT = 3;
        const int TREE_VIEW_LEVEL = 4;

        string m_spriteRootDirectory = null;
        string m_tileRootDirectory = null;
        string m_projectRootDirectory = null;

        string substringDirectory;
        string substringFile;

        //Viewer settings
        
        Color mViewerBGcolor = Color.White;

        int hScrollBarPbViewerTileSetX = 0;
        int vScrollBarPbViewerTileSetY = 0;

        Bitmap m_selectedTileSet = null;

        Pen gPen;
        bool m_bShowMapGrid = false;

        //layer
        UInt32 m_layerID = 0;
        int m_layerType;
        string m_layerName;
        UInt16 m_mapWidth;
        UInt16 m_mapHeight;
        UInt16 m_tileWidth;
        UInt16 m_tileHeight;
        UInt16 m_nbHTiles;
        UInt16 m_nbVTiles;


        //camera
        UInt32 m_cameraID = 0;
        Int16 m_cameraX;
        Int16 m_cameraY;
        UInt16 m_cameraWidth;
        UInt16 m_cameraHeight;


        CGame m_game;

        public LevelEditor()
        {
            InitializeComponent();
            InitializeLevelEditor();

            m_game = new CGame();
        }

        private void InitializeLevelEditor()
        {
            treeViewSprite.ImageList = imageListTreeViewSprite;
            treeViewMap.ImageList = imageListTreeViewTileSet;

            gPen = new Pen(Color.Gray, 1);

            return;
        }

        public void PopulateTreeView(string directoryValue, TreeNode parentNode, int type)
        {
            string[] directoryArray = Directory.GetDirectories(directoryValue);

            try
            {
                if (directoryArray.Length != 0)
                {
                    foreach (string directory in directoryArray)
                    {
                        if (type == TREE_VIEW_SPRITE)
                        {
                            if (directory.IndexOf("\\Sprite") == -1)
                            {
                                continue;
                            }
                        }
                        else if (type == TREE_VIEW_MAP)
                        {
                            if (directory.IndexOf("\\Map") == -1)
                            {
                                continue;
                            }
                        }
                        
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
                        else if (type == TREE_VIEW_MAP)
                        {
                            fileFilter = Directory.GetFiles(@directory, "*.map");
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
      
        }

        private void UpdatePictureBoxes()
        {

        }

        private void DrawPictureBoxes()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            OpenGlControlEditor.SwapBuffers();
        }

        private void LevelEditor_Load(object sender, EventArgs e)
        {
            // Resize will be called already, so need to create buffer again here
            // May be because of start maximised is set in from property

            OpenGlControlEditor.InitializeContexts();
            GL.ClearColor(Color.White);

            // start timer
            timerUpdate.Enabled = true;
        }

        private void LevelEditor_Resize(object sender, EventArgs e)
        {
            
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

                case LAYER_PHYSICS:
                    break;
            }
        }

        private void toolStripButtonGrid_Click(object sender, EventArgs e)
        {
            m_bShowMapGrid = !m_bShowMapGrid;
        }

        private void toolStripButtonAddObject_Click(object sender, EventArgs e)
        {
            NewObject newObjectForm = new NewObject();
            newObjectForm.Show();
        }

        private void toolStripButtonPlay_Click(object sender, EventArgs e)
        {
            StartPreview();
        }

        private void StartPreview()
        {
            if (m_cameraWidth < 128 || m_cameraHeight < 128)
            {
                MessageBox.Show("Please set camera width and height of minimum 128");
                return;
            }

            Preview newPreviewForm = new Preview();
            newPreviewForm.MaximizeBox = false;
            newPreviewForm.Width = m_cameraWidth;
            newPreviewForm.Height = m_cameraHeight;
            newPreviewForm.Show();
        }

        private void newToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            saveFileDialogLevel.ShowDialog();
        }

        private void saveFileDialogLevel_FileOk(object sender, CancelEventArgs e)
        {
            if (saveFileDialogLevel.FileName != "")
            {
                m_projectRootDirectory = saveFileDialogLevel.FileName;
                System.IO.Directory.CreateDirectory(saveFileDialogLevel.FileName);
                System.IO.Directory.CreateDirectory(saveFileDialogLevel.FileName + "/" + "Text");
                System.IO.Directory.CreateDirectory(saveFileDialogLevel.FileName + "/" + "Sprite");
                System.IO.Directory.CreateDirectory(saveFileDialogLevel.FileName + "/" + "Level");
                System.IO.Directory.CreateDirectory(saveFileDialogLevel.FileName + "/" + "Map");
                System.IO.Directory.CreateDirectory(saveFileDialogLevel.FileName + "/" + "Sound");
                System.IO.Directory.CreateDirectory(saveFileDialogLevel.FileName + "/" + "Raw");
                //int nameStart = m_projectRootDirectory.LastIndexOf("\\");
                //string projectName = m_projectRootDirectory.Substring(nameStart, m_projectRootDirectory.Length - nameStart);
                //System.IO.File.Create(m_projectRootDirectory + projectName + ".game");
            }
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void RefreshData()
        {
            if (m_projectRootDirectory != null)
            {
                // Show sprties in tree view
                treeViewSprite.Nodes.Clear();
                m_spriteRootDirectory = m_projectRootDirectory + "\\" + "Sprite";
                treeViewSprite.Nodes.Add(m_projectRootDirectory);
                PopulateTreeView(m_projectRootDirectory, treeViewSprite.Nodes[0], TREE_VIEW_SPRITE);

                // Show sprties in tree view
                treeViewMap.Nodes.Clear();
                m_tileRootDirectory = m_projectRootDirectory + "\\" + "Map";
                treeViewMap.Nodes.Add(m_projectRootDirectory);
                PopulateTreeView(m_projectRootDirectory, treeViewMap.Nodes[0], TREE_VIEW_MAP);
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenProject();
        }

        private void OpenProject()
        {
            DialogResult result = this.folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                m_projectRootDirectory = folderBrowserDialog.SelectedPath;
            }
            else
            {
                m_projectRootDirectory = null;
            }
            RefreshData();
        }

        private void toolStripButtonCamera_Click(object sender, EventArgs e)
        {
            SetCamera();
        }

        private void SetCamera()
        {
            CameraProperties newCamPropForm = new CameraProperties();
            newCamPropForm.MaximizeBox = false;
            newCamPropForm.m_cameraX = m_cameraX;
            newCamPropForm.m_cameraY = m_cameraY;
            newCamPropForm.m_cameraWidth = m_cameraWidth;
            newCamPropForm.m_cameraHeight = m_cameraHeight;
            newCamPropForm.Init();

            newCamPropForm.ShowDialog(); ;
            m_cameraX = newCamPropForm.m_cameraX;
            m_cameraY = newCamPropForm.m_cameraY;
            m_cameraWidth = newCamPropForm.m_cameraWidth;
            m_cameraHeight = newCamPropForm.m_cameraHeight;
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void previewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartPreview();
        }

        private void setCameraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetCamera();
        }

        private void toolStripButtonOpen_Click(object sender, EventArgs e)
        {
            OpenProject();
        }

        private void buttonDeleteLayer_Click(object sender, EventArgs e)
        {
            DialogResult result3 = MessageBox.Show("Do you want to delete the Layer? \n [This action will be undoable]", "Level Editor",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button2);
        }

        private void toolStripButtonAddLEvel_Click(object sender, EventArgs e)
        {
            frmNewLevel childWindow = new frmNewLevel();
            childWindow.ShowDialog();
            string lvlname = childWindow.GetLevelName();
            childWindow.Dispose();
        }

        private void treeViewMap_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            e.Node.ImageIndex = 0;
        }

        private void treeViewMap_AfterExpand(object sender, TreeViewEventArgs e)
        {
            e.Node.ImageIndex = 1;
        }

        private void treeViewMap_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.ToString().IndexOf(".MAP") != -1
                || e.Node.ToString().IndexOf(".map") != -1)
            {
                e.Node.SelectedImageIndex = 3;
            }
        }

        private void OpenGlControlEditor_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void OpenGlControlEditor_MouseMove(object sender, MouseEventArgs e)
        {
            lblMouseX.Text = "Mouse X :" + e.X;
            lblMouseY.Text = "Mouse Y :" + e.Y;
        }

        private void pnlBgColor_MouseDown(object sender, MouseEventArgs e)
        {
            DialogResult result = colorDialogBg.ShowDialog();
            if (result == DialogResult.OK)
            {
                mViewerBGcolor = colorDialogBg.Color;
                GL.ClearColor(mViewerBGcolor);
                pnlBgColor.BackColor = mViewerBGcolor;
            }
        }

    }

    public class CTileLayer
    {
        const uint FLAG_FLIP_X      = 0x1;
		const uint FLAG_FLIP_Y      = 0x10;
		const uint FLAG_ROTATE_90   = 0x100;
		const uint FLAG_ROTATE_180  = 0x1000;
        const uint FLAG_ROTATE_270  = 0x10000;

        public UInt32 m_layerID = 0;
        public int m_layerType;
        public string m_layerName;
        public UInt16 m_mapWidth;
        public UInt16 m_mapHeight;
        public UInt16 m_tileWidth;
        public UInt16 m_tileHeight;
        public UInt16 m_nbHTiles;
        public UInt16 m_nbVTiles;
        public UInt16[,] m_tileArray;
        public UInt32[,] m_tileFlagArray;
    }

    public class CLevel
    {
        public List<CTileLayer> mListLayers = new List<CTileLayer>();
    }

    public class CGame
    {
        public List<CLevel> mListLayers = new List<CLevel>();
    }
}
