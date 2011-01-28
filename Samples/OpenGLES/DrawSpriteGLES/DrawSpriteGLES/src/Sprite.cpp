#include "StdAfx.h"
#include "Sprite.h"

CSprite::CSprite(void)
{
}

CSprite::~CSprite(void)
{
}

bool CSprite::Load(const char* name) const
{
	FILE *fp = NULL;
	fp = fopen(name,"rb");
	if(fp)
	{
		fseek(fp, 8, SEEK_SET);
		int fileSize = 0;
		fread(&fileSize, 1, sizeof(int), fp);
		fseek(fp, 0, SEEK_END);
		int size = ftell(fp);
		fseek(fp, 12, SEEK_SET);
		if(fileSize == size)
		{
			int imageNameSize;
			fread(&imageNameSize, 1, sizeof(int), fp);
			fread((void *)m_ImageName, imageNameSize, sizeof(char), fp);
			return true;
		}
		else
		{
			return false;
		}
	}
	else
	{
		return false;
	}
}
