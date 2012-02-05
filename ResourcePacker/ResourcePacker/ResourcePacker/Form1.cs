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

namespace ResourcePacker
{
    public partial class frmMain : Form
    {
        CLoadSaveContainer m_container = new CLoadSaveContainer();
        string m_currentSavePath = null;

        public frmMain()
        {
            InitializeComponent();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialogPackFile.ShowDialog(); // Show the dialog.
        }

        private void tsbtnOpen_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialogPackFile.ShowDialog(); // Show the dialog.
        }

        private void openFileDialogPackFile_FileOk(object sender, CancelEventArgs e)
        {
            string file = openFileDialogPackFile.FileName;
            OpenPackFile(file);
        }

        private void OpenPackFile(string fileName)
        {
            //TODO:implement
            Clean();

            TextReader textReader = new StreamReader(@fileName);

            XmlSerializer readImage = new XmlSerializer(typeof(CLoadSaveContainer));
            m_container = (CLoadSaveContainer)readImage.Deserialize(textReader);
            textReader.Close();

            for (int i = 0; i < m_container.m_list.Count; i++)
            {
                CPackInfo pack = m_container.m_list[i];
                int n = dgViewPack.Rows.Add();
                dgViewPack.Rows[n].Cells[0].Value = "" + pack.m_index;
                dgViewPack.Rows[n].Cells[1].Value = "" + pack.m_path;
                dgViewPack.Rows[n].Cells[2].Value = "" + pack.m_size;
                dgViewPack.Rows[n].Cells[3].Value = "" + pack.m_packFile;
            }

            m_currentSavePath = fileName;
            return;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialogPackFile.ShowDialog();
        }

        private void tsBtnSave_Click(object sender, EventArgs e)
        {
            if (m_currentSavePath == null)
            {
                saveFileDialogPackFile.ShowDialog();
            }
            else
            {
                SavePackFile(m_currentSavePath);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialogPackFile.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string name = saveFileDialogPackFile.FileName;
            SavePackFile(name);
        }

        private void SavePackFile(string fileName)
        {
            //TODO:implement
            TextWriter textWriter = new StreamWriter(@fileName);

            XmlSerializer serializerImage = new XmlSerializer(typeof(CLoadSaveContainer));
            serializerImage.Serialize(textWriter, m_container);
            textWriter.Close();

            m_currentSavePath = fileName;

        }

        private void tsBtnAdd_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialogFile.ShowDialog(); // Show the dialog.
        }

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialogFile.ShowDialog(); // Show the dialog.
        }

        private void openFileDialogFile_FileOk(object sender, CancelEventArgs e)
        {
            string file = openFileDialogFile.FileName;
            AddFileToPack(file);
        }

        private void AddFileToPack(string fileName)
        {
            //TODO:implement
            CPackInfo pack = new CPackInfo();
            pack.m_index = m_container.m_list.Count;
            pack.m_path = fileName;

            FileInfo f = new FileInfo(fileName);
            pack.m_size = f.Length;
            pack.m_packFile = "default";
            m_container.m_list.Add(pack);
            int n = dgViewPack.Rows.Add();
            dgViewPack.Rows[n].Cells[0].Value = "" + pack.m_index;
            dgViewPack.Rows[n].Cells[1].Value = "" + pack.m_path;
            dgViewPack.Rows[n].Cells[2].Value = "" + pack.m_size;
            dgViewPack.Rows[n].Cells[3].Value = "" + pack.m_packFile;
        }

        private void frmMain_DragDrop(object sender, DragEventArgs e)
        {
            Array a = (Array)e.Data.GetData(DataFormats.FileDrop);

            //if (a.GetValue(0).ToString().IndexOf(".pak") == -1)
            //{
            //    return;
            //}
            //else
            {
                AddFileToPack(a.GetValue(0).ToString());
            }
        }

        private void tsBtanPack_Click(object sender, EventArgs e)
        {
            Pack();
        }

        private void frmMain_DragEnter(object sender, DragEventArgs e)
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

        private void tsBtnNew_Click(object sender, EventArgs e)
        {
            Clean();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clean();
        }

        private void Clean()
        {
            m_currentSavePath = null;
            dgViewPack.Rows.Clear();
            m_container.m_list.Clear();
        }

        private void Pack()
        {
            byte[] buffer = new Byte[1024];
            int bytesRead;
            List<COffsetInfo> offsetInfoList = new List<COffsetInfo>();

            for (int i = 0; i < m_container.m_list.Count - 1; i++)
            {
                CPackInfo pack = m_container.m_list[i];

                string path = System.IO.Path.GetDirectoryName(m_currentSavePath);
                path += "\\";
                path += pack.m_packFile;
                //path += ".data";

                FileStream writeStream = new FileStream(path, FileMode.Append);
                FileStream readStream = new FileStream(pack.m_path, FileMode.Open);
                BinaryWriter binaryWriter = new BinaryWriter(writeStream);
                BinaryReader binaryReader = new BinaryReader(readStream);

                while ((bytesRead = binaryReader.Read(buffer, 0, 1024)) > 0)
                {
                    binaryWriter.Write(buffer, 0, bytesRead);
                }

                readStream.Close();
                binaryWriter.Close();

                int index = -1;
                for (int j = 0; j < offsetInfoList.Count; j++)
                {
                    if (offsetInfoList[j].m_packname == pack.m_packFile)
                    {
                        index = j;
                        break;
                    }
                }

                if (index == -1)
                {
                    COffsetInfo offinfo = new COffsetInfo();
                    offinfo.m_packname = pack.m_packFile;
                    //add offsets
                    offinfo.m_offsetList.Add(pack.m_size);
                    //add corresponding filenames
                    offinfo.m_filenameList.Add(System.IO.Path.GetFileName(pack.m_path));
                    offsetInfoList.Add(offinfo);
                }
                else
                {
                    //offset and corresponding filename 
                    offsetInfoList[index].m_filenameList.Add(System.IO.Path.GetFileName(pack.m_path));
                    offsetInfoList[index].m_offsetList.Add(pack.m_size);
                }
                       

                //pack.m_index;
                //pack.m_path;
                //pack.m_size;
                //pack.m_packFile;
                //string file = System.IO.Path.GetFileName("C:\\realtek.log");
            }

            string fileName = System.IO.Path.GetFileNameWithoutExtension(m_currentSavePath);
            string headerPath = System.IO.Path.GetDirectoryName(m_currentSavePath);
            headerPath += "\\";
            headerPath += "ResourceHeader";
            headerPath += ".h";
            TextWriter header_h = new StreamWriter(headerPath);
            header_h.WriteLine("#ifndef _" + fileName.ToUpper() + "_H_");
            header_h.WriteLine("#define _" + fileName.ToUpper() + "_H_");

            //List offsets
            header_h.WriteLine("static long g_offsetarray[] = {");
            for (int i = 0; i < offsetInfoList.Count; i++)
            {
                //first file offset is zero for all packs
                header_h.WriteLine("0,");
                long offset = 0;
                for (int j = 0; j < offsetInfoList[i].m_offsetList.Count; j++)
                {
                    //add with previous offset to get next file offset
                    offset += offsetInfoList[i].m_offsetList[j];
                    header_h.WriteLine("" + offset + ",");
                }
            }
            //now end with "}"
            header_h.WriteLine("};");

            //List file names
            header_h.WriteLine("static string g_fileNameArray[] = {");
            for (int i = 0; i < offsetInfoList.Count; i++)
            {
                for (int j = 0; j < offsetInfoList[i].m_offsetList.Count; j++)
                {
                    header_h.WriteLine("\"" + offsetInfoList[i].m_filenameList[j] + "\"" + ",");
                }
            }
            //now end with "}"
            header_h.WriteLine("};");

            //List of packfile names 
            header_h.WriteLine("static string g_packFileNameArray[] = {");
            int totalfilecount = 0;
            for (int i = 0; i < offsetInfoList.Count; i++)
            {
                for (int j = 0; j < offsetInfoList[i].m_offsetList.Count; j++)
                {
                    header_h.WriteLine("\"" + offsetInfoList[i].m_packname + "\"" + ",");
                }
                totalfilecount += offsetInfoList[i].m_offsetList.Count;
            }
            //now end with "}"
            header_h.WriteLine("};");

            header_h.WriteLine("#define " + "TOTAL_FILES_PACKED         " + "(" + totalfilecount + ")");
            
            //close header stream
            header_h.WriteLine("#endif //HEADER_H");
            header_h.Close();
        }

        private void dgViewPack_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            /*
            m_container.m_list.Clear();

            for (int i = 0; i < dgViewPack.RowCount; i++)
            {
                CPackInfo pack = new CPackInfo();
                pack.m_index = Convert.ToInt32(dgViewPack.Rows[i].Cells[0].Value);
                pack.m_path = Convert.ToString(dgViewPack.Rows[i].Cells[1].Value);
                pack.m_size = Convert.ToInt64(dgViewPack.Rows[i].Cells[2].Value);
                pack.m_packFile = Convert.ToString(dgViewPack.Rows[i].Cells[3].Value);
                m_container.m_list.Add(pack);
            }
             */
        }

        private void dgViewPack_EditModeChanged(object sender, EventArgs e)
        {

        }

        private void dgViewPack_Enter(object sender, EventArgs e)
        {

        }

        private void dgViewPack_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
            
        }

        private void dgViewPack_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            m_container.m_list.Clear();

            for (int i = 0; i < dgViewPack.RowCount; i++)
            {
                CPackInfo pack = new CPackInfo();
                pack.m_index = Convert.ToInt32(dgViewPack.Rows[i].Cells[0].Value);
                pack.m_path = Convert.ToString(dgViewPack.Rows[i].Cells[1].Value);
                pack.m_size = Convert.ToInt64(dgViewPack.Rows[i].Cells[2].Value);
                pack.m_packFile = Convert.ToString(dgViewPack.Rows[i].Cells[3].Value);
                m_container.m_list.Add(pack);
            }
        }
    }

    public class COffsetInfo
    {
        public string m_packname;
        public List<string> m_filenameList = new List<string>();
        public List<long> m_offsetList = new List<long>();
    }

    public class CPackInfo
    {
        public int m_index;
        public string m_path;
        public long m_size;
        public string m_packFile;
    }

    public class CLoadSaveContainer
    {
        public List<CPackInfo> m_list = new List<CPackInfo>();
    }
}
