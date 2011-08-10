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
    public partial class CameraProperties : Form
    {
        public Int16 m_cameraX = 0;
        public Int16 m_cameraY = 0;
        public UInt16 m_cameraWidth = 0;
        public UInt16 m_cameraHeight = 0;

        public CameraProperties()
        {
            InitializeComponent();
        }

        public void Init()
        {
            tbCamX.Text = "" + m_cameraX;
            tbCamY.Text = "" + m_cameraY;
            tbCamWidth.Text = "" + m_cameraWidth;
            tbCamHeight.Text = "" + m_cameraHeight;
        }

        private void buttonCameraPropOK_Click(object sender, EventArgs e)
        {
            if (tbCamX.Text != "" && tbCamY.Text != ""
                && tbCamWidth.Text != "" && tbCamHeight.Text != "")
            {
                m_cameraX = System.Convert.ToInt16(tbCamX.Text);
                m_cameraY = System.Convert.ToInt16(tbCamY.Text);
                m_cameraWidth = System.Convert.ToUInt16(tbCamWidth.Text);
                m_cameraHeight = System.Convert.ToUInt16(tbCamHeight.Text);
            }

            if (m_cameraWidth > 0 && m_cameraHeight > 0)
            {
                this.Close();
            }
        }

        private void tbCamWidth_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
