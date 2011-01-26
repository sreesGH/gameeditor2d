using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace GameEditor
{
    public class ModuleLoad
    {
        public static bool Load()
        {
            string path = GameEditor.GetGfxFilePath();

            TextReader textReader = new StreamReader(@path);

            XmlSerializer readImage = new XmlSerializer(typeof(CLoadSaveContainer));
            CLoadSaveContainer container = (CLoadSaveContainer)readImage.Deserialize(textReader);
            textReader.Close();
            GameEditor.SetContainer(container);
            return true;
        }
    }
}
