using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GameEditor
{
    public class ModuleExport
    {
        public static bool Export(CImage image, List<CModule> moduleList, List<CFrame> frameList, List<CAnimation> animationList)
        {
            int size = 0;
            string path = GameEditor.GetImagePath();
            int extStart = path.IndexOf(".");
            path = path.Substring(0, extStart);
            path += ".bgfx";
            
            size += path.Length;
            
            size += 4;  //nb. of modules
            size += (moduleList.Count * 4); //moduleID
            size += (moduleList.Count * 2); //moduleX
            size += (moduleList.Count * 2); //moduleY
            size += (moduleList.Count * 2); //moduleWidth
            size += (moduleList.Count * 2); //moduleHeight

            size += 4; //nb. of frames
            size += (frameList.Count * 4); //frameID
            for (int i = 0; i < frameList.Count; i++)
            {
                size += 4; //nb. of framemodules
                size += frameList[i].mListFrameModules.Count * 4; //framemoduleID
                size += frameList[i].mListFrameModules.Count * 4; //framemoduleX 
                size += frameList[i].mListFrameModules.Count * 4; //frmaemoduleY
                size += frameList[i].mListFrameModules.Count * 4; //frmaemoduleFlag
            }

            size += 4; //nb. of animations
            size += (animationList.Count * 4); //animationID
            for (int i = 0; i < animationList.Count; i++)
            {
                size += 4; //nb. of animationframes
                size += animationList[i].mListAnimationFrames.Count * 4; //animationframeID
                size += animationList[i].mListAnimationFrames.Count * 4; //animationframeTime
                size += animationList[i].mListAnimationFrames.Count * 4; //animationframeX
                size += animationList[i].mListAnimationFrames.Count * 4; //animationframeY
            }

            byte[] data = new byte[size];
            FileStream stream = new FileStream(path, FileMode.Create);
            BinaryWriter w = new BinaryWriter(stream);
            w.Write(data);
            w.Close();

            return true;
        }
    }
}
