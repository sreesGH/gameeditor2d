#include "StdAfx.h"

//#include "MemoryManager.h"
#include "src/memory/MMGR.H"

#include "Sprite.h"
#include "Texture.h"
#include "Utility.h"

GLfloat gRect[] =		{
							0.0f, 0.0f, 0.0f,
							1.0f, 0.0f, 0.0f,
							0.0f, 1.0f, 0.0f,
							1.0f, 1.0f, 0.0f,
						};

GLfloat gTexCoords[] =	{
							0.0f, 1.0f,
							1.0f, 1.0f,
							0.0f, 0.0f,
							1.0f, 0.0f,
						};

CSprite::CSprite(void):m_animationStartTime(-1),
						m_CurrentAnimationFrame(0)
{
	m_texture = new CTexture();
}

CSprite::~CSprite(void)
{
	SAFE_DELETE (m_texture);

	// delete module data
	SAFE_DELETE_ARRAY(m_pModuleID);
	SAFE_DELETE_ARRAY(m_pModuleClipX);
	SAFE_DELETE_ARRAY(m_pModuleClipY);
	SAFE_DELETE_ARRAY(m_pModuleClipWidth);
	SAFE_DELETE_ARRAY(m_pModuleClipHeight);

	// delete frame data
	SAFE_DELETE_ARRAY(m_pFrameID);
	for(int i = 0; i < m_nFrames; i++)
	{
		SAFE_DELETE_ARRAY(m_pFrameModuleID[i]);
		SAFE_DELETE_ARRAY(m_pFrameModuleX[i]);
		SAFE_DELETE_ARRAY(m_pFrameModuleY[i]);
		SAFE_DELETE_ARRAY(m_pFrameModuleFlag[i]);
	}	
	SAFE_DELETE_ARRAY(m_pFrameModuleID);
	SAFE_DELETE_ARRAY(m_pFrameModuleX);
	SAFE_DELETE_ARRAY(m_pFrameModuleY);
	SAFE_DELETE_ARRAY(m_pFrameModuleFlag);
	SAFE_DELETE_ARRAY(m_pnFrameModules);

	// delete animation data
	SAFE_DELETE_ARRAY(m_pAnimationID);
	for(int i = 0; i < m_pnAnimationFrames[i]; i++)
	{
		SAFE_DELETE_ARRAY(m_pAnimationFrameID[i]);
		SAFE_DELETE_ARRAY(m_pAnimationFrameTime[i]);
		SAFE_DELETE_ARRAY(m_pAnimationFrameX[i]);
		SAFE_DELETE_ARRAY(m_pAnimationFrameY[i]);
	}
	SAFE_DELETE_ARRAY(m_pAnimationFrameID);
	SAFE_DELETE_ARRAY(m_pAnimationFrameTime);
	SAFE_DELETE_ARRAY(m_pAnimationFrameX);
	SAFE_DELETE_ARRAY(m_pAnimationFrameY);
	SAFE_DELETE_ARRAY(m_pnAnimationFrames);
}

bool CSprite::Load(const char* name)
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
			//Read image name string size
			int imageNameSize;
			fread(&imageNameSize, 1, sizeof(int), fp);
			//Read image name
			fread((void *)m_ImageName, imageNameSize, sizeof(char), fp);
			m_texture->LoadTexture(m_ImageName);

			//Read image width
			fread(&m_ImageWidth, 1, sizeof(short), fp);

			//Read image height
			fread(&m_ImageHeight, 1, sizeof(short), fp);

			//Read number of modules
			fread(&m_nModules, 1, sizeof(int), fp);
			//Read moduleID, clipX, clipY, clipWidth, ClipHeight
			m_pModuleID = new short[m_nModules];
			m_pModuleClipX = new short[m_nModules];
			m_pModuleClipY = new short[m_nModules];
			m_pModuleClipWidth = new short[m_nModules];
			m_pModuleClipHeight = new short[m_nModules];
			for(int i = 0; i < m_nModules; i++)
			{
				fread(m_pModuleID + i, 1, sizeof(short), fp);
				fread(m_pModuleClipX  + i, 1, sizeof(short), fp);
				fread(m_pModuleClipY + i, 1, sizeof(short), fp);
				fread(m_pModuleClipWidth + i, 1, sizeof(short), fp);
				fread(m_pModuleClipHeight + i, 1, sizeof(short), fp);
			#ifdef _DEBUG
				printf("i = %d\n", i);
				printf("Module ID = %d\n", m_pModuleID[i]);
				printf("Module ClipX = %d\n", m_pModuleClipX[i]);
				printf("Module ClipY = %d\n", m_pModuleClipY[i]);
				printf("Module ClipW = %d\n", m_pModuleClipWidth[i]);
				printf("Module ClipH = %d\n", m_pModuleClipHeight[i]);
			#endif	//_DEBUG
			}

			#ifdef _DEBUG
				printf("==================== FRAMES ==========================\n");
			#endif	//_DEBUG

			//Read number of frames
			fread(&m_nFrames, 1, sizeof(int), fp);
			//Read number of frameID
			m_pFrameID = new short[m_nFrames];
			m_pnFrameModules = new int[m_nFrames];
			m_pFrameModuleID = new short*[m_nFrames];
			m_pFrameModuleX = new short*[m_nFrames];
			m_pFrameModuleY = new short*[m_nFrames];
			m_pFrameModuleFlag = new unsigned char*[m_nFrames];
			for(int i = 0; i < m_nFrames; i++)
			{
				fread(m_pFrameID + i, 1, sizeof(short), fp);
				fread(m_pnFrameModules + i, 1, sizeof(int), fp);
				
				m_pFrameModuleID[i] = new short[m_pnFrameModules[i]];
				m_pFrameModuleX[i] = new short[m_pnFrameModules[i]];
				m_pFrameModuleY[i] = new short[m_pnFrameModules[i]];
				m_pFrameModuleFlag[i] = new unsigned char[m_pnFrameModules[i]];
			#ifdef _DEBUG
				printf("--- i = %d\n", i);
								printf("--- Frame ID = %d\n", m_pFrameID[i]);
				printf("--- Nb. of Frame Modules = %d\n", m_pnFrameModules[i]);
			#endif	//_DEBUG
				for(int j = 0; j < m_pnFrameModules[i]; j++)
				{
					fread(m_pFrameModuleID[i] + j, 1, sizeof(short), fp);
					fread(m_pFrameModuleX[i] + j, 1, sizeof(short), fp);
					fread(m_pFrameModuleY[i] + j, 1, sizeof(short), fp);
					fread(m_pFrameModuleFlag[i] + j, 1, sizeof(unsigned char), fp);
			#ifdef _DEBUG
				printf("--- --- j = %d\n", j);
				printf("--- --- Frame Modules ID   = %d\n", m_pFrameModuleID[i][j]);
				printf("--- --- Frame Modules X    = %d\n", m_pFrameModuleX[i][j]);
				printf("--- --- Frame Modules Y    = %d\n", m_pFrameModuleY[i][j]);
				printf("--- --- Frame Modules FLAG = %d\n", m_pFrameModuleFlag[i][j]);
			#endif	//_DEBUG
				}
			}

			#ifdef _DEBUG
				printf("======================= ANIMATIONS =======================\n");
			#endif	//_DEBUG

			//Read number of animations
			fread(&m_nAnimations, 1, sizeof(int), fp);
			m_pAnimationID = new short[m_nAnimations];
			m_pnAnimationFrames = new int[m_nAnimations];
			m_pAnimationFrameID = new short*[m_nAnimations];
			m_pAnimationFrameTime = new long long*[m_nAnimations];
			m_pAnimationFrameX = new short*[m_nAnimations];
			m_pAnimationFrameY = new short*[m_nAnimations];
			for(int i = 0; i < m_nAnimations; i++)
			{
				fread(m_pAnimationID + i, 1, sizeof(short), fp);
				fread(m_pnAnimationFrames + i, 1, sizeof(int), fp);

				m_pAnimationFrameID[i] = new short [m_pnAnimationFrames[i]];
				m_pAnimationFrameTime[i] = new long long [m_pnAnimationFrames[i]];
				m_pAnimationFrameX[i] = new short [m_pnAnimationFrames[i]];
				m_pAnimationFrameY[i] = new short [m_pnAnimationFrames[i]];
			#ifdef _DEBUG
				printf("--- i = %d\n", i);
				printf("--- Animation ID = %d\n", m_pAnimationID[i]);
				printf("--- Nb. of Animation Frames = %d\n", m_pnAnimationFrames[i]);
			#endif	//_DEBUG
				for(int j = 0; j < m_pnAnimationFrames[i]; j++)
				{
					fread(m_pAnimationFrameID[i] + j, 1, sizeof(short), fp);
					fread(m_pAnimationFrameTime[i] + j, 1, sizeof(long long), fp);
					fread(m_pAnimationFrameX[i] + j, 1, sizeof(short), fp);
					fread(m_pAnimationFrameY[i] + j, 1, sizeof(short), fp);
				#ifdef _DEBUG
					printf("--- --- j = %d\n", j);
					printf("--- --- Anim Frame ID   = %d\n", m_pAnimationFrameID[i][j]);
					printf("--- --- Anim Frame Time = %ld\n", m_pAnimationFrameTime[i][j]);
					printf("--- --- Anim Frame X    = %d\n", m_pAnimationFrameX[i][j]);
					printf("--- --- Anim Frame Y	= %d\n", m_pAnimationFrameY[i][j]);
				#endif	//_DEBUG
				}
			}
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

////////////////////////////////////////////////////////////////////
//	Editor co-ordinate system 
//  (0, 0)
//		|--------------
//		|	O
//		|  /||\
//		|	/\
//
//	OPENGL-ES co-ordinate system 
//
//		|	O
//		|  /||\
//		|	/\
//		|--------------
//  (0, 0)
////////////////////////////////////////////////////////////////////

void CSprite::PaintModule(int id, float x, float y, int flag)const
{
	gRect[0] = x;								gRect[1] = y;
	gRect[3] = x + m_pModuleClipWidth[id];		gRect[4] = y;
	gRect[6] = x;								gRect[7] = y + m_pModuleClipHeight[id];
	gRect[9] = x + m_pModuleClipWidth[id];		gRect[10] = y + m_pModuleClipHeight[id];

	float s1 = (float)m_pModuleClipX[id] / m_ImageWidth;
	float t1 = (float)(m_ImageHeight - m_pModuleClipY[id]) / m_ImageHeight;
	float s2 = (float)(m_pModuleClipX[id] + m_pModuleClipWidth[id]) / m_ImageWidth;
	float t2 = (float)(m_ImageHeight -(m_pModuleClipY[id] + m_pModuleClipHeight[id])) / m_ImageHeight;

	gTexCoords[0] = s1;			gTexCoords[1] = t2;
	gTexCoords[2] = s2;			gTexCoords[3] = t2;
	gTexCoords[4] = s1;			gTexCoords[5] = t1;
	gTexCoords[6] = s2;			gTexCoords[7] = t1;

	glVertexPointer(3, GL_FLOAT, 0, gRect);
	glTexCoordPointer(2, GL_FLOAT, 0, gTexCoords);
	glBindTexture(GL_TEXTURE_2D, m_texture->GetID());
	glDrawArrays(GL_TRIANGLE_STRIP/*GL_LINES*/, 0, 4);
	return;
}

void CSprite::PaintFrame(int id, float x, float y, int flag)const
{
	for(int i = 0; i < m_pnFrameModules[id]; i++)
	{
		PaintModule(m_pFrameModuleID[id][i], m_pFrameModuleX[id][i] + x, m_pFrameModuleY[id][i] + y, 1.0); 
	}
	return;
}

void CSprite::PaintAnimation(int id, float x, float y, int flag, bool bLoop, int startingFrameIndex)
{
	if(m_CurrentAnimationFrame == startingFrameIndex)
	{
		if(m_animationStartTime == -1)
		{
			m_animationStartTime = CUtility::GetTime();
		}
	}

	PaintFrame(m_CurrentAnimationFrame, m_pAnimationFrameX[id][m_CurrentAnimationFrame] + x, m_pAnimationFrameY[id][m_CurrentAnimationFrame] + y, 1);

	if((CUtility::GetTime() - m_animationStartTime) > m_pAnimationFrameTime[id][m_CurrentAnimationFrame])
	{
		if(m_CurrentAnimationFrame < m_pnAnimationFrames[id] - 1)
		{
			m_CurrentAnimationFrame++;
			m_animationStartTime = CUtility::GetTime();
		}
		else
		{
			if(bLoop)
			{
				m_CurrentAnimationFrame = 0;
			}
		}
	}
	return;
}