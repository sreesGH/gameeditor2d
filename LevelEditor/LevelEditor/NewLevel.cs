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
    public partial class frmNewLevel : Form
    {
        string mLevelName = null;
        public frmNewLevel()
        {
            InitializeComponent();
        }

        private void frmNewLevel_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            mLevelName = tbLevelName.Text;
            this.Close();
        }

        public string GetLevelName()
        {
            return mLevelName;
        }
    }
}
