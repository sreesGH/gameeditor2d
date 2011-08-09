using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NewLayer
{
    public partial class frmNewLayer : Form
    {
        public UInt16 m_mapWidth;
        public UInt16 m_mapHeight;
        public UInt16 m_tileWidth;
        public UInt16 m_tileHeight;
        public UInt16 m_nbHTiles;
        public UInt16 m_nbVTiles;
        public int m_layerType;
        public string m_layerName;

        public frmNewLayer()
        {
            InitializeComponent();
        }

        private void frmNewLayer_Load(object sender, EventArgs e)
        {
            m_layerType = -1;
            comboBoxLayerType.SelectedIndex = 0;

            // Needed to get text changed in multiple text boxes
            foreach (Control maybeTextBox in GetControls(this))
            {
                if (maybeTextBox is TextBox)
                {
                    maybeTextBox.TextChanged += new EventHandler(tbNbHTiles_TextChanged);
                }
            }

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

        private void comboBoxLayerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxLayerType.SelectedIndex == 1)
            {
                gbLayer.Hide();
            }
            else
            {
                gbLayer.Show();
            }

        }

        private void tbNbHTiles_TextChanged(object sender, EventArgs e)
        {
            if (tbNbHTiles.Text != null && tbTileWidth.Text != null && tbNbVTiles.Text != null && tbTileHeight.Text != null
                && tbNbHTiles.Text != "" && tbTileWidth.Text != "" && tbNbVTiles.Text != "" && tbTileHeight.Text != "")
            {
                m_tileWidth = System.Convert.ToUInt16(tbTileWidth.Text);
                m_nbHTiles = System.Convert.ToUInt16(tbNbHTiles.Text);
                m_tileHeight = System.Convert.ToUInt16(tbTileHeight.Text);
                m_nbVTiles = System.Convert.ToUInt16(tbNbVTiles.Text);

                m_mapWidth = (UInt16)(m_nbHTiles * m_tileWidth);
                m_mapHeight = (UInt16)(m_nbVTiles * m_tileHeight);
                lblMapSize.Text = "Map Size : " + m_mapWidth + " x " + m_mapHeight;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            m_layerType = comboBoxLayerType.SelectedIndex;
            m_layerName = tbLayerName.Text;

            if (m_mapWidth > 0 && m_mapHeight > 0 || m_layerType == 1)
            {
                if (m_layerName != null && m_layerName != "")
                {
                    this.Close();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            m_layerType = -1;
            this.Close();
        }
    }
}
