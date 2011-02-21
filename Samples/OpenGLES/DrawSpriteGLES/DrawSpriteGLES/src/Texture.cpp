#include "StdAfx.h"

#include <string.h>
#include "Texture.h"
#include "src/ImageLoaders/TGALoader.h"
#include "src/ImageLoaders/BMPLoader.h"
#include "src/memory/MMGR.H"


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

	if(strstr(name, ".bmp"))
	{
		printf("BMP Image\n");
		//bitmap = LoadBMP(name, &info);
		m_BMPLoader = new CBMPLoader();
		m_BMPLoader->Load(name);
	}
	else if(strstr(name, ".tga"))
	{
		printf("TGA Image\n");
		m_TGALoader = new CTGALoader();
		m_TGALoader->Load(name);
	}
	else
	{
		printf("Unsupported image format\n");
	}

	glGenTextures(1, &m_Id);

	glBindTexture(GL_TEXTURE_2D, m_Id);

	if(strstr(name, ".bmp"))
	{
		glTexImage2D(GL_TEXTURE_2D, 0, GL_RGB, m_BMPLoader->GetWidth(),
					m_BMPLoader->GetHeight(), 0, GL_RGB, GL_UNSIGNED_BYTE,
					m_BMPLoader->GetImg());
	}
	else
	{
		glTexImage2D(GL_TEXTURE_2D, 0, GL_RGBA, m_TGALoader->GetWidth(),
					m_TGALoader->GetHeight(), 0, GL_RGBA, GL_UNSIGNED_BYTE,
					m_TGALoader->GetImg());
	}

	glTexParameterf(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR);
	glTexParameterf(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);

	//SAFE_DELETE_ARRAY(bitmap);

	return true;
}
