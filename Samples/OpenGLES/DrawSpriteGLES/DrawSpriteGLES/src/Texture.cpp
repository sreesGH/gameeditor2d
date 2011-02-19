#include "StdAfx.h"
//#include "MemoryManager.h"
#include "src/memory/MMGR.H"

#include "Texture.h"

CTexture::CTexture(void)
{
	//LoadTexture(name);
}

CTexture::~CTexture(void)
{
}

bool CTexture::LoadTexture(char* name)
{
	BITMAPINFOHEADER info;
	unsigned char *bitmap = NULL;
	
	bitmap = LoadBMP(name, &info);

	if (!bitmap)
		return false;

	glGenTextures(1, &m_Id);

	glBindTexture(GL_TEXTURE_2D, m_Id);

	glTexImage2D(GL_TEXTURE_2D, 0, GL_RGB, info.biWidth,
		info.biHeight, 0, GL_RGB, GL_UNSIGNED_BYTE,
		bitmap);

	glTexParameterf(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR);
	glTexParameterf(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);

	SAFE_DELETE_ARRAY(bitmap);

	return true;
}

unsigned char* CTexture::LoadBMP(char *filename, BITMAPINFOHEADER *bmpInfo)
{
	FILE *file;
	BITMAPFILEHEADER bmpFile;
	unsigned char *bmpImage = NULL;
	unsigned char tmpRGB;

	TCHAR path[256];
	char fullPath[256];
	GetModuleFileName(NULL, path, 256);

	TCHAR *pos = wcsrchr(path, '\\');
	*(pos + 1) = '\0';
	
	wcstombs(fullPath, path, 256);
	
	strcat(fullPath, filename);

	file = fopen(fullPath,"rb");

	if (!file)
	{
		MessageBox(NULL, L"Can't Find Bitmap", L"Error", MB_OK);
		return NULL;
	}

	fread(&bmpFile,sizeof(BITMAPFILEHEADER),1,file);

	if (bmpFile.bfType != 0x4D42)
	{
		MessageBox(NULL, L"Incorrect texture type", L"Error", MB_OK);
		fclose(file);
		return NULL;
	}

	fread(bmpInfo,sizeof(BITMAPINFOHEADER),1,file);

	fseek(file,bmpFile.bfOffBits,SEEK_SET);

	bmpImage = new unsigned char[bmpInfo->biSizeImage];

	if (!bmpImage)
	{
		MessageBox(NULL, L"Out of Memory", L"Error", MB_OK);
		SAFE_DELETE_ARRAY(bmpImage);
		fclose(file);
		return NULL;
	}

	fread(bmpImage,1,bmpInfo->biSizeImage,file);

	if (!bmpImage)
	{
		MessageBox(NULL, L"Error reading bitmap", L"Error", MB_OK);
		fclose(file);
		return NULL;
	}

	for (unsigned int i = 0; i < bmpInfo->biSizeImage; i+=3)
	{
		tmpRGB = bmpImage[i];
		bmpImage[i] = bmpImage[i+2];
		bmpImage[i+2] = tmpRGB;
	}

	fclose(file);

	return bmpImage;
}
