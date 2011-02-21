//////////////////////////////////////////////////////////////
//	CTexture:
//	Author	: Sreenath M
//	Date	: 11/02/2011
//////////////////////////////////////////////////////////////

#pragma once

#include "GLES/gl.h"

class CTGALoader;
class CBMPLoader;

class CTexture
{
public:
	CTexture(void);
	~CTexture(void);
	bool LoadTexture(char* name);
	inline unsigned int GetID(){return m_Id;}
private:
	unsigned int m_Id;
	unsigned int m_width;
	unsigned int m_height;
	unsigned int m_level;
 	unsigned int m_internalformat;
	char *m_fileName;
	char* m_data;
	unsigned int m_imageSize;
	CTGALoader* m_TGALoader;
	CBMPLoader* m_BMPLoader;
};
