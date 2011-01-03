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
        public static bool Save(CImage image, List<CModule> moduleList, List<CFrame> frameList, List<CAnimation> animationList)
        {
            string path = Form1.GetImagePath();
            int extStart = path.IndexOf(".");
            path = path.Substring(0, extStart);
            path += ".gfx";
            TextWriter textWriter = new StreamWriter(@path);

            XmlSerializer serializerImage = new XmlSerializer(typeof(CImage));
            serializerImage.Serialize(textWriter, image);

            XmlSerializer serializerModule = new XmlSerializer(typeof(List<CModule>));
            serializerModule.Serialize(textWriter, moduleList);

            XmlSerializer serializerFrame = new XmlSerializer(typeof(List<CFrame>));
            serializerFrame.Serialize(textWriter, frameList);

            XmlSerializer serializerAnimation = new XmlSerializer(typeof(List<CAnimation>));
            serializerAnimation.Serialize(textWriter, animationList);

            textWriter.Close();
            return true;
        }
    }
}
