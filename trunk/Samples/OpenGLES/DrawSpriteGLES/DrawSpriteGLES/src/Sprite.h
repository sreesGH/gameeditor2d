//////////////////////////////////////////////////////////////
//	CSprite:
//	Author	: Sreenath M
//	Date	: 28/01/2011
//////////////////////////////////////////////////////////////

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
//			|-NB. OF FRAME MODULES          (4 bytes - Integer)
//          |-FRAME MODULES ID              (2 bytes - Short)
//          |-FRAME MODULES X               (2 bytes - Short)
//          |-FRAME MODULES Y               (2 bytes - Short)
//          |-FRAME MODULES FLAG            (1 byte - Byte)
//  NB. OF ANIMATIONS      (4 bytes - Integer)
//      |-ANIMATION ID                          (2 bytes - Short)
//			|-NB. OF ANIMATION FRAMES           (4 bytes - Integer)
//          |-ANIMATION FRAMES ID               (2 bytes - Short)
//          |-ANIMATION FRAMES TIME             (8 bytes - Int64)
//          |-ANIMATION FRAMES X                (2 bytes - Short)
//          |-ANIMATION FRAMES Y                (2 bytes - Short)
///////////////////////////////////////////////////////////////////////////////

#pragma once
#define MAX_NAME_SIZE		128

class CSprite
{
public:
	CSprite(void);
	CSprite(const CSprite &RHS);
	~CSprite(void);
	bool Load(const char* name);

private:
	char m_ImageName[MAX_NAME_SIZE];

	int m_nModules;
	short *m_pModuleID;
	short *m_pModuleClipX;
	short *m_pModuleClipY;
	short *m_pModuleClipWidth;
	short *m_pModuleClipHeight;

	int m_nFrames;
	short *m_pFrameID;
	int *m_pnFrameModules;
	short **m_pFrameModuleID;
	short **m_pFrameModuleX;
	short **m_pFrameModuleY;
	unsigned char **m_pFrameModuleFlag;

	int m_nAnimations;
	short *m_pAnimationID;
	int *m_pnAnimationFrames;
	short **m_pAnimationFrameID;
	long long **m_pAnimationFrameTime;
	short **m_pAnimationFrameX;
	short **m_pAnimationFrameY;

};
