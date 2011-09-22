using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TileMapEditor
{
    public partial class frmTielMapEditor : Form
    {
        Graphics gMapViewerGraphics;
        Bitmap gMapViewerBuffer;

        Graphics gTileSetViewerGraphics;
        Bitmap gTileSetViewerBuffer;

        Color MapViewerBGcolor = new Color();
        Color TileSetViewerBGcolor = new Color();

        CTileMap mTileMap = null;
        Bitmap mTileSetImage = null;
        Bitmap[,] mTileImageArray = null;

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
                }
            }

            mTileMap = new CTileMap();
        }

        private void toolStripButtonNew_Click(object sender, EventArgs e)
        {
            InitAll();
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

                CreateMapViewerBuffers();
            }
        }

        private void buttonBrowseTileSet_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialogTileSet.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                mTileMap.mTileSetImagePath = openFileDialogTileSet.FileName;
                textBoxTileSetName.Text = mTileMap.mTileSetImagePath;
                mTileSetImage = new Bitmap(mTileMap.mTileSetImagePath);
                pictureBoxTileSetViewer.Image = mTileSetImage;

                mTileImageArray = new Bitmap[mTileMap.mnbHTiles, mTileMap.mnbVTiles];

                for (int i = 0; i < mTileMap.mnbHTiles; i++)
                {
                    for (int j = 0; j < mTileMap.mnbVTiles; j++)
                    {
                        Bitmap bmpDst = new Bitmap(mTileMap.mtileWidth, mTileMap.mtileHeight);

                        using (Graphics gfx = Graphics.FromImage(bmpDst))
                        {
                            gfx.DrawImage(pictureBoxTileSetViewer.Image, 0, 0, new Rectangle(i * mTileMap.mtileWidth, j * mTileMap.mtileHeight, mTileMap.mtileWidth, mTileMap.mtileHeight), GraphicsUnit.Pixel);
                        }

                        mTileImageArray[i, j] = bmpDst;
                    }
                }

                CreateTileSetViewerBuffers();
            }
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
                gMapViewerGraphics.Clear(MapViewerBGcolor);
            }

            if (gTileSetViewerGraphics != null)
            {
                gTileSetViewerGraphics.Clear(TileSetViewerBGcolor);
            }
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
        public UInt16[,] mtileArray;
        public UInt32[,] mtileFlagArray;

        public string mTileSetImagePath;
    }
}
