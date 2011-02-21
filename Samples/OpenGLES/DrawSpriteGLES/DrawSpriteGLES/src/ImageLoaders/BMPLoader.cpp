#include "StdAfx.h"
#include "BMPLoader.h"
#include "src/memory/MMGR.H"

CBMPLoader::CBMPLoader(void)
{
	pImage=pPalette=pData=NULL;
	iWidth=iHeight=iBPP=bEnc=0;
	lImageSize=0;
}

CBMPLoader::~CBMPLoader(void)
{
	SAFE_DELETE_ARRAY(pImage);
	SAFE_DELETE_ARRAY(pPalette);
	SAFE_DELETE_ARRAY(pData);
}
 
int CBMPLoader::Load(char* szFilename)
{
	using namespace std;
	ifstream fIn;
	unsigned long ulSize;
	int iRet;

	// Clear out any existing image and palette
	SAFE_DELETE_ARRAY(pImage);
	SAFE_DELETE_ARRAY(pPalette);

	// Open the specified file
	fIn.open(szFilename,ios::binary);

	if(fIn==NULL)
		return IMG_ERR_NO_FILE;

	// Get file size
	fIn.seekg(0, ios_base::end);
	ulSize = fIn.tellg();
	fIn.seekg(0, ios_base::beg);

	// Allocate some space
	// Check and clear pDat, just in case
	SAFE_DELETE_ARRAY(pData);

	pData = new unsigned char[ulSize];

	if(pData == NULL)
	{
		fIn.close();
		return IMG_ERR_MEM_FAIL;
	}

	// Read the file into memory
	fIn.read((char*)pData,ulSize);
	fIn.close();
	
	// Process the header
	iRet = ReadHeader();
 
	if(iRet != IMG_OK)
		return iRet;
	
	// Load image data
	iRet = LoadRawData();
	if(iRet != IMG_OK)
		return iRet;
	
	BGRtoRGB(); // Convert to RGB

	return IMG_OK;
}
 
 
int CBMPLoader::ReadHeader() // Examine the header and populate our class attributes
{
	BITMAPFILEHEADER bmpFile;
	BITMAPINFOHEADER info;

	if(pData == NULL)
		return IMG_ERR_NO_FILE;

	memcpy(&bmpFile, pData, sizeof(BITMAPFILEHEADER));
	if (bmpFile.bfType != 0x4D42)
		return IMG_ERR_UNSUPPORTED;

	memcpy(&info, pData + sizeof(BITMAPFILEHEADER), sizeof(BITMAPINFOHEADER));
	iWidth = info.biWidth;
	iHeight = info.biHeight;
	iBPP = info.biBitCount;

	// Calculate image size
	lImageSize = (iWidth * iHeight * (iBPP/8));
	return IMG_OK;
 }
 
int CBMPLoader::LoadRawData() // Load uncompressed image data
{
	short iOffset;

	// Clear old data if present
	SAFE_DELETE_ARRAY(pImage);

	pImage = new unsigned char[lImageSize];

	if(pImage == NULL)
		return IMG_ERR_MEM_FAIL;

	iOffset = sizeof(BITMAPFILEHEADER) + sizeof(BITMAPINFOHEADER); // Add header to ident field size

	memcpy(pImage,&pData[iOffset],lImageSize);

	return IMG_OK;
}


int CBMPLoader::LoadTgaPalette() // Load a 256 color palette
{
	unsigned char bTemp;
	short iIndex,iPalPtr;
 
	// Delete old palette if present
	SAFE_DELETE_ARRAY(pPalette);
 
	// Create space for new palette
	pPalette = new unsigned char[768];
 
	if(pPalette == NULL)
		return IMG_ERR_MEM_FAIL;
 
	// VGA palette is the 768 bytes following the header
	memcpy(pPalette, &pData[pData[0] + 18], 768);
	 
	// Palette entries are BGR ordered so we have to convert to RGB
	for(iIndex = 0, iPalPtr = 0; iIndex != 256; ++iIndex, iPalPtr += 3)
	{
		 bTemp = pPalette[iPalPtr];               // Get Blue value
		 pPalette[iPalPtr] = pPalette[iPalPtr+2]; // Copy Red to Blue
		 pPalette[iPalPtr + 2] = bTemp;             // Replace Blue at the end
	}
	return IMG_OK;
}
 
 
void CBMPLoader::BGRtoRGB() // Convert BGR to RGB (or back again)
{
	unsigned long Index,nPixels;
	unsigned char *bCur;
	unsigned char bTemp;
	short iPixelSize;

	// Set ptr to start of image
	bCur = pImage;

	// Calc number of pixels
	nPixels = iWidth * iHeight;

	// Get pixel size in bytes
	iPixelSize = iBPP/8;

	for(Index = 0; Index != nPixels; Index++)  // For each pixel
	{
		bTemp = *bCur;      // Get Blue value
		*bCur = *(bCur + 2);  // Swap red value into first position
		*(bCur + 2) = bTemp;  // Write back blue to last position

		bCur += iPixelSize; // Jump to next pixel
	}
 
}
 
 
void CBMPLoader::FlipImg() // Flips the image vertically (Why store images upside down?)
{
	unsigned char bTemp;
	unsigned char *pLine1, *pLine2;
	int iLineLen, iIndex;

	iLineLen = iWidth * (iBPP/8);
	pLine1 = pImage;
	pLine2 = &pImage[iLineLen * (iHeight - 1)];

	for( ;pLine1 < pLine2; pLine2 -= (iLineLen*2))
	{
		for(iIndex = 0; iIndex != iLineLen; pLine1++, pLine2++, iIndex++)
		{
			bTemp = *pLine1;
			*pLine1 = *pLine2;
			*pLine2 = bTemp;       
		}
	} 
 
}
 
 
int CBMPLoader::GetBPP() 
 {
  return iBPP;
 }
 
 
int CBMPLoader::GetWidth()
 {
  return iWidth;
 }
 
 
int CBMPLoader::GetHeight()
 {
  return iHeight;
 }
 
 
unsigned char* CBMPLoader::GetImg()
 {
  return pImage;
 }
 
 
unsigned char* CBMPLoader::GetPalette()
 {
  return pPalette;
 }