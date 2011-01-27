#pragma once
#define MAX_NAME_SIZE		128

class CSprite
{
public:
	CSprite(void);
	CSprite(const CSprite &RHS);
	~CSprite(void);
	bool Load(const char* name) const;

private:
	char m_name[MAX_NAME_SIZE];

	int m_nModules;
	short *m_pModuleID;
	short *m_pModuleClipX;
	short *m_pModuleClipY;
	short *m_pModuleClipWidth;
	short *m_pModuleClipHeight;

	int m_nFrames;
	short *m_pFrameID;
	int *m_pnFrameModules;
	short *m_pFrameModuleID;
	short *m_pFrameModuleX;
	short *m_pFrameModuleY;
	unsigned char *m_pFrameModuleFlag;

	int m_nAnimations;
	short *m_pAnimationID;
	int *m_pnAnimationFrames;
	short *m_pAnimationFrameID;
	long long *m_pAnimationFrameTime;
	short *m_pAnimationFrameModuleX;
	short *m_pAnimationFrameY;

};
