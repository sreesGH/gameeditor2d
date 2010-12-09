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
            TextWriter textWriter = new StreamWriter(@"C:\image.xml");

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
