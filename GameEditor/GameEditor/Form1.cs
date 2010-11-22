using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
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

        //Frame
        short m_nFrames = 0;
        short m_frameID = 0;
        List<CFrame> mListAllFrames = new List<CFrame>();

        int snappedFrameModuleID = -1;

        //Animation
        short m_animationID = 0;
        short m_nAnimations = 0;
        List<CAnimation> mListAllAnimations = new List<CAnimation>();

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

                case ViewerState.FRAME_EDITOR:
                    {
                        //if (dgViewFrameModule.Rows[j].IsNewRow)
                        if (m_nFrames <= 0) return;
                        int selectedFrame = dgViewFrame.CurrentRow.Index;
                        if (m_nFrames <= selectedFrame) return;
                        for (int i = 0; i < mListAllFrames[selectedFrame].mListFrameModules.Count; i++)
                        {
                            gViewerGraphics.DrawImage(ImageListmodule.Images[mListAllFrames[selectedFrame].mListFrameModules[i].mId], mListAllFrames[selectedFrame].mListFrameModules[i].mX, mListAllFrames[selectedFrame].mListFrameModules[i].mY);
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

                            int diffX = e.X - mListAllFrames[selectedFrame].mListFrameModules[snappedFrameModuleID].mX;
                            int diffY = e.Y - mListAllFrames[selectedFrame].mListFrameModules[snappedFrameModuleID].mY;

                            mListAllFrames[selectedFrame].mListFrameModules[snappedFrameModuleID].mX += (short)diffX;
                            mListAllFrames[selectedFrame].mListFrameModules[snappedFrameModuleID].mY += (short)diffY;
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
                        for (int i = mListAllFrames[selectedFrame].mListFrameModules.Count - 1; i >= 0; i--)
                        {
                            if (e.X >= mListAllFrames[selectedFrame].mListFrameModules[i].mX
                                && e.X <= (mListAllFrames[selectedFrame].mListFrameModules[i].mX + mListAllFrames[selectedFrame].mListFrameModules[i].mClipWidth)
                                && e.Y >= mListAllFrames[selectedFrame].mListFrameModules[i].mY
                                && e.Y <= (mListAllFrames[selectedFrame].mListFrameModules[i].mY + mListAllFrames[selectedFrame].mListFrameModules[i].mClipHeight)
                                )
                            {
                                snappedFrameModuleID = i;
                                this.Cursor = Cursors.Hand;
                                break;
                            }
                        }
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
                        break;
                    }
                case ViewerState.FRAME_EDITOR:
                    {
                        snappedFrameModuleID = -1;
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
                        mListAllFrames[selectedFrame].mListFrameModules.Add(module);
                        break;
                    }
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
            mListAllFrames.Insert(n, frame);
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
            for (int i = 0; i < mListAllFrames[selectedFrame].mListFrameModules.Count; i++)
            {
                int n = dgViewFrameModule.Rows.Add();
                dgViewFrameModule.Rows[i].Cells[0].Value = "" + mListAllFrames[selectedFrame].mListFrameModules[i].mId;
                dgViewFrameModule.Rows[i].Cells[1].Value = "" + mListAllFrames[selectedFrame].mListFrameModules[i].mX;
                dgViewFrameModule.Rows[i].Cells[2].Value = "" + mListAllFrames[selectedFrame].mListFrameModules[i].mY;
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
            mListAllAnimations.Insert(m_animationID, animation);
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
            mListAllAnimations.Insert(m_animationID, animation);

            for (int i = 0; i < dgViewFrame.RowCount; i++)
            {
                if (dgViewFrame.Rows[i].Selected)
                {
                    CFrame frame = new CFrame();
                    frame.mId = mListAllFrames[i].mId;
                    frame.mX = 0;
                    frame.mY = 0;
                    frame.mTime = 1000;
                    mListAllAnimations[m_animationID].mListAnimationFrames.Add(frame);
                    
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
            for (int i = 0; i < mListAllAnimations.Count; i++)
            {
                //create row and fill it:      
                int n = dgViewAnimation.Rows.Add();
                dgViewAnimation.Rows[i].Cells[0].Value = "" + mListAllAnimations[i].mId;
                dgViewAnimation.Rows[i].Cells[1].Value = "" + "ANIMATION_ID_" + mListAllAnimations[i].mId;
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
            for (int i = 0; i < mListAllAnimations[selectedAnimation].mListAnimationFrames.Count; i++)
            {
                int n = dgViewAnimationFrame.Rows.Add();
                dgViewAnimationFrame.Rows[i].Cells[0].Value = "" + mListAllAnimations[selectedAnimation].mListAnimationFrames[i].mId;
                dgViewAnimationFrame.Rows[i].Cells[1].Value = "" + mListAllAnimations[selectedAnimation].mListAnimationFrames[i].mTime;
                dgViewAnimationFrame.Rows[i].Cells[2].Value = "" + mListAllAnimations[selectedAnimation].mListAnimationFrames[i].mX;
                dgViewAnimationFrame.Rows[i].Cells[3].Value = "" + mListAllAnimations[selectedAnimation].mListAnimationFrames[i].mY;
            }
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
        public Int64 mTime;
        public List<CModule> mListFrameModules;
        public CFrame()
        {
            mListFrameModules = new List<CModule>();
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
}
