using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;

using NewLayer;

namespace TextEditor
{
    public partial class frmTextEditor : Form
    {
        int m_languageCount = 1;
        Color m_selectedFontColor = Color.Black;
        int m_selectedLanguage = 0;

        string m_ExportPath = null;

        public frmTextEditor()
        {
            InitializeComponent();
            m_languageCount = 1;
        }

        private void toolStripButtonAddLanguage_Click(object sender, EventArgs e)
        {
            m_languageCount++;
            dataGridViewTextEditor.Columns.Add("Language" + m_languageCount, "Language " + m_languageCount );
        }

        private void dataGridViewTextEditor_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                string s = "" + dataGridViewTextEditor[e.ColumnIndex, e.RowIndex].Value;
                s = s.ToUpper();
                dataGridViewTextEditor[e.ColumnIndex, e.RowIndex].Value = s;

                for (int i = 0; i < e.RowIndex; i++)
                {
                    if ("" + dataGridViewTextEditor[0, i].Value == "" + dataGridViewTextEditor[e.ColumnIndex, e.RowIndex].Value)
                    {
                        MessageBox.Show("ID is same at " + i +"th row" );
                    }
                }
            }
            dataGridViewTextEditor[e.ColumnIndex, e.RowIndex].Style.Font = dataGridViewTextEditor.DefaultCellStyle.Font;
            dataGridViewTextEditor[e.ColumnIndex, e.RowIndex].Style.ForeColor = dataGridViewTextEditor.DefaultCellStyle.ForeColor;
        }

        private void toolStripButtonExport_Click(object sender, EventArgs e)
        {
            saveFileDialogExport.ShowDialog();
            if (saveFileDialogExport.FileName != "")
            {
                // parse only name of the file
                string fileName = saveFileDialogExport.FileName;
                int nameStart = 0;
                int nameLength = 0;
                int extStart = 0;
                for (int i = fileName.Length - 1; i >= 0; i--)
                {
                    if (fileName[i] == '\\')
                    {
                        nameStart = i + 1;
                        nameLength = fileName.Length - 1 - i;
                        break;
                    }
                }
                fileName = fileName.Substring(nameStart, nameLength);
                string imageName = fileName;
                extStart = fileName.IndexOf(".");
                fileName = fileName.Substring(0, extStart);

                // open file for header and exported data
                TextWriter header_h = new StreamWriter(fileName + ".h");

                header_h.WriteLine("#ifndef _" + fileName.ToUpper() + "_H_");
                header_h.WriteLine("#define _" + fileName.ToUpper() + "_H_");

                for (int i = 1; i <= m_languageCount; i++)   // first column is ID
                {
                    FileStream stream = new FileStream(fileName + "_language" + i + ".btxt", FileMode.Create);
                    BinaryWriter exportWriter = new BinaryWriter(stream);
                    FileStream offsetStream = new FileStream(fileName + "_language" + i + "_offset" + ".btxt", FileMode.Create);
                    BinaryWriter offsetExportWriter = new BinaryWriter(offsetStream);
                    for (int j = 0; j < dataGridViewTextEditor.RowCount - 1; j++)
                    {
                        header_h.WriteLine("#define " + dataGridViewTextEditor[0, j].Value + "          " + j);
                        offsetExportWriter.Write(stream.Position);
                        exportWriter.Write("" + dataGridViewTextEditor[i, j].Value);
                    }
                    offsetExportWriter.Close();
                    exportWriter.Close();
                }

                //close header stream
                header_h.WriteLine("#endif //HEADER_H");
                header_h.Close();
            }

        }

        private void toolStripButtonUndo_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButtonShowFontDialog_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            if (fontDialog1.ShowDialog() != DialogResult.Cancel)
            {
                DataGridViewCell selectedCell = dataGridViewTextEditor.CurrentCell;
                selectedCell.Style.Font = fontDialog1.Font;
                selectedCell.Style.ForeColor = fontDialog1.Color;

                //Set this font for all cells from now onwards
                dataGridViewTextEditor.DefaultCellStyle.Font = fontDialog1.Font;
                dataGridViewTextEditor.DefaultCellStyle.ForeColor = fontDialog1.Color;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void toolStripButtonchangecase_Click(object sender, EventArgs e)
        {
            DataGridViewCell selectedCell = dataGridViewTextEditor.CurrentCell;
            if (selectedCell.ColumnIndex == 0) return;
            else
            {
                string s = "" + selectedCell.Value;
                selectedCell.Value = "" + s.ToUpper();
            }
        }

        private void toolStripButtonTranslate_Click(object sender, EventArgs e)
        {
            frmNewLayer childWindow = new frmNewLayer();
            childWindow.ShowDialog();
            CTranslate t = new CTranslate();
            t.InitTranslation("en", t.m_languageCode[childWindow.m_selectedLanguage]);

            m_languageCount++;
            dataGridViewTextEditor.Columns.Add("Language" + m_languageCount, "Language " + m_languageCount);

            for (int i = 0; i < dataGridViewTextEditor.RowCount; i++ )
            {
                string rslt;
                t.SetData("" + dataGridViewTextEditor[1, i].Value);
                rslt = t.Translate();
                dataGridViewTextEditor[m_languageCount, i].Value = rslt; 
            }
        }
    }

    public class CFontCell
    {
        public string m_font;
        public short m_fontSize;
        public short m_fontStyle;
        public short type;
        public string m_text;
    }
}
