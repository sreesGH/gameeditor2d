using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

///////////////////////////////////////////////////////////////////////////////
//  HEADER              (4 bytes - Integer)
//  FLAG                (4 bytes - Integer)
//  IMAGE NAME LENGTH   (4 bytes - Integer)
//  IMAGE NAME          (Byte array)
//  NB. OF MODULES      (4 bytes - Integer)
//      |-MODULE ID             (2 bytes - Short)
//      |-MODULE CLIP X         (2 bytes - Short)
//      |-MODULE CLIP Y         (2 bytes - Short)
//      |-MODULE CLIP WIDTH     (2 bytes - Short)
//      |-MODULE CLIP HEIGHT    (2 bytes - Short)
//  NB. OF FRAMES      (4 bytes - Integer)
//      |-FRAME ID                          (2 bytes - Short)
//      |-NB. OF FRAME MODULES              (4 bytes - Integer)
//          |-FRAME MODULES ID              (2 bytes - Short)
//          |-FRAME MODULES X               (2 bytes - Short)
//          |-FRAME MODULES Y               (2 bytes - Short)
//          |-FRAME MODULES FLAG            (1 byte - Byte)
//  NB. OF ANIMATIONS      (4 bytes - Integer)
//      |-ANIMATION ID                          (2 bytes - Short)
//      |-NB. OF ANIMATION FRAMES               (4 bytes - Integer)
//          |-ANIMATION FRAMES ID               (2 bytes - Short)
//          |-ANIMATION FRAMES TIME             (4 bytes - Integer)
//          |-ANIMATION FRAMES X                (2 bytes - Short)
//          |-ANIMATION FRAMES Y                (2 bytes - Short)
///////////////////////////////////////////////////////////////////////////////

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

            FileStream stream = new FileStream(path, FileMode.Create);
            BinaryWriter exportWriter = new BinaryWriter(stream);

            // parse only name of the file
            int nameStart = 0;
            int nameLength = 0;
            for (int i = path.Length - 1; i >= 0; i--)
            {
                if (path[i] == '\\')
                {
                    nameStart = path.Length - 2 - i;
                    nameLength = i + 2;
                    break;
                }
            }
            path = path.Substring(nameStart, nameLength);

            //////////////////////////////////////////////////

            exportWriter.Write(0xFF);
            size += 4;  //Header (Future)

            exportWriter.Write(0xFF);
            size += 4;  //Flags (Future)

            exportWriter.Write(path.Length);
            size += 4;  //image path length

            exportWriter.Write(path);
            size += path.Length;

            exportWriter.Write(moduleList.Count);
            size += 4;  //nb. of modules

            for (int i = 0; i < moduleList.Count; i++)
            {
                exportWriter.Write(moduleList[i].mId);
                size += 2; //moduleID
                exportWriter.Write(moduleList[i].mClipX);
                size += 2; //moduleX
                exportWriter.Write(moduleList[i].mClipY);
                size += 2; //moduleY
                exportWriter.Write(moduleList[i].mClipWidth);
                size += 2; //moduleWidth
                exportWriter.Write(moduleList[i].mClipHeight);
                size += 2; //moduleHeight
            }

            exportWriter.Write(frameList.Count);
            size += 4; //nb. of frames

            for (int i = 0; i < frameList.Count; i++)
            {
                exportWriter.Write(frameList[i].mId);
                size += 2; //frameID
                exportWriter.Write(frameList[i].mListFrameModules.Count);
                size += 4; //nb. of framemodules

                for (int j = 0; j < frameList[i].mListFrameModules.Count; j++)
                {
                    exportWriter.Write(frameList[i].mListFrameModules[j].mId);
                    size += 2; //framemoduleID
                    exportWriter.Write(frameList[i].mListFrameModules[j].mX);
                    size += 2; //framemoduleX
                    exportWriter.Write(frameList[i].mListFrameModules[j].mY);
                    size += 2; //frmaemoduleY
                    exportWriter.Write(frameList[i].mListFrameModules[j].mFlag);
                    size += 1; //frmaemoduleFlag
                }
            }

            exportWriter.Write(animationList.Count);
            size += 4; //nb. of animations
            
            for (int i = 0; i < animationList.Count; i++)
            {
                exportWriter.Write(animationList[i].mId);
                size += 2; //animationID
                exportWriter.Write(animationList[i].mListAnimationFrames.Count);
                size += 4; //nb. of animationframes

                for (int j = 0; j < animationList[i].mListAnimationFrames.Count; j++)
                {
                    exportWriter.Write(animationList[i].mListAnimationFrames[j].mId);
                    size += 2; //animationframeID
                    exportWriter.Write(animationList[i].mListAnimationFrames[j].mTime);
                    size += 2; //animationframeTime
                    exportWriter.Write(animationList[i].mListAnimationFrames[j].mX);
                    size += 2; //animationframeX
                    exportWriter.Write(animationList[i].mListAnimationFrames[j].mY);
                    size += 2; //animationframeY
                }
            }

            exportWriter.Seek(8, SeekOrigin.Begin); //skip header anf flag
            exportWriter.Write(size);
            exportWriter.Close();

            return true;
        }
    }
}
