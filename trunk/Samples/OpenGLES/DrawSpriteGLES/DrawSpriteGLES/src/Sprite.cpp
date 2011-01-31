#include "StdAfx.h"
#include "Sprite.h"

CSprite::CSprite(void)
{
}

CSprite::~CSprite(void)
{
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
