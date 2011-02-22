using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace GameEditor
{
    public partial class GameEditor : Form
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

        int m_mouseX = 0;
        int m_mouseY = 0;

        //Image
        Bitmap m_Image;
        bool m_bImageLoaded = false;
        
        static string m_ImagePath = null;
        public static string GetImagePath()
        {
            return m_ImagePath;
        }

        //Gfx File
        public static string m_GfxFilePath = null;
        public static string GetGfxFilePath()
        {
            return m_GfxFilePath;
        }

        //Module
        short m_nModules = 0;
        short m_moduleID = 0;
        Rectangle m_moduleRect;
        Image m_ModuleImage;
        
        List<Image> mListAllModuleImages = new List<Image>();

        //Frame
        short m_nFrames = 0;
        short m_frameID = 0;
        
        int snappedFrameModuleID = -1;

        //Animation
        short m_animationID = 0;
        short m_nAnimations = 0;
        
        short m_animationFrameCounter = 0;
        Int64 m_StartTime = 0;

        int snappedAnimationFrameID = -1;

        static CLoadSaveContainer container = new CLoadSaveContainer();
        public static void SetContainer(CLoadSaveContainer c)
        {
            container = c;
        }

        //Actions
        bool m_blmbDown = false;

        public GameEditor()
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

                case ViewerState.FRAME_EDITOR:
                    {
                        //if (dgViewFrameModule.Rows[j].IsNewRow)
                        if (m_nFrames <= 0) return;
                        int selectedFrame = dgViewFrame.CurrentRow.Index;
                        if (m_nFrames <= selectedFrame) return;
                        DrawFrame(selectedFrame);
                        //for (int i = 0; i < container.mListAllFrames[selectedFrame].mListFrameModules.Count; i++)
                        //{
                        //    gViewerGraphics.DrawImage(mListAllModuleImages[container.mListAllFrames[selectedFrame].mListFrameModules[i].mId], container.mListAllFrames[selectedFrame].mListFrameModules[i].mX, container.mListAllFrames[selectedFrame].mListFrameModules[i].mY);
                        //}

                        //DrawFrame bounding box
                        gPen.Width = 1;
                        gPen.Color = Color.Purple;
                        gPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                        Rectangle rect = new Rectangle(0, 0, 1, 1);
                        if (chkboxShowFrameRect.Checked)
                        {
                            rect.X = (int)container.mListAllFrames[selectedFrame].mFrameRectX;
                            rect.Y = (int)container.mListAllFrames[selectedFrame].mFrameRectY;
                            rect.Width = (int)container.mListAllFrames[selectedFrame].mFrameRectWidth;
                            rect.Height = (int)container.mListAllFrames[selectedFrame].mFrameRectHeight;
                            gViewerGraphics.DrawRectangle(gPen, rect);
                        }
                        break;
                    }
                case ViewerState.ANIMATION_EDITOR:
                    {
                        if (m_nAnimations <= 0) return;
                        int selectedAnimation = dgViewAnimation.CurrentRow.Index;
                        if (m_nAnimations <= selectedAnimation) return;
                        if (container.mListAllAnimations[selectedAnimation].mListAnimationFrames[m_animationFrameCounter].mTime
                            >= (System.Environment.TickCount - m_StartTime))
                        {
                            m_StartTime = System.Environment.TickCount;
                            m_animationFrameCounter++;
                        }
                        if (chkboxLoopAnim.Checked)
                        {
                            if (m_animationFrameCounter >= container.mListAllAnimations[selectedAnimation].mListAnimationFrames.Count)
                            {
                                m_animationFrameCounter = 0;
                            }
                        }
                        else
                        {
                            if (m_animationFrameCounter >= container.mListAllAnimations[selectedAnimation].mListAnimationFrames.Count)
                            {
                                m_animationFrameCounter = (short)(container.mListAllAnimations[selectedAnimation].mListAnimationFrames.Count - 1);
                            }
                        }
                        DrawAnimationFrame(selectedAnimation, m_animationFrameCounter);

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

        private void DrawFrame(int index)
        {
            for (int i = 0; i < container.mListAllFrames[index].mListFrameModules.Count; i++)
            {
                gViewerGraphics.DrawImage(mListAllModuleImages[container.mListAllFrames[index].mListFrameModules[i].mId], container.mListAllFrames[index].mListFrameModules[i].mX, container.mListAllFrames[index].mListFrameModules[i].mY);
            }
        }

        private void DrawAnimationFrame(int selectedAnimation, int index)
        {
            int frameX = container.mListAllAnimations[selectedAnimation].mListAnimationFrames[index].mX;
            int frameY = container.mListAllAnimations[selectedAnimation].mListAnimationFrames[index].mY;

            for (int i = 0; i < container.mListAllAnimations[selectedAnimation].mListAnimationFrames[index].mListFrameModules.Count; i++)
            {
                gViewerGraphics.DrawImage(mListAllModuleImages[container.mListAllAnimations[selectedAnimation].mListAnimationFrames[index].mListFrameModules[i].mId],
                                        container.mListAllAnimations[selectedAnimation].mListAnimationFrames[index].mListFrameModules[i].mX + frameX,
                                        container.mListAllAnimations[selectedAnimation].mListAnimationFrames[index].mListFrameModules[i].mY + frameY);
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
            if(m_GfxFilePath != null)
            {
                LoadAssociatedFile();
            }
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
            //openFileDialogImage.OpenFile();
            LoadImage(openFileDialogImage.FileName);
            container.m_ImageProperty.mName = m_ImagePath;
            container.m_ImageProperty.mWidth = (short)m_Image.Width;
            container.m_ImageProperty.mHeight = (short)m_Image.Height;
            container.m_ImageProperty.mBpp = (short)(Image.GetPixelFormatSize(m_Image.PixelFormat) / 8);
            m_bImageLoaded = true;
        }

        private void LoadImage(string path)
        {
            if (path.IndexOf(".tga") != -1)
            {
                CTGALoader loader = new CTGALoader();
                loader.Load(path);

                int imageWidth = loader.GetWidth();
                int imageHeight = loader.GetHeight();
                int bpp = loader.GetBPP() / 8;
                bool bRGB = loader.IsRGB();
                byte[] imageData = loader.GetImg();
                bool bFlipImg = loader.IsFlipNeeded();

                m_Image = new Bitmap(imageWidth, imageHeight);
                Color color = Color.FromArgb(255, 255, 0, 255);

                for (int i = 0; i < imageHeight; i++)
                {
                    for (int j = 0; j < imageWidth; j++)
                    {
                        if (bpp == 4)
                        {
                            if (bRGB)
                            {
                                //swap BGR to RGB here
                                color = Color.FromArgb(imageData[(i * bpp * imageWidth) + (j * bpp) + 3],
                                                    imageData[(i * bpp * imageWidth) + (j * bpp) + 2],
                                                    imageData[(i * bpp * imageWidth) + (j * bpp) + 1],
                                                    imageData[(i * bpp * imageWidth) + (j * bpp) + 0]);
                            }
                            else
                            {
                                color = Color.FromArgb(imageData[(i * bpp * imageWidth) + (j * bpp) + 3],
                                                    imageData[(i * bpp * imageWidth) + (j * bpp) + 0],
                                                    imageData[(i * bpp * imageWidth) + (j * bpp) + 1],
                                                    imageData[(i * bpp * imageWidth) + (j * bpp) + 2]);
                            }
                        }
                        else if (bpp == 3)
                        {
                            if (bRGB)
                            {
                                //swap BGR to RGB here
                                color = Color.FromArgb(255,
                                                    imageData[(i * bpp * imageWidth) + (j * bpp) + 2],
                                                    imageData[(i * bpp * imageWidth) + (j * bpp) + 1],
                                                    imageData[(i * bpp * imageWidth) + (j * bpp) + 0]);
                            }
                            else
                            {
                                color = Color.FromArgb(255,
                                                    imageData[(i * bpp * imageWidth) + (j * bpp) + 0],
                                                    imageData[(i * bpp * imageWidth) + (j * bpp) + 1],
                                                    imageData[(i * bpp * imageWidth) + (j * bpp) + 2]);
                            }
                        }
                        if (bFlipImg)
                        {
                            m_Image.SetPixel(i, j , color);
                        }
                        else
                        {
                            m_Image.SetPixel(j, (imageHeight - 1 - i), color);
                        }
                    }
                }
            }
            else    // png / bmp
            {
                m_Image = new Bitmap(path);
            }
         
            m_ImagePath = path;
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
            lbldebug.Text = "DBG: " + snappedFrameModuleID;
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

                case ViewerState.FRAME_EDITOR:
                    {
                        if (m_blmbDown)
                        {
                            if (m_nFrames <= 0) return;
                            if (snappedFrameModuleID == -1) return;
                            int selectedFrame = dgViewFrame.CurrentRow.Index;
                            if (m_nFrames <= selectedFrame) return;

                            int diffX = e.X - container.mListAllFrames[selectedFrame].mListFrameModules[snappedFrameModuleID].mX;
                            int diffY = e.Y - container.mListAllFrames[selectedFrame].mListFrameModules[snappedFrameModuleID].mY;

                            container.mListAllFrames[selectedFrame].mListFrameModules[snappedFrameModuleID].mX += (short)diffX;
                            container.mListAllFrames[selectedFrame].mListFrameModules[snappedFrameModuleID].mY += (short)diffY;

                            UpdateFrameRect(selectedFrame);

                            //Now update corresponding data grid too

                        }
                        break;
                    }

                case ViewerState.ANIMATION_EDITOR:
                    {
                        if (m_blmbDown)
                        {
                            if (m_nAnimations <= 0) return;
                            if (snappedAnimationFrameID == -1) return;
                            int selectedAnimation = dgViewAnimation.CurrentRow.Index;
                            if (m_nAnimations <= selectedAnimation) return;

                            int diffX = e.X - (container.mListAllAnimations[selectedAnimation].mListAnimationFrames[snappedAnimationFrameID].mFrameRectX + container.mListAllAnimations[selectedAnimation].mListAnimationFrames[snappedAnimationFrameID].mX);
                            int diffY = e.Y - (container.mListAllAnimations[selectedAnimation].mListAnimationFrames[snappedAnimationFrameID].mFrameRectY + container.mListAllAnimations[selectedAnimation].mListAnimationFrames[snappedAnimationFrameID].mY);

                            container.mListAllAnimations[selectedAnimation].mListAnimationFrames[snappedAnimationFrameID].mX += (short)diffX;
                            container.mListAllAnimations[selectedAnimation].mListAnimationFrames[snappedAnimationFrameID].mY += (short)diffY;

                            //Now update corresponding data grid too

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
            m_blmbDown = true;
            switch ((ViewerState)m_state)
            {
                case ViewerState.MODULE_EDITOR:
                    {
                        if (e.Button == MouseButtons.Left)
                        {
                            m_moduleRect.X = e.X;
                            m_moduleRect.Y = e.Y;
                        }
                        break;
                    }
                case ViewerState.FRAME_EDITOR:
                    {
                        if (m_nFrames <= 0) return;
                        int selectedFrame = dgViewFrame.CurrentRow.Index;
                        if (m_nFrames <= selectedFrame) return;

                        //Do it reverse order to get the top one selected first
                        for (int i = container.mListAllFrames[selectedFrame].mListFrameModules.Count - 1; i >= 0; i--)
                        {
                            if (e.X >= container.mListAllFrames[selectedFrame].mListFrameModules[i].mX
                                && e.X <= (container.mListAllFrames[selectedFrame].mListFrameModules[i].mX + container.mListAllFrames[selectedFrame].mListFrameModules[i].mClipWidth)
                                && e.Y >= container.mListAllFrames[selectedFrame].mListFrameModules[i].mY
                                && e.Y <= (container.mListAllFrames[selectedFrame].mListFrameModules[i].mY + container.mListAllFrames[selectedFrame].mListFrameModules[i].mClipHeight)
                                )
                            {
                                snappedFrameModuleID = i;
                                this.Cursor = Cursors.Hand;
                                break;
                            }
                        }
                        break;
                    }
                case ViewerState.ANIMATION_EDITOR:
                    {
                        if (m_nAnimations <= 0) return;
                        int selectedAnimation = dgViewAnimation.CurrentRow.Index;
                        if (m_nAnimations <= selectedAnimation) return;

                        int selectedAnimationFrame = dgViewAnimationFrame.CurrentRow.Index;
                        if (selectedAnimationFrame >= container.mListAllAnimations[selectedAnimation].mListAnimationFrames.Count)
                        {
                            return;
                        }
                        else
                        {
                            snappedAnimationFrameID = selectedAnimationFrame;
                            this.Cursor = Cursors.Hand;
                        }

                        //Do it reverse order to get the top one selected first
                        //for (int i = container.mListAllAnimations[selectedAnimation].mListAnimationFrames.Count - 1; i >= 0; i--)
                        //for (int i = 0; i < container.mListAllAnimations[selectedAnimation].mListAnimationFrames.Count; i--)
                        //{
                          //  if (e.X >= container.mListAllAnimations[selectedAnimation].mListAnimationFrames[i].mFrameRectX + container.mListAllAnimations[selectedAnimation].mListAnimationFrames[i].mX
                            //    && e.X <= (container.mListAllAnimations[selectedAnimation].mListAnimationFrames[i].mFrameRectX + container.mListAllAnimations[selectedAnimation].mListAnimationFrames[i].mFrameRectWidth) + container.mListAllAnimations[selectedAnimation].mListAnimationFrames[i].mX
                              //  && e.Y >= container.mListAllAnimations[selectedAnimation].mListAnimationFrames[i].mFrameRectY + +container.mListAllAnimations[selectedAnimation].mListAnimationFrames[i].mY
                                //&& e.Y <= (container.mListAllAnimations[selectedAnimation].mListAnimationFrames[i].mFrameRectY + container.mListAllAnimations[selectedAnimation].mListAnimationFrames[i].mFrameRectHeight) + +container.mListAllAnimations[selectedAnimation].mListAnimationFrames[i].mY
                                //)
                            //{
                              //  snappedAnimationFrameID = i;
                               // this.Cursor = Cursors.Hand;
                                //break;
                            //}
                        //}
                        break;
                    }
            }
        }

        private void pbViewer_MouseUp(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Default;
            switch ((ViewerState)m_state)
            {
                case ViewerState.MODULE_EDITOR:
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
                                    //For list viewer
                                    ImageListmodule.Images.Add(m_ModuleImage, Color.Magenta);
                                    listViewModuleList.Items.Add(n.ToString(), n);
                                    //ImageListmodule.Insert(n, m_ModuleImage);
                                    
                                    //For drawing in the viewer
                                    mListAllModuleImages.Add(m_ModuleImage);

                                    dgViewModule.Rows[n].Cells[0].Value = "" + m_moduleID;
                                    dgViewModule.Rows[n].Cells[1].Value = "" + m_moduleRect.X;
                                    dgViewModule.Rows[n].Cells[2].Value = "" + m_moduleRect.Y;
                                    dgViewModule.Rows[n].Cells[3].Value = "" + m_moduleRect.Width;
                                    dgViewModule.Rows[n].Cells[4].Value = "" + m_moduleRect.Height;
                                    dgViewModule.Rows[n].Cells[5].Value = "" + "MODULE_ID_" + m_moduleID;

                                    CModule module = new CModule();
                                    module.mId = m_moduleID;
                                    module.mX = 0;
                                    module.mY = 0;
                                    module.mClipX = (short)m_moduleRect.X;
                                    module.mClipY = (short)m_moduleRect.Y;
                                    module.mClipWidth = (short)m_moduleRect.Width;
                                    module.mClipHeight = (short)m_moduleRect.Height;
                                    module.mDescription = "MODULE_ID_" + m_moduleID;
                                    module.mFlag = 0;

                                    container.mListAllModules.Add(module);

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
                        break;
                    }

                case ViewerState.FRAME_EDITOR:
                    {
                        if (e.Button == MouseButtons.Left)
                        {
                            snappedFrameModuleID = -1;
                            m_blmbDown = false;
                        }
                        break;
                    }

                case ViewerState.ANIMATION_EDITOR:
                    {
                        if (e.Button == MouseButtons.Left)
                        {
                            snappedAnimationFrameID = -1;
                            m_blmbDown = false;
                        }
                        break;
                    }
            }
        }

        private void tabFrame_Click(object sender, EventArgs e)
        {

        }

        private void pnlViewerBgColor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listViewModuleList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListView.SelectedListViewItemCollection b = this.listViewModuleList.SelectedItems;
            short id = -1;
            foreach (ListViewItem item in b)
            {
                id = (short)item.Index;
            }

            switch ((ViewerState)m_state)
            {
                case ViewerState.FRAME_EDITOR:
                    {
                        CModule module = new CModule();
                        module.mX = 0;
                        module.mY = 0;
                        module.mClipWidth = (short)Convert.ToInt32(dgViewModule.Rows[id].Cells[3].Value);
                        module.mClipHeight = (short)Convert.ToInt32(dgViewModule.Rows[id].Cells[4].Value);
                        module.mFlag = 0;
                        module.mId = id;
                        int selectedFrame = dgViewFrame.CurrentRow.Index;
                        container.mListAllFrames[selectedFrame].mListFrameModules.Add(module);
                        UpdateFrameRect(selectedFrame);
                        break;
                    }
            }
        }

        private void UpdateFrameRect(int selectedFrame)
        {
            for (int i = 0; i < container.mListAllFrames[selectedFrame].mListFrameModules.Count; i++)
            {
                container.mListAllFrames[selectedFrame].mFrameRectX = Math.Min(container.mListAllFrames[selectedFrame].mFrameRectX, container.mListAllFrames[selectedFrame].mListFrameModules[i].mX);
                container.mListAllFrames[selectedFrame].mFrameRectY = Math.Min(container.mListAllFrames[selectedFrame].mFrameRectY, container.mListAllFrames[selectedFrame].mListFrameModules[i].mY);
                container.mListAllFrames[selectedFrame].mFrameRectWidth = Math.Max(container.mListAllFrames[selectedFrame].mFrameRectWidth, (short)(container.mListAllFrames[selectedFrame].mListFrameModules[i].mX + container.mListAllFrames[selectedFrame].mListFrameModules[i].mClipWidth));
                container.mListAllFrames[selectedFrame].mFrameRectHeight = Math.Max(container.mListAllFrames[selectedFrame].mFrameRectHeight, (short)(container.mListAllFrames[selectedFrame].mListFrameModules[i].mY + container.mListAllFrames[selectedFrame].mListFrameModules[i].mClipHeight));
            }
        }

        private void dgViewFrame_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //create row and fill it:      
            int n = dgViewFrame.Rows.Add();
            dgViewFrame.Rows[n].Cells[0].Value = "" + m_frameID;
            dgViewFrame.Rows[n].Cells[1].Value = "" + "FRAME_ID_" + m_frameID;
            CFrame frame = new CFrame();
            frame.mId = m_frameID;
            frame.mDescription = "" + "FRAME_ID_" + m_frameID;
            container.mListAllFrames.Insert(n, frame);
            m_nFrames++;
            m_frameID++;
        }

        private void dgViewFrame_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStripAnimator.Show(dgViewFrame, new Point(e.X, e.Y));
                return;
            }
            //Clear rows
            for (int j = 0; j < dgViewFrameModule.RowCount; j++)
            {
                if (!dgViewFrameModule.Rows[j].IsNewRow)
                {
                    dgViewFrameModule.Rows.RemoveAt(j);
                }
            }
            
            int selectedFrame = dgViewFrame.CurrentRow.Index;
            if (m_nFrames <= selectedFrame) return;
            
            //Now refresh with new
            for (int i = 0; i < container.mListAllFrames[selectedFrame].mListFrameModules.Count; i++)
            {
                int n = dgViewFrameModule.Rows.Add();
                dgViewFrameModule.Rows[i].Cells[0].Value = "" + container.mListAllFrames[selectedFrame].mListFrameModules[i].mId;
                dgViewFrameModule.Rows[i].Cells[1].Value = "" + container.mListAllFrames[selectedFrame].mListFrameModules[i].mX;
                dgViewFrameModule.Rows[i].Cells[2].Value = "" + container.mListAllFrames[selectedFrame].mListFrameModules[i].mY;
            }
        }

        private void dgViewAnimation_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //create row and fill it:      
            //int n = dgViewAnimation.Rows.Add();
            //dgViewAnimation.Rows[m_animationID].Cells[0].Value = "" + m_animationID;
            //dgViewAnimation.Rows[m_animationID].Cells[1].Value = "" + "ANIMATION_ID_" + m_animationID;
            CAnimation animation = new CAnimation();
            animation.mId = m_animationID;
            container.mListAllAnimations.Insert(m_animationID, animation);
            m_nAnimations++;
            m_animationID++;

            UpdateAnimationDataGrid();
        }

        private void contextMenuStripAnimator_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void contextMenuStripAnimator_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void animateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CAnimation animation = new CAnimation();
            animation.mId = m_animationID;

            container.mListAllAnimations.Insert(m_animationID, animation);

            for (int i = 0; i < dgViewFrame.RowCount; i++)
            {
                if (dgViewFrame.Rows[i].Selected)
                {
                    CFrame frame = new CFrame();
                    frame.mId = container.mListAllFrames[i].mId;
                    frame.mX = 0;
                    frame.mY = 0;
                    frame.mFrameRectX = container.mListAllFrames[i].mFrameRectX;
                    frame.mFrameRectY = container.mListAllFrames[i].mFrameRectY;
                    frame.mFrameRectWidth = container.mListAllFrames[i].mFrameRectWidth;
                    frame.mFrameRectHeight = container.mListAllFrames[i].mFrameRectHeight;
                    frame.mListFrameModules = container.mListAllFrames[i].mListFrameModules;
                    frame.mTime = 1000;
                    container.mListAllAnimations[m_animationID].mListAnimationFrames.Add(frame);
                    
                }
            }

            m_nAnimations++;
            m_animationID++;

            UpdateAnimationDataGrid();
        }

        private void dgViewModule_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStripFrame.Show(dgViewModule, new Point(e.X, e.Y));
                return;
            }
        }

        private void UpdateAnimationDataGrid()
        {
            //Clear rows
            for (int j = 0; j < dgViewAnimation.RowCount; j++)
            {
                if (!dgViewAnimation.Rows[j].IsNewRow)
                {
                    dgViewAnimation.Rows.RemoveAt(j);
                }
            }
            for (int i = 0; i < container.mListAllAnimations.Count; i++)
            {
                //create row and fill it:      
                int n = dgViewAnimation.Rows.Add();
                dgViewAnimation.Rows[i].Cells[0].Value = "" + container.mListAllAnimations[i].mId;
                dgViewAnimation.Rows[i].Cells[1].Value = "" + "ANIMATION_ID_" + container.mListAllAnimations[i].mId;
                container.mListAllAnimations[i].mDescription = "" + "ANIMATION_ID_" + container.mListAllAnimations[i].mId;
            }
        }

        private void dgViewAnimation_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
           
        }

        private void dgViewAnimation_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void dgViewAnimation_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Clear rows
            for (int j = 0; j < dgViewAnimationFrame.RowCount; j++)
            {
                if (!dgViewAnimationFrame.Rows[j].IsNewRow)
                {
                    dgViewAnimationFrame.Rows.RemoveAt(j);
                }
            }
            int selectedAnimation = dgViewAnimation.CurrentRow.Index;
            if (m_nAnimations <= selectedAnimation) return;

            //Now refresh with new
            for (int i = 0; i < container.mListAllAnimations[selectedAnimation].mListAnimationFrames.Count; i++)
            {
                int n = dgViewAnimationFrame.Rows.Add();
                dgViewAnimationFrame.Rows[i].Cells[0].Value = "" + container.mListAllAnimations[selectedAnimation].mListAnimationFrames[i].mId;
                dgViewAnimationFrame.Rows[i].Cells[1].Value = "" + container.mListAllAnimations[selectedAnimation].mListAnimationFrames[i].mTime;
                dgViewAnimationFrame.Rows[i].Cells[2].Value = "" + container.mListAllAnimations[selectedAnimation].mListAnimationFrames[i].mX;
                dgViewAnimationFrame.Rows[i].Cells[3].Value = "" + container.mListAllAnimations[selectedAnimation].mListAnimationFrames[i].mY;
            }

            //Reset animtaion viewer properties
            m_StartTime = System.Environment.TickCount;
            m_animationFrameCounter = 0;
        }

        private void chkboxLoopAnim_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModuleSave.Save(container);
        }

        private void dgViewAnimationFrame_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            m_animationFrameCounter = (short)dgViewAnimationFrame.CurrentRow.Index;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Open Gfx file 
            openFileDialogGfxFile.ShowDialog();

        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModuleExport.Export(container.m_ImageProperty, container.mListAllModules, container.mListAllFrames, container.mListAllAnimations);
        }

        private void GameEditor_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void GameEditor_DragDrop(object sender, DragEventArgs e)
        {
            Array a = (Array)e.Data.GetData(DataFormats.FileDrop);
            
            if (a.GetValue(0).ToString().IndexOf(".gfx") == -1)
            {
                return;
            }
            else
            {
                m_GfxFilePath = a.GetValue(0).ToString();
            }
            
            LoadAssociatedFile();
        }

        private void openFileDialogGfxFile_FileOk(object sender, CancelEventArgs e)
        {
            // Read Gfx file
            m_GfxFilePath = openFileDialogGfxFile.FileName;
            LoadAssociatedFile();
        }

        public void LoadAssociatedFileByDoubleClicking(string fileName)
        {
            m_GfxFilePath = fileName;
            LoadAssociatedFile();
        }

        private void LoadAssociatedFile()
        {
            ModuleLoad.Load();
            LoadImage(container.m_ImageProperty.mName);

            //Fill module data grid
            for (int i = 0; i < container.mListAllModules.Count; i++)
            {
                int n = dgViewModule.Rows.Add();
                dgViewModule.Rows[n].Cells[0].Value = "" + container.mListAllModules[i].mId;
                dgViewModule.Rows[n].Cells[1].Value = "" + container.mListAllModules[i].mClipX;
                dgViewModule.Rows[n].Cells[2].Value = "" + container.mListAllModules[i].mClipY;
                dgViewModule.Rows[n].Cells[3].Value = "" + container.mListAllModules[i].mClipWidth;
                dgViewModule.Rows[n].Cells[4].Value = "" + container.mListAllModules[i].mClipHeight;
                dgViewModule.Rows[n].Cells[5].Value = "" + container.mListAllModules[i].mDescription;

                m_moduleRect.X = container.mListAllModules[i].mClipX;
                m_moduleRect.Y = container.mListAllModules[i].mClipY;
                m_moduleRect.Width = container.mListAllModules[i].mClipWidth;
                m_moduleRect.Height = container.mListAllModules[i].mClipHeight;

                m_ModuleImage = m_Image.Clone(m_moduleRect, PixelFormat.Format32bppArgb);
                //For list viewer
                ImageListmodule.Images.Add(m_ModuleImage, Color.Magenta);
                listViewModuleList.Items.Add(n.ToString(), n);
                //For drawing in the viewer
                mListAllModuleImages.Add(m_ModuleImage);
            }
            m_nModules = (short)container.mListAllModules.Count;

            //Fill frame data grid
            for (int i = 0; i < container.mListAllFrames.Count; i++)
            {
                int n = dgViewFrame.Rows.Add();
                dgViewFrame.Rows[n].Cells[0].Value = "" + container.mListAllFrames[i].mId;
                dgViewFrame.Rows[n].Cells[1].Value = "" + container.mListAllFrames[i].mDescription;
            }
            m_nFrames = (short)container.mListAllFrames.Count;

            //Fill animation data grid
            for (int i = 0; i < container.mListAllAnimations.Count; i++)
            {
                int n = dgViewAnimation.Rows.Add();
                dgViewAnimation.Rows[n].Cells[0].Value = "" + container.mListAllAnimations[i].mId;
                dgViewAnimation.Rows[n].Cells[1].Value = "" + container.mListAllAnimations[i].mDescription;
            }
            m_nAnimations = (short)container.mListAllAnimations.Count;
        }
    }

    static class EDITOR_CONSTANTS
    {
        //public const short MODULE_VIEWER_WIDTH = 800;
        //public const short MODULE_VIEWER_HEIGHT = 600;
        public const short VIEWER_GRID_WIDTH = 8;
    }

    public class CImage
    {
        public string mName;
        public short mWidth;
        public short mHeight;
        public short mBpp;
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
        public Int64 mTime;
        public List<CModule> mListFrameModules;
        public CFrame()
        {
            mListFrameModules = new List<CModule>();
            mFrameRectX = 0;
            mFrameRectY = 0;
            mFrameRectWidth = 1;
            mFrameRectHeight = 1;
        }
    }

    public class CAnimation
    {
        public short mId;
        public string mDescription;
        public List<CFrame> mListAnimationFrames;
        public CAnimation()
        {
            mListAnimationFrames = new List<CFrame>();
        }
    }

    public class CLoadSaveContainer
    {
        public CImage m_ImageProperty = new CImage();
        public List<CModule> mListAllModules = new List<CModule>();
        public List<CFrame> mListAllFrames = new List<CFrame>();
        public List<CAnimation> mListAllAnimations = new List<CAnimation>();
    }
}
