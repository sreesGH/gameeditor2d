﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Xml.Serialization;

namespace TileMapEditor
{
    public partial class frmTielMapEditor : Form
    {
        static Graphics gMapViewerGraphics;
        static Bitmap gMapViewerBuffer;

        static Graphics gTileSetViewerGraphics;
        static Bitmap gTileSetViewerBuffer;

        static Color MapViewerBGcolor = new Color();
        static Color TileSetViewerBGcolor = new Color();

        static bool mbShowGridOnMapViewer = false;
        static Pen blackPen = new Pen(Color.Black, 1);

        bool mbParamSet = false;
        bool m_bLeftMouseDownMapViewer = false;
        bool mbOpenMap = false;

        static CTileMap mTileMap = null;
        static Bitmap mTileSetImage = null;
        static Bitmap[,] mTileImageArray = null;

        static int mSelectedTileId = -1;
        static int mNbhTilesInTileSet = 0;
        static int mNbvTilesInTileSet = 0;

        static int mMapViewerMouseX = 0;
        static int mMapViewerMouseY = 0;

        static string mSavePath = null;

        //Action list
        const int ADD_TILES = 0;
        const int REMOVE_TILES = ADD_TILES + 1;
        const int ROTATE_TILES = REMOVE_TILES + 1;
        const int FLIP_H_TILES = ROTATE_TILES + 1;
        const int FLIP_V_TILES = FLIP_H_TILES + 1;

        static Stack<CAction> mActionUndoStack = new Stack<CAction>();
        static Stack<CAction> mActionRedoStack = new Stack<CAction>();

        public static void DoAction(int action, int[] param)
        {
            switch (action)
            {
                case ADD_TILES:
                    {
                        CAction actionObj = new CAction(action, param);
                        mActionUndoStack.Push(actionObj);
                        //Add single tile
                        //param[0] = tileid, param[1] = mouseX, param[2] = mouseY
                        if(param.Length == 3)   
                        {
                            AssignTile(param[0], param[1], param[2]);
                        }
                        //Add tiles in an area 
                        //param[0] = tileid, param[1] = mouseStartX, param[2] = mouseStartY
                        //param[3] = mouseEndX, param[4] = mouseEndY
                        else if (param.Length == 5)
                        {

                        }
                    }
                    break;

                case REMOVE_TILES:
                    {
                        CAction actionObj = new CAction(action, param);
                        mActionUndoStack.Push(actionObj);
                        //Add single tile
                        //param[0] = mouseX, param[1] = mouseY
                        if (param.Length == 2)
                        {
                            AssignTile(-1, param[1], param[2]);
                        }
                        //Add tiles in an area 
                        //param[0] = mouseStartX, param[1] = mouseStartY
                        //param[2] = mouseEndX, param[3] = mouseEndY
                        else if (param.Length == 4)
                        {

                        }
                    }
                    break;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //The technique is: 
        //  Keep the Command objects in a stack to support multi level undo. 
        //  A second stack keeps all the commands you've Undone in order to support redo. 
        //  So when you pop the undo stack to undo a command,
        //      you push the same command you popped into the redo stack. 
        //  You do the same thing in reverse when you redo a command.
        //  You pop the redo stack and push the popped command back into the undo stack.
        //////////////////////////////////////////////////////////////////////////////////////

        public static void UnDoAction(int action, int[] param)
        {

        }

        public static void ReDoAction(int action, int[] param)
        {

        }

        public frmTielMapEditor()
        {
            InitializeComponent();
        }

        private void frmTielMapEditor_Load(object sender, EventArgs e)
        {
            CreateMapViewerBuffers();
            CreateTileSetViewerBuffers();

            //Set bg color
            MapViewerBGcolor = Color.Pink;
            TileSetViewerBGcolor = Color.Pink;

            //Disable entire text boxes
            gbTilest.Enabled = false;

            //Enable timer
            timerUpdate.Enabled = true;
        }

        private void CreateMapViewerBuffers()
        {
            if (gMapViewerBuffer != null)
            {
                gMapViewerBuffer.Dispose();
            }
            if (pictureBoxMapViewer.Image != null)
            {
                gMapViewerBuffer = new Bitmap(pictureBoxMapViewer.Image.Width, pictureBoxMapViewer.Image.Height);
                if (gMapViewerGraphics != null)
                {
                    gMapViewerGraphics.Dispose();
                }
                gMapViewerGraphics = Graphics.FromImage(gMapViewerBuffer);

                pictureBoxMapViewer.Image = gMapViewerBuffer;
            }
        }

        private void CreateTileSetViewerBuffers()
        {
            if (gTileSetViewerBuffer != null)
            {
                gTileSetViewerBuffer.Dispose();
            }
            if (pictureBoxTileSetViewer.Image != null)
            {
                gTileSetViewerBuffer = new Bitmap(pictureBoxTileSetViewer.Image.Width, pictureBoxTileSetViewer.Image.Height);
                if (gTileSetViewerGraphics != null)
                {
                    gTileSetViewerGraphics.Dispose();
                }
                gTileSetViewerGraphics = Graphics.FromImage(gTileSetViewerBuffer);

                pictureBoxTileSetViewer.Image = gTileSetViewerBuffer;
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mbOpenMap = false;
            InitAll();
        }

        private void toolStripButtonNew_Click(object sender, EventArgs e)
        {
            mbOpenMap = false;
            InitAll();
        }

        private void InitAll()
        {
            gbTilest.Enabled = true;

            textBoxTileSetName.Text = "";
            textBoxTileWidth.Text = "";
            textBoxTileHeight.Text = "";
            textBoxMapWidth.Text = "";
            textBoxMapHeight.Text = "";
            labelMapSize.Text = "Map Size : ";

            // Needed to get text changed in multiple text boxes
            foreach (Control maybeTextBox in GetControls(this))
            {
                if (maybeTextBox is TextBox)
                {
                    maybeTextBox.TextChanged += new EventHandler(textBoxTileWidth_TextChanged);
                    if (maybeTextBox.Name != "textBoxTileSetName")
                    {
                        maybeTextBox.KeyPress += new KeyPressEventHandler(textBoxTileWidth_KeyPress);
                    }
                }
            }

            mTileMap = new CTileMap();
        }

        // Needed to get controls recursively if controls are inside another control
        // Here all text boxes are inside groupbox
        public static Control[] GetControls(Control findIn)
        {
            List<Control> allControls = new List<Control>();
            foreach (Control oneControl in findIn.Controls)
            {
                allControls.Add(oneControl);
                if (oneControl.Controls.Count > 0)
                    allControls.AddRange(GetControls(oneControl));
            }
            return allControls.ToArray();
        }

        private void textBoxTileWidth_TextChanged(object sender, EventArgs e)
        {
            labelMapSize.Text = "Map Size : ";

            if (textBoxTileWidth.Text != "" && textBoxTileWidth.Text != null
                && textBoxMapWidth.Text != "" && textBoxMapWidth.Text != null
                && textBoxTileHeight.Text != "" && textBoxTileHeight.Text != null
                && textBoxMapHeight.Text != "" && textBoxMapHeight.Text != null
                )
            {
                mTileMap.mtileWidth = System.Convert.ToUInt16(textBoxTileWidth.Text);
                mTileMap.mnbHTiles = System.Convert.ToUInt16(textBoxMapWidth.Text);
                mTileMap.mtileHeight = System.Convert.ToUInt16(textBoxTileHeight.Text);
                mTileMap.mnbVTiles = System.Convert.ToUInt16(textBoxMapHeight.Text);

                int mapWidth = (UInt16)(mTileMap.mnbHTiles * mTileMap.mtileWidth);
                int mapHeight = (UInt16)(mTileMap.mnbVTiles * mTileMap.mtileHeight);
                labelMapSize.Text = "Map Size : " + mapWidth + " x " + mapHeight + " [in Pixels]";

                //Resize picturebox image
                //pictureBoxMapViewer.Image.Dispose();
                pictureBoxMapViewer.Image = new Bitmap(mapWidth, mapHeight);
                
                //not when map is opened, do it only when new map is created
                if (!mbOpenMap)
                {
                    //set default map each element to -1
                    mTileMap.mtileArray = new int[mTileMap.mnbHTiles * mTileMap.mnbVTiles];
                    for (int i = 0; i < mTileMap.mnbHTiles * mTileMap.mnbVTiles; i++)
                    {
                        //for (int j = 0; j < mTileMap.mnbVTiles; j++)
                        {
                            mTileMap.mtileArray[i] = -1;
                        }
                    }
                }

                CreateMapViewerBuffers();
                CreateTileImages();

                mbParamSet = true;
            }
        }

        private void textBoxTileWidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

        }

        private void CreateTileImages()
        {
            mNbhTilesInTileSet = mTileSetImage.Width / mTileMap.mtileWidth;
            mNbvTilesInTileSet = mTileSetImage.Height / mTileMap.mtileHeight;

            mTileImageArray = new Bitmap[mNbhTilesInTileSet, mNbvTilesInTileSet];

            for (int i = 0; i < mNbhTilesInTileSet; i++)
            {
                for (int j = 0; j < mNbvTilesInTileSet; j++)
                {
                    //create sub tile images now
                    Bitmap bmpDst = new Bitmap(mTileMap.mtileWidth, mTileMap.mtileHeight);

                    using (Graphics gfx = Graphics.FromImage(bmpDst))
                    {
                        gfx.DrawImage(mTileSetImage, 0, 0, new Rectangle(i * mTileMap.mtileWidth, j * mTileMap.mtileHeight, mTileMap.mtileWidth, mTileMap.mtileHeight), GraphicsUnit.Pixel);
                    }

                    mTileImageArray[i, j] = bmpDst;
                }
            }
        }

        private void buttonBrowseTileSet_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialogTileSet.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                mTileMap.mTileSetImagePath = openFileDialogTileSet.FileName;
                CreateTileSetImage();
            }
        }

        private void CreateTileSetImage()
        {
            textBoxTileSetName.Text = mTileMap.mTileSetImagePath;
            mTileSetImage = new Bitmap(mTileMap.mTileSetImagePath);
            pictureBoxTileSetViewer.Image = mTileSetImage;
            CreateTileSetViewerBuffers();
        }

        private void timerUpdate_Tick(object sender, EventArgs e)
        {
            pictureBoxMapViewer.Refresh();
            pictureBoxTileSetViewer.Refresh();

            DrawViewers();
        }

        private void DrawViewers()
        {
            if (gMapViewerGraphics != null)
            {
                //clear
                gMapViewerGraphics.Clear(MapViewerBGcolor);

                //draw map
                if (mbParamSet)
                {
                    for (int i = 0; i < mTileMap.mnbHTiles * mTileMap.mnbVTiles; i++)
                    {
                        //for (int j = 0; j < mTileMap.mnbVTiles; j++)
                        {
                            if (mTileMap.mtileArray[i] != -1)
                            {
                                if (mTileImageArray != null)
                                {
                                    int h = (int)mTileMap.mtileArray[i] / mNbhTilesInTileSet;
                                    int v = (int)mTileMap.mtileArray[i] % mNbhTilesInTileSet;

                                    if (mTileImageArray[v, h] != null)
                                    {
                                        int x = (i % mTileMap.mnbHTiles) * mTileMap.mtileWidth;
                                        int y = (i / mTileMap.mnbHTiles) * mTileMap.mtileHeight;
                                        gMapViewerGraphics.DrawImage(mTileImageArray[v, h], x, y);
                                    }
                                }
                            }
                        }
                    }

                    //draw current selected tile
                    if (mSelectedTileId != -1)
                    {
                        int x = mSelectedTileId / mNbhTilesInTileSet;
                        int y = mSelectedTileId % mNbhTilesInTileSet;
                        if (mTileImageArray[y, x] != null)
                        {
                            gMapViewerGraphics.DrawImage(mTileImageArray[y, x], mMapViewerMouseX, mMapViewerMouseY);
                        }
                    }
                }

                //draw grid
                if (mbShowGridOnMapViewer)
                {
                    for (int i = 0; i < pictureBoxMapViewer.Width; i += mTileMap.mtileWidth)
                    {
                        gMapViewerGraphics.DrawLine(blackPen, i, 0, i, pictureBoxMapViewer.Height);
                    }
                    for (int j = 0; j < pictureBoxMapViewer.Height; j += mTileMap.mtileHeight)
                    {
                        gMapViewerGraphics.DrawLine(blackPen, 0, j, pictureBoxMapViewer.Width, j);
                    }
                }
            }
           
            if (gTileSetViewerGraphics != null)
            {
                //clear
                gTileSetViewerGraphics.Clear(TileSetViewerBGcolor);

                //draw tileset
                gTileSetViewerGraphics.DrawImage(mTileSetImage, new Point(0, 0));

                 //draw grid
                if (mbParamSet)
                {
                    if (checkBoxShowGrid.Checked)
                    {
                        for (int i = 0; i < pictureBoxTileSetViewer.Width; i += mTileMap.mtileWidth)
                        {
                            gTileSetViewerGraphics.DrawLine(blackPen, i, 0, i, pictureBoxTileSetViewer.Height);
                        }
                        for (int j = 0; j < pictureBoxTileSetViewer.Height; j += mTileMap.mtileHeight)
                        {
                            gTileSetViewerGraphics.DrawLine(blackPen, 0, j, pictureBoxTileSetViewer.Width, j);
                        }
                    }
                }
            }
        }

        private void panelMapViewerBGColor_MouseClick(object sender, MouseEventArgs e)
        {
            DialogResult result = colorDialogBGSelector.ShowDialog();
            if (result == DialogResult.OK)
            {
                MapViewerBGcolor = colorDialogBGSelector.Color;
                panelMapViewerBGColor.BackColor = colorDialogBGSelector.Color;
            }
        }

        private void panelTileSetVewerBGColor_MouseClick(object sender, MouseEventArgs e)
        {
            DialogResult result = colorDialogBGSelector.ShowDialog();
            if (result == DialogResult.OK)
            {
                TileSetViewerBGcolor = colorDialogBGSelector.Color;
                panelTileSetVewerBGColor.BackColor = colorDialogBGSelector.Color;
            }
        }

        private void pictureBoxTileSetViewer_MouseMove(object sender, MouseEventArgs e)
        {
            labelTileSetMouseX.Text = "Mouse X : " + e.X;
            labelTileSetMouseY.Text = "Mouse Y : " + e.Y;
        }

        //inorder to avoid cumulative addition of same tile in same location 
        //while mouse move in same grid 
        int lastTilePosX, lastTilePosY = 0;

        private void pictureBoxMapViewer_MouseMove(object sender, MouseEventArgs e)
        {
            labelMapMouseX.Text = "Mouse X : " + e.X;
            labelMapMouseY.Text = "Mouse Y : " + e.Y;

            if (m_bLeftMouseDownMapViewer)
            {
                //AssignTile(e.X, e.Y);
                //if (Math.Abs(e.X - mMapViewerMouseX) > mTileMap.mtileWidth
                //    || Math.Abs(e.Y - lastTilePosY) > mTileMap.mtileHeight)
                {
                    lastTilePosX = e.X;
                    lastTilePosY = e.Y;
                    int[] param = { mSelectedTileId, e.X, e.Y };
                    DoAction(ADD_TILES, param);
                }
            }

            mMapViewerMouseX = e.X;
            mMapViewerMouseY = e.Y;
        }

        private void toolStripButtonShowGrid_Click(object sender, EventArgs e)
        {
            mbShowGridOnMapViewer = !mbShowGridOnMapViewer; 
        }

        private void pictureBoxTileSetViewer_MouseDown(object sender, MouseEventArgs e)
        {
            if (mbParamSet)
            {
                if (e.Button == MouseButtons.Left)
                {
                    int h = e.Y / mTileMap.mtileHeight;
                    int w = e.X / mTileMap.mtileWidth;
                    mSelectedTileId = (h * (pictureBoxTileSetViewer.Image.Width / mTileMap.mtileWidth)) + w;
                }
                else
                {
                    mSelectedTileId = -1;
                }
            }
            labelSelectedTileId.Text = "SelectedTileId :" + mSelectedTileId;
        }

        private void pictureBoxMapViewer_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                m_bLeftMouseDownMapViewer = true;
                //AssignTile(e.X, e.Y);
                int[] param = {mSelectedTileId, e.X, e.Y };
                DoAction(ADD_TILES, param);
            }
            else if (e.Button == MouseButtons.Right)
            {
                mSelectedTileId = -1;
            }
        }

        private static void  AssignTile(int id, int x, int y)
        {
            int h = x / mTileMap.mtileWidth;
            int v = y / mTileMap.mtileHeight;
            int pos = (mTileMap.mnbHTiles * v) + h;
            if (pos >= 0 && pos < (mTileMap.mnbHTiles * mTileMap.mnbVTiles))
            {
                mTileMap.mtileArray[pos] = mSelectedTileId;
            }
        }

        private void pictureBoxMapViewer_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                m_bLeftMouseDownMapViewer = false;
            }
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            if (mSavePath != null)
            {
                Save();
            }
            else
            {
                DialogResult result = saveFileDialogMap.ShowDialog();
                if (result == DialogResult.OK)
                {
                    mSavePath = saveFileDialogMap.FileName;
                    Save();
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mSavePath != null)
            {
                Save();
            }
            else
            {
                DialogResult result = saveFileDialogMap.ShowDialog();
                if (result == DialogResult.OK)
                {
                    mSavePath = saveFileDialogMap.FileName;
                    Save();
                }
            }
        }

        private void Save()
        {
            TextWriter textWriter = new StreamWriter(mSavePath);
            XmlSerializer serializer = new XmlSerializer(typeof(CTileMap));
            serializer.Serialize(textWriter, mTileMap);
            textWriter.Close();
        }

        public static String FindRelativePath(String fromPath, String toPath)
        {
            if (String.IsNullOrEmpty(fromPath)) throw new ArgumentNullException("fromPath");
            if (String.IsNullOrEmpty(toPath)) throw new ArgumentNullException("toPath");

            Uri fromUri = new Uri(fromPath);
            Uri toUri = new Uri(toPath);

            Uri relativeUri = fromUri.MakeRelativeUri(toUri);

            return relativeUri.ToString();

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mbOpenMap = true;
            Open();
        }

        private void toolStripButtonOpen_Click(object sender, EventArgs e)
        {
            mbOpenMap = true;
            Open();
        }

        private void Open()
        {
            DialogResult result = openFileDialogMap.ShowDialog();
            if (result == DialogResult.OK)
            {
                string path = openFileDialogMap.FileName;

                TextReader textReader = new StreamReader(@path);
                XmlSerializer readImage = new XmlSerializer(typeof(CTileMap));
                //mTileMap = new CTileMap();
                InitAll();
                mTileMap = (CTileMap)readImage.Deserialize(textReader);
                textReader.Close();
                CreateTileSetImage();
                CreateTileImages();

                int mapWidth = (UInt16)(mTileMap.mnbHTiles * mTileMap.mtileWidth);
                int mapHeight = (UInt16)(mTileMap.mnbVTiles * mTileMap.mtileHeight);
                labelMapSize.Text = "Map Size : " + mapWidth + " x " + mapHeight + " [in Pixels]";

                textBoxMapHeight.Text = "" + mTileMap.mnbVTiles;
                textBoxMapWidth.Text = "" + mTileMap.mnbHTiles;
                textBoxTileHeight.Text = "" + mTileMap.mtileHeight;
                textBoxTileWidth.Text = "" + mTileMap.mtileWidth;

                mSavePath = path;
            }
        }

        private void frmTielMapEditor_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void frmTielMapEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult resultMsgBox = MessageBox.Show("Do you want to save the changes?",
            "TileMapEditor", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

            if (resultMsgBox == DialogResult.Yes)
            {
                if (mSavePath != null)
                {
                    Save();
                }
                else
                {
                    DialogResult result = saveFileDialogMap.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        mSavePath = saveFileDialogMap.FileName;
                        Save();
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
            }
            else if (resultMsgBox == DialogResult.No)
            {
                //Just exit
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
           this.Close();
        }
    }

    public class CTileMap
    {
        const uint FLAG_FLIP_X = 0x1;
        const uint FLAG_FLIP_Y = 0x10;
        const uint FLAG_ROTATE_90 = 0x100;
        const uint FLAG_ROTATE_180 = 0x1000;
        const uint FLAG_ROTATE_270 = 0x10000;

        public UInt16 mtileWidth;
        public UInt16 mtileHeight;
        public UInt16 mnbHTiles;
        public UInt16 mnbVTiles;
        public int[] mtileArray;
        public UInt32[] mtileFlagArray;

        public string mTileSetImagePath;
    }

    public class CAction
    {
        int mAction;
        int []mParam;

        public CAction(int action, int[] param)
        {
            mAction = action;
            mParam = param;
        }
    }
}
