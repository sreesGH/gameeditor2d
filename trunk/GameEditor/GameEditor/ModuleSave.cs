using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace GameEditor
{
    public class ModuleSave
    {
        public static bool Save(CLoadSaveContainer container)
        {
            string path = GameEditor.GetImagePath();
            int extStart = path.IndexOf(".");
            path = path.Substring(0, extStart);
            path += ".gfx";
            TextWriter textWriter = new StreamWriter(@path);

            XmlSerializer serializerImage = new XmlSerializer(typeof(CLoadSaveContainer));
            serializerImage.Serialize(textWriter, container);
            textWriter.Close();

            return true;
        }
    }
}
