using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GameEditor
{
    public class CTGALoader
    {
        const int IMG_OK = 0x1;
        const int IMG_ERR_NO_FILE = 0x2;
        const int IMG_ERR_MEM_FAIL = 0x4;
        const int IMG_ERR_BAD_FORMAT = 0x8;
        const int IMG_ERR_UNSUPPORTED =  0x40;

        int iWidth, iHeight, iBPP;
        bool bRGB = false, bFlipImg = false;
        long lImageSize;
        byte bEnc;
        byte[] pImage, pPalette, pData;

        public CTGALoader()
        { 
            pImage = pPalette = pData = null;
            iWidth = iHeight = iBPP = bEnc = 0;
            lImageSize = 0;
        }

        ~CTGALoader()
        {
            pImage = pPalette = pData = null;
        }

        public int Load(string szFilename)
        {
            long ulSize;
            int iRet;
            
            // Clear out any existing image and palette
            if(pImage != null)  pImage = null;
            if(pPalette != null) pPalette = null;
            
            // Open the specified file
            FileStream fs = File.OpenRead(szFilename);
            BinaryReader br = new BinaryReader(fs);
 
            if(br == null)
            {
                return IMG_ERR_NO_FILE;
            }
 
            FileInfo fi = new FileInfo(szFilename);
            ulSize = fi.Length;
 
            // Allocate some space
            // Check and clear pDat, just in case
            if(pData != null) pData = null;
    
 
            pData = new byte[ulSize];
 
            if(pData == null)
            {
                return IMG_ERR_MEM_FAIL;
            }
 
            // Read the file into memory
            pData = br.ReadBytes((int)ulSize);
 
            br.Close();
 
            // Process the header
            iRet=ReadHeader();
 
            if(iRet!=IMG_OK)
                return iRet;
            
            switch(bEnc)
            {
                case 1: // Raw Indexed
                {
                    // Check filesize against header values
                    if((lImageSize+18+pData[0]+768)>ulSize)
                        return IMG_ERR_BAD_FORMAT;

                    // Double check image type field
                    if(pData[1]!=1)
                        return IMG_ERR_BAD_FORMAT;

                    // Load image data
                    iRet=LoadRawData();
                    if(iRet!=IMG_OK)
                        return iRet;

                    // Load palette
                    iRet=LoadTgaPalette();
                    if(iRet!=IMG_OK)
                        return iRet;

                    break;
                }

                case 2: // Raw RGB
                {
                    // Check filesize against header values
                    if((lImageSize+18+pData[0])>ulSize)
                        return IMG_ERR_BAD_FORMAT;

                    // Double check image type field
                    if(pData[1]!=0)
                        return IMG_ERR_BAD_FORMAT;

                    // Load image data
                    iRet=LoadRawData();
                    if(iRet!=IMG_OK)
                        return iRet;

                    //BGRtoRGB(); // Convert to RGB
                    bRGB = true;

                    break;
                }

                case 9: // RLE Indexed
                {
                    // Double check image type field
                    if(pData[1]!=1)
                        return IMG_ERR_BAD_FORMAT;

                    // Load image data
                    iRet=LoadTgaRLEData();
                    if(iRet!=IMG_OK)
                        return iRet;

                    // Load palette
                    iRet=LoadTgaPalette();
                    if(iRet!=IMG_OK)
                        return iRet;

                    break;
                }
             
                case 10: // RLE RGB
                {
                    // Double check image type field
                    if(pData[1]!=0)
                        return IMG_ERR_BAD_FORMAT;

                    // Load image data
                    iRet=LoadTgaRLEData();
                    if(iRet!=IMG_OK)
                        return iRet;

                    //BGRtoRGB(); // Convert to RGB
                    bRGB = true;

                    break;
                }

                default:
                    return IMG_ERR_UNSUPPORTED;
            }
             
            // Check flip bit
            if ((pData[17] & 0x10) != 0)
            {
                bFlipImg = true;
            }
             
            // Release file memory
            pData = null;
            return IMG_OK;
        }
 
        int ReadHeader() // Examine the header and populate our class attributes
        {
            short ColMapStart,ColMapLen;
            short x1,y1,x2,y2;
 
            if(pData == null)
                return IMG_ERR_NO_FILE;
 
            if(pData[1] > 1)    // 0 (RGB) and 1 (Indexed) are the only types we know about
                return IMG_ERR_UNSUPPORTED;
 
            bEnc = pData[2];    // Encoding flag  1 = Raw indexed image
                                //                2 = Raw RGB
                                //                3 = Raw greyscale
                                //                9 = RLE indexed
                                //               10 = RLE RGB
                                //               11 = RLE greyscale
                                //               32 & 33 Other compression, indexed
 
            if(bEnc>11)       // We don't want 32 or 33
                return IMG_ERR_UNSUPPORTED;
 
 
            // Get palette info
            ColMapStart = System.BitConverter.ToInt16(pData, 3);
            ColMapLen = System.BitConverter.ToInt16(pData, 5);

            // Reject indexed images if not a VGA palette (256 entries with 24 bits per entry)
            if(pData[1] == 1) // Indexed
            {
                if(ColMapStart!=0 || ColMapLen != 256 || pData[7] != 24)
                    return IMG_ERR_UNSUPPORTED;
            }
 
            // Get image window and produce width & height values
            x1 = System.BitConverter.ToInt16(pData, 8);
            y1 = System.BitConverter.ToInt16(pData, 10);
            x2 = System.BitConverter.ToInt16(pData, 12);
            y2 = System.BitConverter.ToInt16(pData, 14);
 
            iWidth = (x2-x1);
            iHeight = (y2-y1);
 
            if(iWidth<1 || iHeight<1)
                return IMG_ERR_BAD_FORMAT;
 
            // Bits per Pixel
            iBPP = pData[16];
 
            // Check flip / interleave byte
            if(pData[17] > 32) // Interleaved data
                return IMG_ERR_UNSUPPORTED;
 
            // Calculate image size
                lImageSize = (iWidth * iHeight * (iBPP / 8));
 
            return IMG_OK;
        }
 
        int LoadRawData() // Load uncompressed image data
         {
            short iOffset;

            // Clear old data if present
            if(pImage != null) pImage = null;

            pImage=new byte[lImageSize];

            if(pImage == null)
            return IMG_ERR_MEM_FAIL;

            iOffset = (short)(pData[0] + 18); // Add header to ident field size

            if(pData[1] == 1) // Indexed images
            iOffset += 768;  // Add palette offset

            System.Array.Copy(pData, iOffset, pImage, 0, (int)lImageSize);

            return IMG_OK;
         }
 
 
        int LoadTgaRLEData() // Load RLE compressed image data
        {
            /*
            short iOffset, iPixelSize;
            byte[] pCur;
            long Index = 0;
            byte bLength,bLoop;

            // Calculate offset to image data
            iOffset = (short)(pData[0] + 18);

            // Add palette offset for indexed images
            if(pData[1] == 1)
            iOffset += 768; 

            // Get pixel size in bytes
            iPixelSize = (short)(iBPP / 8);

            // Set our pointer to the beginning of the image data
            pCur = &pData[iOffset];

            // Allocate space for the image data
            if(pImage != null)
                pImage = null;

            pImage=new byte[lImageSize];

            if(pImage == null)
                return IMG_ERR_MEM_FAIL;

            // Decode
            while(Index<lImageSize) 
            {
            if(*pCur & 0x80) // Run length chunk (High bit = 1)
            {
            bLength=*pCur-127; // Get run length
            pCur++;            // Move to pixel data  

            // Repeat the next pixel bLength times
            for(bLoop=0;bLoop!=bLength;++bLoop,Index+=iPixelSize)
            memcpy(&pImage[Index],pCur,iPixelSize);

            pCur+=iPixelSize; // Move to the next descriptor chunk
            }
            else // Raw chunk
            {
            bLength=*pCur+1; // Get run length
            pCur++;          // Move to pixel data

            // Write the next bLength pixels directly
            for(bLoop=0;bLoop!=bLength;++bLoop,Index+=iPixelSize,pCur+=iPixelSize)
            memcpy(&pImage[Index],pCur,iPixelSize);
            }
            }
            */
            return IMG_OK;
        }
 
 
        int LoadTgaPalette() // Load a 256 color palette
        {
            /*
            byte bTemp;
            short iIndex, iPalPtr;

            // Delete old palette if present
            if(pPalette != null)
            {
                pPalette = null;
            }

            // Create space for new palette
            pPalette = new byte[768];

            if(pPalette == null)
                return IMG_ERR_MEM_FAIL;

            // VGA palette is the 768 bytes following the header
            System.Array.Copy(pData[pData[0] + 18], 0, pPalette, 0, 768);

            // Palette entries are BGR ordered so we have to convert to RGB
            for(iIndex = 0, iPalPtr = 0; iIndex != 256; ++iIndex, iPalPtr += 3)
            {
                bTemp = pPalette[iPalPtr];               // Get Blue value
                pPalette[iPalPtr] = pPalette[iPalPtr+2]; // Copy Red to Blue
                pPalette[iPalPtr+2] = bTemp;             // Replace Blue at the end
            }
            */
            return IMG_OK;
        } 
 
        public bool IsFlipNeeded()
        {
            return bFlipImg;
        }
 
        public int GetBPP()
        {
            return iBPP;
        }

        public int GetWidth()
        {
            return iWidth;
        }

        public int GetHeight()
        {
            return iHeight;
        }

        public byte[] GetImg()
        {
            return pImage;
        }

        public bool IsRGB()
        {
            return bRGB;
        }

        public byte[] GetPalette()
        {
            return pPalette;
        }

    }
}
