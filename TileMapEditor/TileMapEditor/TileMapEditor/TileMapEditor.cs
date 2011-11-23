using System;
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
        static string mExportPath = null;

        static Stack<CAction> mActionUndoStack = new Stack<CAction>();
        static Stack<CAction> mActionRedoStack = new Stack<CAction>();

        //this list contains added / removed in single action
        //ie: from one left-click to release of the click
        static List<CTile> mTileList = new List<CTile>();

        //selected tile position list
        static List<int> mSelectedTileList = new List<int>();
        SolidBrush mSelectionBrush = new SolidBrush(Color.FromArgb(1056964863)); //transparent blue

        static int m_state = CState.STATE_INVALID;
        static int m_prevState = CState.STATE_INVALID;

        const int FLIP_HORIZONDAL = 0;
        const int FLIP_VERTICAL = FLIP_HORIZONDAL + 1;

        public static void SaveAction(int action, List<CTile> tileList)
        {
            CAction actionObj = new CAction(action, tileList);
            mActionUndoStack.Push(actionObj);
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

        public static void UnDoAction()
        {
            if (mActionUndoStack.Count > 0)
            {
                CAction action = mActionUndoStack.Pop();
                mActionRedoStack.Push(action);

                switch (action.mAction)
                {
                    case CAction.ACTION_ADD_TILES:
                        {
                            foreach (CTile tile in action.mTileList)
                            {
                                mTileMap.mtileArray[tile.mPos] = tile.mCurrentTileId;
                            }
                        }
                        break;
                }
            }

        }

        public static void ReDoAction()
        {
            if (mActionRedoStack.Count > 0)
            {
                CAction action = mActionRedoStack.Pop();
                mActionUndoStack.Push(action);

                switch (action.mAction)
                {
                    case CAction.ACTION_ADD_TILES:
                        {
                            foreach (CTile tile in action.mTileList)
                            {
                                mTileMap.mtileArray[tile.mPos] = tile.mNewTileId;
                            }
                        }
                        break;
                }
            }
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
                    //set default flag to 0
                    mTileMap.mtileFlagArray = new UInt32[mTileMap.mnbHTiles * mTileMap.mnbVTiles];

                    for (int i = 0; i < mTileMap.mnbHTiles * mTileMap.mnbVTiles; i++)
                    {
                        mTileMap.mtileArray[i] = -1;
                        mTileMap.mtileFlagArray[i] = 0;
                    }
                }

                CreateMapViewerBuffers();
                CreateTileImages();

                m_state = CState.STATE_ADD_TILES;
            }
        }

        private void textBoxTileWidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            //allow only numeric values
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
                if (m_state != CState.STATE_INVALID)
                {
                    for (int i = 0; i < mTileMap.mnbHTiles * mTileMap.mnbVTiles; i++)
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

                    if (m_state == CState.STATE_SELECT_TILES)
                    {
                        foreach (int pos in mSelectedTileList)
                        {
                            int x = (pos % mTileMap.mnbHTiles) * mTileMap.mtileWidth;
                            int y = (pos / mTileMap.mnbHTiles) * mTileMap.mtileHeight;
                            gMapViewerGraphics.FillRectangle(mSelectionBrush, x, y, mTileMap.mtileWidth, mTileMap.mtileHeight);
                        }
                    }

                    //draw current selected tile below current mouse pos
                    if (m_state != CState.STATE_REMOVE_TILES)
                    {
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
                if (m_state == CState.STATE_ADD_TILES)
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

        private void toolStripButtonShowGrid_Click(object sender, EventArgs e)
        {
            mbShowGridOnMapViewer = !mbShowGridOnMapViewer; 
        }

        private void pictureBoxTileSetViewer_MouseDown(object sender, MouseEventArgs e)
        {
            if (m_state == CState.STATE_ADD_TILES)
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
                AssignTile(mSelectedTileId, e.X, e.Y);
            }
            else if (e.Button == MouseButtons.Right)
            {
                mSelectedTileId = -1;
            }
        }

        private void pictureBoxMapViewer_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //List<CTile> tileList = new List<CTile>();
                //tileList = mTileList;
                SaveAction(CAction.ACTION_ADD_TILES, mTileList);
                mTileList.Clear();
                m_bLeftMouseDownMapViewer = false;

            }
        }

        private void pictureBoxMapViewer_MouseMove(object sender, MouseEventArgs e)
        {
            labelMapMouseX.Text = "Mouse X : " + e.X;
            labelMapMouseY.Text = "Mouse Y : " + e.Y;

            if (m_bLeftMouseDownMapViewer)
            {
                AssignTile(mSelectedTileId, e.X, e.Y);
            }

            mMapViewerMouseX = e.X;
            mMapViewerMouseY = e.Y;
        }

        private static void AssignTile(int id, int x, int y)
        {
            int h = x / mTileMap.mtileWidth;
            int v = y / mTileMap.mtileHeight;
            int pos = (mTileMap.mnbHTiles * v) + h;

            if(m_state == CState.STATE_SELECT_TILES)
            {
                bool found = false;
                foreach (int storedPos in mSelectedTileList)
                {
                    if (storedPos == pos)
                    {
                        found = true;
                    }
                }
                if (!found)
                {
                    mSelectedTileList.Add(pos);
                }
            }
            else
            {
                //remove tile means adding a -1 tile id
                if(m_state == CState.STATE_REMOVE_TILES)
                {
                    mSelectedTileId = -1;
                }

                if (pos >= 0 && pos < (mTileMap.mnbHTiles * mTileMap.mnbVTiles))
                {
                    bool found = false;
                    foreach (CTile t in mTileList)
                    {
                        if (t.mPos == pos)
                        {
                            found = true;
                        }
                    }
                    if (!found)
                    {
                        CTile tile = new CTile();
                        tile.mPos = pos;
                        tile.mCurrentTileId = mTileMap.mtileArray[pos];
                        //tile.mFlag = mTileMap.mtileFlagArray[pos];
                        tile.mNewTileId = mSelectedTileId;
                        mTileList.Add(tile);
                        mTileMap.mtileArray[pos] = mSelectedTileId;
                    }
                }
            }
        }

        private static void FlipTile(int flip)
        {
            if (flip == FLIP_HORIZONDAL)
            {

            }
            else
            {

            }
        }

        ///////////////////////////////////////////////////////////////////////////////
        //  HEADER              (4 bytes - Integer)
        //  FLAG                (4 bytes - Integer)
        //  FILE SIZE           (4 bytes - Integer)
        //  IMAGE NAME LENGTH   (4 bytes - Integer)
        //  IMAGE NAME          (Byte array)
        //  IMAGE WIDTH         (2 bytes - short)
        //  IMAGE HEIGHT        (2 bytes - short)
        //  TILE WIDTH          (2 bytes - short)
        //  TILE HEIGHT         (2 bytes - short)
        //  MAP WIDTH(In tiles) (2 bytes - short)
        //  MAP HEIGHT(In tiles)(2 bytes - short)
        //  MAP DATA            (4 bytes - Integer array)
        ///////////////////////////////////////////////////////////////////////////////
        
        private void ExportTileMap()
        {
            DialogResult result = saveFileDialogExport.ShowDialog();
            if (result == DialogResult.OK)
            {
                mExportPath = saveFileDialogExport.FileName;
                int extStart = mExportPath.IndexOf(".");
                string path = mExportPath.Substring(0, extStart);

                // open file for header and exported data
                TextWriter header_h = new StreamWriter(path + ".h");
                FileStream stream = new FileStream(path + ".btsm", FileMode.Create);
                BinaryWriter exportWriter = new BinaryWriter(stream);

                string imageName = mTileMap.mTileSetImagePath;

                // parse only name of the file
                int nameStart = 0;
                int nameLength = 0;
                for (int i = imageName.Length - 1; i >= 0; i--)
                {
                    if (imageName[i] == '\\')
                    {
                        nameStart = i + 1;
                        nameLength = imageName.Length - 1 - i;
                        break;
                    }
                }
                imageName = imageName.Substring(nameStart, nameLength);

                extStart = imageName.IndexOf(".");
                string fileName = imageName.Substring(0, extStart);

                int size = 0;   //total file size
                exportWriter.Write(0xFF);
                size += 4;  //Header (Future)

                exportWriter.Write(0xFF);
                size += 4;  //Flags (Future)

                exportWriter.Write(0x00);
                size += 4;  //Total size (Will be written @ the end)

                exportWriter.Write(imageName.Length);
                size += 4;  //image path length

                //Size of the file name is getting written with image name: Thats how exporter works
                //So here is the fix : write it letter by letter
                for (int i = 0; i < imageName.Length; i++)
                {
                    exportWriter.Write(imageName[i]);
                }
                size += (imageName.Length);

                exportWriter.Write(mTileSetImage.Width);
                size += 2;  //Image width

                exportWriter.Write(mTileSetImage.Height);
                size += 2;  //Image height

                exportWriter.Write(mTileMap.mtileWidth);
                size += 2;  //Tile width

                exportWriter.Write(mTileMap.mtileHeight);
                size += 2;  //Tile height

                exportWriter.Write(mTileMap.mnbHTiles);
                size += 2;  //Map width

                exportWriter.Write(mTileMap.mnbVTiles);
                size += 2;  //Map height

                for (int i = 0; i < mTileMap.mtileArray.Length; i++)
                {
                    exportWriter.Write(mTileMap.mtileArray[i]);
                    size += 4;   //tile ids

                    //exportWriter.Write(mTileMap.mtileFlagArray[i]);
                    //size += 4;   //tile flags
                }

                header_h.WriteLine("#ifndef _" + fileName.ToUpper() + "_H_");
                header_h.WriteLine("#define _" + fileName.ToUpper() + "_H_");
                header_h.WriteLine("#define " + fileName.ToUpper() + "_IMAGE" + "            " + "\"" + imageName + "\"");

                exportWriter.Seek(8, SeekOrigin.Begin); //skip header anf flag
                exportWriter.Write(size);
                exportWriter.Close();

                //close header stream
                header_h.WriteLine("#endif //HEADER_H");
                header_h.Close();

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

        private void toolStripButtonExport_Click(object sender, EventArgs e)
        {
            //Export
            ExportTileMap();
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Export
            ExportTileMap();
        }

        private void toolStripButtonUndo_Click(object sender, EventArgs e)
        {
            //undo
            UnDoAction();
        }

        private void unDoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //undo
            UnDoAction();
        }

        private void toolStripButtonRedo_Click(object sender, EventArgs e)
        {
            //redo
            ReDoAction();
        }

        private void redoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //redo
            ReDoAction();
        }

        private void toolStripButtonCut_Click(object sender, EventArgs e)
        {
            //cut
        }

        private void toolStripButtonCopy_Click(object sender, EventArgs e)
        {
            //copy
        }

        private void toolStripButtonPaste_Click(object sender, EventArgs e)
        {
            //paste
        }

        private void toolStripButtonErase_Click(object sender, EventArgs e)
        {
            //erase
            int state = m_state;
            if(m_state == CState.STATE_REMOVE_TILES)
            {
                m_state = m_prevState;
            }
            else
            {
                m_state = CState.STATE_REMOVE_TILES;
            }
            m_prevState = state;
        }

        private void eraseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //erase
            int state = m_state;
            if (m_state == CState.STATE_REMOVE_TILES)
            {
                m_state = m_prevState;
            }
            else
            {
                m_state = CState.STATE_REMOVE_TILES;
            }
            m_prevState = state;
        }

        private void toolStripButtonFlipX_Click(object sender, EventArgs e)
        {
            //hflip
            FlipTile(FLIP_HORIZONDAL);
        }

        private void flipHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //hflip
            FlipTile(FLIP_HORIZONDAL);
        }

        private void toolStripButtonFlipY_Click(object sender, EventArgs e)
        {
            //vflip
            FlipTile(FLIP_VERTICAL);
        }

        private void flipVerticallyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //vflip
            FlipTile(FLIP_VERTICAL);
        }

        private void toolStripButtonRotateCW_Click(object sender, EventArgs e)
        {
            //rotate cw
        }

        private void toolStripButtonRotateCCW_Click(object sender, EventArgs e)
        {
            //rotate ccw
        }

        private void toolStripButtonFill_Click(object sender, EventArgs e)
        {
            //fill
        }

        private void toolStripButtonPointer_Click(object sender, EventArgs e)
        {
            //select
            int state = m_state;
            if (m_state == CState.STATE_SELECT_TILES)
            {
                m_state = m_prevState;
            }
            else
            {
                m_state = CState.STATE_SELECT_TILES;
            }
            m_prevState = state;
        }

        private void selectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //select
            int state = m_state;
            if (m_state == CState.STATE_SELECT_TILES)
            {
                m_state = m_prevState;
                //clear selected tiles
                mSelectedTileList.Clear();
            }
            else
            {
                m_state = CState.STATE_SELECT_TILES;
            }
            m_prevState = state;
        }

        private void toolStripButtonPicker_Click(object sender, EventArgs e)
        {
            //pick
        }
    }

    public class CTile
    {
        public int mPos;
        public UInt32 mFlag;
        public int mCurrentTileId;
        public int mNewTileId;
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
        //Action list
        public const int ACTION_ADD_TILES = 0;
        public const int ACTION_ROTATE_TILES = ACTION_ADD_TILES + 1;
        public const int ACTION_FLIP_H_TILES = ACTION_ROTATE_TILES + 1;
        public const int ACTION_FLIP_V_TILES = ACTION_FLIP_H_TILES + 1;

        public int mAction;
        public List<CTile> mTileList;

        public CAction(int action, List<CTile> tileList)
        {
            mAction = action;
            mTileList = new List<CTile>();
            //copy the list content
            mTileList.AddRange(tileList);
        }
    }

    public class CState
    {
        public const int STATE_INVALID = 0;
        public const int STATE_ADD_TILES = STATE_INVALID + 1;
        public const int STATE_REMOVE_TILES = STATE_ADD_TILES + 1;
        public const int STATE_SELECT_TILES = STATE_REMOVE_TILES + 1;
        public const int STATE_PICK_TILE = STATE_SELECT_TILES + 1;
    }
}
