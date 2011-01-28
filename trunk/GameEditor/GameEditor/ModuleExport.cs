using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

///////////////////////////////////////////////////////////////////////////////
//  HEADER              (4 bytes - Integer)
//  FLAG                (4 bytes - Integer)
//  FILE SIZE           (4 bytes - Integer)
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
//          |-ANIMATION FRAMES TIME             (8 bytes - Int64)
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
            string fileName = GameEditor.GetImagePath();
            int extStart = path.IndexOf(".");
            path = path.Substring(0, extStart);

            
            // open file for header and exported data
            TextWriter header_h = new StreamWriter(path+".h");
            FileStream stream = new FileStream(path + ".bgfx", FileMode.Create);
            BinaryWriter exportWriter = new BinaryWriter(stream);

            // parse only name of the file
            int nameStart = 0;
            int nameLength = 0;
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
            //////////////////////////////////////////////////

            exportWriter.Write(0xFF);
            size += 4;  //Header (Future)

            exportWriter.Write(0xFF);
            size += 4;  //Flags (Future)

            exportWriter.Write(0x00);
            size += 4;  //Total size (Will be written @ the end)

            exportWriter.Write(imageName.Length);
            size += 4;  //image path length

            //Size of the file name is getting written with image name: Thats how exporter works
            //Here is the fix
            for (int i = 0; i < imageName.Length; i++)
            {
                exportWriter.Write(imageName[i]);
            }
            size += (imageName.Length);

            header_h.WriteLine("#ifndef _" + fileName.ToUpper() + "_H_" );
            header_h.WriteLine("#define _" + fileName.ToUpper() + "_H_");
            header_h.WriteLine("#define " + fileName.ToUpper() + "_IMAGE" + "            " + "\"" + imageName + "\"");

            /////////////////////////////////// MODULES ///////////////////////////////////////////////////////////////////////
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

                header_h.WriteLine("#define " + fileName.ToUpper() + "_MODULE_ID_" + (moduleList[i].mDescription).ToString() 
                                    + "            " + "(" + moduleList[i].mId + ")");
            }

            /////////////////////////////////// FRAMES ///////////////////////////////////////////////////////////////////////
            exportWriter.Write(frameList.Count);
            size += 4; //nb. of frames

            for (int i = 0; i < frameList.Count; i++)
            {
                exportWriter.Write(frameList[i].mId);
                size += 2; //frameID
                exportWriter.Write(frameList[i].mListFrameModules.Count);
                size += 4; //nb. of framemodules

                header_h.WriteLine("#define " + fileName.ToUpper() + "_FRAME_ID_" + (frameList[i].mDescription).ToString()
                                    + "            " + "(" + frameList[i].mId + ")");

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

            /////////////////////////////////// ANIMATIONS ///////////////////////////////////////////////////////////////////////
            exportWriter.Write(animationList.Count);
            size += 4; //nb. of animations
            
            for (int i = 0; i < animationList.Count; i++)
            {
                exportWriter.Write(animationList[i].mId);
                size += 2; //animationID
                exportWriter.Write(animationList[i].mListAnimationFrames.Count);
                size += 4; //nb. of animationframes

                header_h.WriteLine("#define " + fileName.ToUpper() + "_ANIMATION_ID_" + (animationList[i].mDescription).ToString()
                                    + "            " + "(" + animationList[i].mId + ")");

                for (int j = 0; j < animationList[i].mListAnimationFrames.Count; j++)
                {
                    exportWriter.Write(animationList[i].mListAnimationFrames[j].mId);
                    size += 2; //animationframeID
                    exportWriter.Write(animationList[i].mListAnimationFrames[j].mTime);
                    size += 8; //animationframeTime
                    exportWriter.Write(animationList[i].mListAnimationFrames[j].mX);
                    size += 2; //animationframeX
                    exportWriter.Write(animationList[i].mListAnimationFrames[j].mY);
                    size += 2; //animationframeY
                }
            }

            exportWriter.Seek(8, SeekOrigin.Begin); //skip header anf flag
            exportWriter.Write(size);
            exportWriter.Close();

            //close header stream
            header_h.WriteLine("#endif //HEADER_H");
            header_h.Close();

            return true;
        }
    }
}
