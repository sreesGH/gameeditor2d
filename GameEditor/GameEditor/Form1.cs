using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GameEditor
{
    public partial class Form1 : Form
    {
        enum ViewerState
        {
            MODULE_EDITOR = 0,
            FRAME_EDITOR,
            ANIMATION_EDITOR
        };
        byte m_state;

        //Viewer settings
        Graphics gViewerGraphics;
        Bitmap gViewerBuffer;
        int pbViewerWidth = 800;
        int pbViewerHeight = 480;
        Color pbViewerBGcolor = Color.White;

        SolidBrush gBrush;
        Pen gPen;

        //Image
        Bitmap m_Image;
        bool m_bImageLoaded = false;
        string m_ImagePath = null;

        int m_mouseX = 0;
        int m_mouseY = 0;

        //Module
        //List<CModule> mListAllModules;
        short m_nModules = 0;
        short m_moduleID = 0;
        Rectangle m_moduleRect;
        Image m_ModuleImage;
        //List<Image> m_moduleImageList = new List<Image>();

        //Actions
        bool m_blmbDown = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void timerUpdate_Tick(object sender, EventArgs e)
        {
            pbViewer.Refresh();
            UpdateViewer();
            DrawViewer();
        }

        private void UpdateViewer()
        {
            switch ((ViewerState)m_state)
            {
                case ViewerState.MODULE_EDITOR:
                    {
                        break;
                    }
            }
        }

        private void DrawViewer()
        {
            //Clear it
            gViewerGraphics.Clear(pbViewerBGcolor);

            switch((ViewerState)m_state)
            {
                case ViewerState.MODULE_EDITOR:
                    {
                        //Draw Image
                        if (m_bImageLoaded)
                        {
                            gViewerGraphics.DrawImage(m_Image, 0, 0);
                        }

                        //Draw  module bounding boxes
                        gPen.Width = 1;
                        gPen.Color = Color.Purple;
                        gPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                        Rectangle rect = new Rectangle(0, 0, 1, 1);
                        if (chkboxShowModule.Checked)
                        {
                            if (m_nModules > 0)
                            {
                                for (int i = 0; i < dgViewModule.RowCount; i++)
                                {
                                    rect.X = Convert.ToInt32(dgViewModule.Rows[i].Cells[1].Value);
                                    rect.Y = Convert.ToInt32(dgViewModule.Rows[i].Cells[2].Value);
                                    rect.Width = Convert.ToInt32(dgViewModule.Rows[i].Cells[3].Value);
                                    rect.Height = Convert.ToInt32(dgViewModule.Rows[i].Cells[4].Value);
                                    gViewerGraphics.DrawRectangle(gPen, rect);
                                }
                            }
                        }

                        //Draw current module
                        gPen.Color = Color.Maroon;
                        if (m_blmbDown && m_bImageLoaded)
                        {
                            gViewerGraphics.DrawRectangle(gPen, m_moduleRect);
                        }

                        break;
                    }
            }

            //Draw Grid
            gPen.Width = 1;
            gPen.Color = Color.Gray;
            gPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            if (chkboxShowGrid.Checked)
            {
                int loopCount = (pbViewerWidth) / (EDITOR_CONSTANTS.VIEWER_GRID_WIDTH * 2);
                for (int j = 0; j < loopCount; j++)
                {
                    gViewerGraphics.DrawLine(gPen, 0, ((pbViewerHeight) >> 1) + (j * EDITOR_CONSTANTS.VIEWER_GRID_WIDTH), pbViewerWidth, ((pbViewerHeight) >> 1) + (j * EDITOR_CONSTANTS.VIEWER_GRID_WIDTH));
                    gViewerGraphics.DrawLine(gPen, 0, ((pbViewerHeight) >> 1) - (j * EDITOR_CONSTANTS.VIEWER_GRID_WIDTH), pbViewerWidth, ((pbViewerHeight) >> 1) - (j * EDITOR_CONSTANTS.VIEWER_GRID_WIDTH));
                    gViewerGraphics.DrawLine(gPen, ((pbViewerWidth) >> 1) + (j * EDITOR_CONSTANTS.VIEWER_GRID_WIDTH), 0, ((pbViewerWidth) >> 1) + (j * EDITOR_CONSTANTS.VIEWER_GRID_WIDTH), (pbViewerHeight));
                    gViewerGraphics.DrawLine(gPen, ((pbViewerWidth) >> 1) - (j * EDITOR_CONSTANTS.VIEWER_GRID_WIDTH), 0, ((pbViewerWidth) >> 1) - (j * EDITOR_CONSTANTS.VIEWER_GRID_WIDTH), (pbViewerHeight));
                }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gViewerBuffer = new Bitmap(pbViewerWidth, pbViewerHeight);
            gViewerGraphics = Graphics.FromImage(gViewerBuffer);
            pbViewer.Image = gViewerBuffer;

            gBrush = new SolidBrush(Color.Blue);
            gPen = new Pen(Color.Blue, 1);

            m_state = (byte)ViewerState.MODULE_EDITOR;

            timerUpdate.Enabled = true;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            pbViewerWidth = pbViewer.Width;
            pbViewerHeight = pbViewer.Height;

            if (pbViewerWidth <= 0 || pbViewerHeight <= 0) return;

            gViewerBuffer.Dispose();
            gViewerGraphics.Dispose();
            gViewerBuffer = new Bitmap(pbViewerWidth, pbViewerHeight);
            gViewerGraphics = Graphics.FromImage(gViewerBuffer);
            pbViewer.Image = gViewerBuffer;
        }

        private void pnlViewerBgColor_MouseClick(object sender, MouseEventArgs e)
        {
            if (clrDlg.ShowDialog() != DialogResult.Cancel)
            {
                pbViewerBGcolor = clrDlg.Color;
                pnlViewerBgColor.BackColor = clrDlg.Color;
            }
        }

        private void openFileDialogImage_FileOk(object sender, CancelEventArgs e)
        {
            m_Image = new Bitmap(openFileDialogImage.OpenFile());
            m_ImagePath = openFileDialogImage.FileName;
            txtboxImageName.Text = m_ImagePath;
            lblImageWidth.Text = "Width: " + m_Image.Width;
            lblImageHeight.Text = "Height: " + m_Image.Height;
            lblImageBpp.Text = "Bpp: " + (Image.GetPixelFormatSize(m_Image.PixelFormat) / 8);
            lblImageDpi.Text = "Dpi: " + m_Image.HorizontalResolution;
            m_bImageLoaded = true;
        }

        private void btnImageLoad_Click(object sender, EventArgs e)
        {
            openFileDialogImage.ShowDialog();
        }

        private void pbViewer_MouseMove(object sender, MouseEventArgs e)
        {
            m_mouseX = e.X;
            m_mouseY = e.Y;
            lblMouseX.Text = "Mouse X: " + m_mouseX;
            lblMouseY.Text = "Mouse Y: " + m_mouseY;

            switch ((ViewerState)m_state)
            {
                case ViewerState.MODULE_EDITOR:
                    {
                        if (m_blmbDown && m_bImageLoaded)
                        {
                            m_moduleRect.Width = e.X - m_moduleRect.X;
                            m_moduleRect.Height = e.Y - m_moduleRect.Y;
                        }

                        if (chkboxShowModule.Checked)
                        {
                            for (int i = 0; i < dgViewModule.RowCount; i++)
                            {
                                if (dgViewModule.Rows[i].Selected)
                                {
                                    int diff = 0;
                                    int x = Convert.ToInt32(dgViewModule.Rows[i].Cells[1].Value);
                                    int y = Convert.ToInt32(dgViewModule.Rows[i].Cells[2].Value);
                                    int width = Convert.ToInt32(dgViewModule.Rows[i].Cells[3].Value);
                                    int height = Convert.ToInt32(dgViewModule.Rows[i].Cells[4].Value);

                                    if (e.X > (x - 3) && e.X < (x + 3) && e.Y > y && e.Y < (y + height))
                                    {
                                        //m_bResizeModule = true;
                                        this.Cursor = Cursors.VSplit;
                                        if (m_blmbDown)
                                        {
                                            diff = e.X - (Convert.ToInt32(dgViewModule.Rows[i].Cells[1].Value));
                                            //lbldbg1.Text = "e.x = " + e.X + "curr x = " + (Convert.ToInt32(dgViewModule.Rows[i].Cells[1].Value)) + "diff = " + diff;
                                            dgViewModule.Rows[i].Cells[1].Value = "" + e.X;
                                            dgViewModule.Rows[i].Cells[3].Value = "" + (Convert.ToInt32(dgViewModule.Rows[i].Cells[3].Value) - diff);
                                        }
                                    }
                                    else if (e.X > (x + width - 3) && e.X < (x + width + 3) && e.Y > y && e.Y < (y + height))
                                    {
                                        //m_bResizeModule = true;
                                        this.Cursor = Cursors.VSplit;
                                        if (m_blmbDown)
                                        {
                                            diff = (Convert.ToInt32(dgViewModule.Rows[i].Cells[1].Value)) + (Convert.ToInt32(dgViewModule.Rows[i].Cells[3].Value)) - e.X;
                                            //lbldbg1.Text = "e.x = " + e.X + "curr x = " + (Convert.ToInt32(dgViewModule.Rows[i].Cells[1].Value)) + "diff = " + diff;
                                            dgViewModule.Rows[i].Cells[3].Value = "" + (Convert.ToInt32(dgViewModule.Rows[i].Cells[3].Value) - diff);
                                        }
                                    }
                                    else if (e.Y > (y - 3) && e.Y < (y + 3) && e.X > x && e.X < (x + width))
                                    {
                                        //m_bResizeModule = true;
                                        this.Cursor = Cursors.HSplit;
                                        if (m_blmbDown)
                                        {
                                            diff = e.Y - (Convert.ToInt32(dgViewModule.Rows[i].Cells[2].Value));
                                            dgViewModule.Rows[i].Cells[2].Value = "" + e.Y;
                                            dgViewModule.Rows[i].Cells[4].Value = "" + (Convert.ToInt32(dgViewModule.Rows[i].Cells[4].Value) - diff);
                                        }

                                    }
                                    else if (e.Y > (y + height - 3) && e.Y < (y + height + 3) && e.X > x && e.X < (x + width))
                                    {
                                        //m_bResizeModule = true;
                                        this.Cursor = Cursors.HSplit;
                                        if (m_blmbDown)
                                        {
                                            diff = (Convert.ToInt32(dgViewModule.Rows[i].Cells[2].Value)) + (Convert.ToInt32(dgViewModule.Rows[i].Cells[4].Value)) - e.Y;
                                            dgViewModule.Rows[i].Cells[4].Value = "" + (Convert.ToInt32(dgViewModule.Rows[i].Cells[4].Value) - diff);
                                        }
                                    }
                                    //TODO: Move the entire rect
                                    /*
                                    else if (e.Y > y && e.Y < (y + height) && e.X > x && e.X < (x + width))
                                    {
                                        //m_bResizeModule = true;
                                        this.Cursor = Cursors.Cross;
                                        if (m_blmbDown)
                                        {
                                            int diffX = (Convert.ToInt32(dgViewModule.Rows[i].Cells[1].Value)) + (Convert.ToInt32(dgViewModule.Rows[i].Cells[3].Value)) - e.X;
                                            int diffY = (Convert.ToInt32(dgViewModule.Rows[i].Cells[2].Value)) + (Convert.ToInt32(dgViewModule.Rows[i].Cells[4].Value)) - e.Y;
                                            dgViewModule.Rows[i].Cells[1].Value = "" + (Convert.ToInt32(dgViewModule.Rows[i].Cells[1].Value) + diff);
                                            dgViewModule.Rows[i].Cells[2].Value = "" + (Convert.ToInt32(dgViewModule.Rows[i].Cells[2].Value) + diff);
                                        }
                                    }
                                    */
                                    else
                                    {
                                        if (!m_blmbDown)
                                        {
                                            //m_bResizeModule = false;
                                            this.Cursor = Cursors.Default;
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_state = (byte)tabControl1.SelectedIndex;
        }

        private void pbViewer_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void pbViewer_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                m_blmbDown = true;
                m_moduleRect.X = e.X;
                m_moduleRect.Y = e.Y;
            }
        }

        private void pbViewer_MouseUp(object sender, MouseEventArgs e)
        {
            if (m_blmbDown && m_bImageLoaded)
            {
                if (e.Button == MouseButtons.Left)
                {
                    m_blmbDown = false;
                    m_moduleRect.Width = e.X - m_moduleRect.X;
                    m_moduleRect.Height = e.Y - m_moduleRect.Y;

                     //ERROR CHECK:
                    if ((m_moduleRect.X + m_moduleRect.Width) < m_Image.Width
                        && (m_moduleRect.Y + m_moduleRect.Height) < m_Image.Height
                        && m_moduleRect.Width > 0
                        && m_moduleRect.Height > 0)
                    {
                        //create row and fill it:      
                        int n = dgViewModule.Rows.Add();
                        //add to image list
                        m_ModuleImage = m_Image.Clone(m_moduleRect, PixelFormat.Format32bppArgb);
                        ImageListmodule.Images.Add(m_ModuleImage, Color.Magenta);
                        listViewModuleList.Items.Add(n.ToString(), n);
                        //ImageListmodule.Insert(n, m_ModuleImage);
                        dgViewModule.Rows[n].Cells[0].Value = "" + m_moduleID;
                        dgViewModule.Rows[n].Cells[1].Value = "" + m_moduleRect.X;
                        dgViewModule.Rows[n].Cells[2].Value = "" + m_moduleRect.Y;
                        dgViewModule.Rows[n].Cells[3].Value = "" + m_moduleRect.Width;
                        dgViewModule.Rows[n].Cells[4].Value = "" + m_moduleRect.Height;
                        dgViewModule.Rows[n].Cells[5].Value = "" + "MODULE_ID_" + m_moduleID;
                        
                        for (int i = 0; i <= n; i++)
                        {
                            dgViewModule.Rows[i].Selected = false;
                        }
                        dgViewModule.Rows[n].Selected = true;
                       
                        m_moduleID++;
                        m_nModules++;
                    }
                }
            }
        }

        private void tabFrame_Click(object sender, EventArgs e)
        {

        }

        private void pnlViewerBgColor_Paint(object sender, PaintEventArgs e)
        {

        }
    }

    static class EDITOR_CONSTANTS
    {
        //public const short MODULE_VIEWER_WIDTH = 800;
        //public const short MODULE_VIEWER_HEIGHT = 600;
        public const short VIEWER_GRID_WIDTH = 8;
    }

    public class CModule
    {
        public short mId;
        public short mX;
        public short mY;
        public short mClipX;
        public short mClipY;
        public short mClipWidth;
        public short mClipHeight;
        public string mDescription;
        public byte mFlag;
    }

    public class CFrame
    {
        public short mId;
        public short mX;
        public short mY;
        public short mFrameRectX;
        public short mFrameRectY;
        public short mFrameRectWidth;
        public short mFrameRectHeight;
        public string mDescription;
        public byte mFlag;
        public List<CModule> mListFrameModules;
    }

    public class CAnimation
    {
        public short mId;
        public string mDescription;
        public List<CFrame> mListAnimationFrames;
    }
}
