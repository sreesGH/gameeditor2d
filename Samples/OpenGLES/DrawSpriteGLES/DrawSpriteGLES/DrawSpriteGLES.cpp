// GLESTemplate.cpp : Defines the entry point for the application.
//

#include "stdafx.h"
#include "DrawSpriteGLES.h"

#include "GLES/gl.h"
#include "GLES/egl.h"
#include <math.h>
#include <stdio.h>

#include "src/Sprite.h"
#define MAX_LOADSTRING 100

// Global Variables:
HINSTANCE hInst;								// current instance
TCHAR szTitle[MAX_LOADSTRING];					// The title bar text
TCHAR szWindowClass[MAX_LOADSTRING];			// the main window class name

#pragma message( "To Do : 1. Fixed Precision  2. Multi Texturing" )
/////////////////////////////////////////////////////////////

#define SCREEN_WIDTH		320
#define SCREEN_HEIGHT		480
#define PI					(static_cast<double> (3.1415926535897932384626433832795))


EGLDisplay glesDisplay;
EGLSurface glesSurface;
EGLContext glesContext;

HWND hWnd; 
HDC hDC;  

CSprite sprite;

GLuint texture[1];

float xrot = 0.0f;
float yrot = 0.0f;

GLfloat vertices[] = { -1.0f, 1.0f, 1.0f,    //front
				        1.0f, 1.0f, 1.0f,    //1
				        1.0f,-1.0f, 1.0f,    //2
				       -1.0f,-1.0f, 1.0f,    //3
				       -1.0f, 1.0f,-1.0f,    //4
				        1.0f, 1.0f,-1.0f,    //5
				        1.0f,-1.0f,-1.0f,    //6
				       -1.0f,-1.0f,-1.0f  }; //7

// Index Array for method II
GLubyte indices[] = {	0, 1, 2, 3,		//front
						4, 5, 1, 0,		//top
						3, 2, 6, 7,		//bottom
						5, 4, 7, 6,		//back
						1, 5, 6, 2,		//right
						4, 0, 3, 7  };	//left

GLfloat cubeTexCords[] = {
	// FRONT
	 0.0f, 0.0f,
	 1.0f, 0.0f,
	 0.0f, 1.0f,
	 1.0f, 1.0f,
	// BACK
	 1.0f, 0.0f,
	 1.0f, 1.0f,
	 0.0f, 0.0f,
	 0.0f, 1.0f,
	// LEFT
	 1.0f, 0.0f,
	 1.0f, 1.0f,
	 0.0f, 0.0f,
	 0.0f, 1.0f,
	// RIGHT
	 1.0f, 0.0f,
	 1.0f, 1.0f,
	 0.0f, 0.0f,
	 0.0f, 1.0f,
	// TOP
	 0.0f, 0.0f,
	 1.0f, 0.0f,
	 0.0f, 1.0f,
	 1.0f, 1.0f,
	// BOTTOM
	 1.0f, 0.0f,
	 1.0f, 1.0f,
	 0.0f, 0.0f,
	 0.0f, 1.0f
};
	GLfloat box[] = {
		// FRONT
		 0.0f,  0.0f,  0.0f,
		 32.0f,  0.0f,  0.0f,
		 0.0f,  32.0f,  0.0f,
		 32.0f, 32.0f,  0.0f,
	};

	GLfloat texCoords[] = {
		// FRONT
		 0.25f, 0.75f,
		 0.75f, 0.75f,
		 0.25f, 0.25f,
		 0.75f, 0.25f,
	};

float lightAmbient[] = { 0.8f, 0.8f, 0.8f, 1.0f };
float matAmbient[] = { 0.8f, 0.8f, 0.8f, 1.0f };

void DrawImage(float x, float y, int moduleX, int moduleY, int moduleWidth, int moduleHeight)
{
	box[0] = x;					box[1] = y;
	box[3] = x + moduleWidth;	box[4] = y;
	box[6] = x;					box[7] = y + moduleHeight;
	box[9] = x + moduleWidth;	box[10] = y + moduleHeight;

	float s1 = (float)moduleX / 64;
	float t1 = (float)moduleY / 64;
	float s2 = (float)(moduleX + moduleWidth) / 64;
	float t2 = (float)(moduleY + moduleHeight) / 64;

	texCoords[0] = s1;			texCoords[1] = t2;
	texCoords[2] = s2;			texCoords[3] = t2;
	texCoords[4] = s1;			texCoords[5] = t1;
	texCoords[6] = s2;			texCoords[7] = t1;

	glDrawArrays(GL_TRIANGLE_STRIP/*GL_LINES*/, 0, 4);
	return;
}

unsigned char *loadBMP(char *filename, BITMAPINFOHEADER *bmpInfo)
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
		delete[] bmpImage;
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

bool loadTextures()
{
	BITMAPINFOHEADER info;
	unsigned char *bitmap = NULL;
	
	bitmap = loadBMP("zeus.bmp", &info);

	if (!bitmap)
		return false;

	glGenTextures(1, texture);

	glBindTexture(GL_TEXTURE_2D, texture[0]);

	glTexImage2D(GL_TEXTURE_2D, 0, GL_RGB, info.biWidth,
		info.biHeight, 0, GL_RGB, GL_UNSIGNED_BYTE,
		bitmap);

	glTexParameterf(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR);
	glTexParameterf(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);

	delete[] bitmap;

	return true;
}

bool InitOGLES()
{  
  EGLConfig configs[10];
  EGLint matchingConfigs;	

  const EGLint configAttribs[] =
  {
      EGL_RED_SIZE,       8,
      EGL_GREEN_SIZE,     8,
      EGL_BLUE_SIZE,      8,
      EGL_ALPHA_SIZE,     EGL_DONT_CARE,
      EGL_DEPTH_SIZE,     16,
      EGL_STENCIL_SIZE,   EGL_DONT_CARE,
      EGL_SURFACE_TYPE,   EGL_WINDOW_BIT,
      EGL_NONE,           EGL_NONE
  };
  
  hDC = GetWindowDC(hWnd);
  glesDisplay = eglGetDisplay(EGL_DEFAULT_DISPLAY);	 
  
  if(!eglInitialize(glesDisplay, NULL, NULL)) 
    return false;
	
  if(!eglChooseConfig(glesDisplay, configAttribs, &configs[0], 10,  &matchingConfigs)) 
   return false;
	
  if(matchingConfigs < 1)  return false;	  

  glesSurface = eglCreateWindowSurface(glesDisplay, configs[0], hWnd, NULL);	
  if(!glesSurface) return false;
  
  glesContext=eglCreateContext(glesDisplay,configs[0],0,NULL);

  if(!glesContext) return false;

  eglMakeCurrent(glesDisplay, glesSurface, glesSurface, glesContext); 
    
  glClearColorx(0,0,0,0);
  glShadeModel(GL_SMOOTH);  
  glEnable(GL_DEPTH_TEST);
  glEnable(GL_CULL_FACE);

  RECT r;
  GetClientRect(hWnd, &r);  
  //kWindowWidth = r.right - r.left;
  //kWindowHeight = r.bottom - r.top;
  glViewport(0, 0, SCREEN_WIDTH, SCREEN_HEIGHT);	//r.left, r.top, WindowWidth, WindowHeight);
  
  // we need the fastest rendering as possible
  glHint(GL_PERSPECTIVE_CORRECTION_HINT, GL_FASTEST);

  return true;
}

void SetPerspective( float fov, float aspect, float zNear, float zFar )
{
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();  
	glViewport(0, 0, SCREEN_WIDTH, SCREEN_HEIGHT);
	//float aspect = (GLfloat)kWindowWidth/(GLfloat)kWindowHeight;
	float fH = float ( tan( fov / 360 * PI ) * zNear );
	float fW = float ( fH * aspect );
	glFrustumf( -fW, fW, -fH, fH, zNear, zFar );
	glMatrixMode(GL_MODELVIEW);
	glLoadIdentity();
	return;
}

void SetOrtho()
{
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity(); 
	glViewport(0, 0, SCREEN_WIDTH, SCREEN_HEIGHT);
	glOrthof(0.0f, 320.0f, 0.0f, 480.0f, -1.0f, 1.0f);
	glMatrixMode(GL_MODELVIEW);
	glLoadIdentity();
}

void InitGame()
{
	char path[128];
	sprintf(path, "%s", "sprite.bgfx");
	sprite.Load(path);
	if (!loadTextures())
	{
		MessageBox(NULL, L"Error loading textures", L"Error", MB_OK);
		return ;
	}

	glEnable(GL_TEXTURE_2D);

	glEnable(GL_LIGHTING);
	glEnable(GL_LIGHT0);

	glMaterialfv(GL_FRONT_AND_BACK, GL_AMBIENT, matAmbient);
	
	glLightfv(GL_LIGHT0, GL_AMBIENT, lightAmbient);

	glEnable(GL_DEPTH_TEST);
	glDepthFunc(GL_LEQUAL);

	glClearColor(0.0f, 0.0f, 0.0f, 0.0f);
	glClearDepthf(1.0f);

	glVertexPointer(3, GL_FLOAT, 0, box);
	glTexCoordPointer(2, GL_FLOAT, 0, texCoords);
	glEnableClientState(GL_VERTEX_ARRAY);
	glEnableClientState(GL_TEXTURE_COORD_ARRAY);

	glEnable(GL_CULL_FACE);
	glShadeModel(GL_SMOOTH);

	return;
}

void Render()
{
	SetOrtho();
	glClear (GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
	glVertexPointer(3, GL_FLOAT, 0, box);
	glTexCoordPointer(2, GL_FLOAT, 0, texCoords);
	glLoadIdentity();
	glEnable(GL_TEXTURE_2D);

	DrawImage(160.0f, 240.0f, 16.0f, 16.0f, 32.0f, 32.0f);

	glDisable(GL_TEXTURE_2D);
	glTranslatef(64.0f, 64.0f, 0.0f);
	glColor4f(1.0f, 0.0f, 0.0f, 1.0f);
	glNormal3f(0.0f, 0.0f, 1.0f);

	glDrawArrays(GL_TRIANGLE_STRIP, 0, 4);

	float ratio = (float)SCREEN_WIDTH / SCREEN_HEIGHT;
	SetPerspective(45.0f, ratio, 0.1f, 100.0f);
	glLoadIdentity();
	//glDisable(GL_TEXTURE_2D);
	glScalef(0.25f, 0.25f, 0.25f);
	glTranslatef(3.0f, 0.0f, -8.0f);

	glVertexPointer(3, GL_FLOAT, 0, vertices);
	glColor4f(1.0f, 0.0f, 0.0f, 1.0f);
	//go through our index array and draw our vertex array
	glDrawElements(GL_TRIANGLE_STRIP, 24, GL_UNSIGNED_BYTE, indices);
	glPopMatrix();
	glColor4f(1.0f, 1.0f, 1.0f, 1.0f);
	
	eglSwapBuffers(glesDisplay, glesSurface);
	return;
}

////////////////////////////////////////////////////////////

// Forward declarations of functions included in this code module:
ATOM				MyRegisterClass(HINSTANCE hInstance);
BOOL				InitInstance(HINSTANCE, int);
LRESULT CALLBACK	WndProc(HWND, UINT, WPARAM, LPARAM);
INT_PTR CALLBACK	About(HWND, UINT, WPARAM, LPARAM);

int APIENTRY _tWinMain(HINSTANCE hInstance,
                     HINSTANCE hPrevInstance,
                     LPTSTR    lpCmdLine,
                     int       nCmdShow)
{
	UNREFERENCED_PARAMETER(hPrevInstance);
	UNREFERENCED_PARAMETER(lpCmdLine);

 	// TODO: Place code here.
	MSG msg;
//	HACCEL hAccelTable;

	// Initialize global strings
	LoadString(hInstance, IDS_APP_TITLE, szTitle, MAX_LOADSTRING);
	LoadString(hInstance, IDC_DRAWSPRITEGLES, szWindowClass, MAX_LOADSTRING);
	MyRegisterClass(hInstance);

	bool done = false;

	// Perform application initialization:
	if (!InitInstance (hInstance, nCmdShow))
	{
		return FALSE;
	}

	InitGame();

	while(!done)
	{
		if(PeekMessage(&msg,NULL,0,0,PM_REMOVE))
		{
			if(msg.message==WM_QUIT)
			{
				done = true;
			}
			else
			{
				TranslateMessage(&msg);
				DispatchMessage(&msg);
			}
	    }
		else
		{
			Render();
		}
	}

#if 0
	hAccelTable = LoadAccelerators(hInstance, MAKEINTRESOURCE(IDC_GLESTEMPLATE));
	
	// Main message loop:
	while (GetMessage(&msg, NULL, 0, 0))
	{
		if (!TranslateAccelerator(msg.hwnd, hAccelTable, &msg))
		{
			TranslateMessage(&msg);
			DispatchMessage(&msg);
		}
	}
#endif	//if0
	return (int) msg.wParam;
}



//
//  FUNCTION: MyRegisterClass()
//
//  PURPOSE: Registers the window class.
//
//  COMMENTS:
//
//    This function and its usage are only necessary if you want this code
//    to be compatible with Win32 systems prior to the 'RegisterClassEx'
//    function that was added to Windows 95. It is important to call this function
//    so that the application will get 'well formed' small icons associated
//    with it.
//
ATOM MyRegisterClass(HINSTANCE hInstance)
{
	WNDCLASSEX wcex;

	wcex.cbSize = sizeof(WNDCLASSEX);

	wcex.style			= CS_HREDRAW | CS_VREDRAW;
	wcex.lpfnWndProc	= WndProc;
	wcex.cbClsExtra		= 0;
	wcex.cbWndExtra		= 0;
	wcex.hInstance		= hInstance;
	wcex.hIcon			= LoadIcon(hInstance, MAKEINTRESOURCE(IDI_DRAWSPRITEGLES));
	wcex.hCursor		= LoadCursor(NULL, IDC_ARROW);
	wcex.hbrBackground	= (HBRUSH)(COLOR_WINDOW+1);
	wcex.lpszMenuName	= MAKEINTRESOURCE(IDC_DRAWSPRITEGLES);
	wcex.lpszClassName	= szWindowClass;
	wcex.hIconSm		= LoadIcon(wcex.hInstance, MAKEINTRESOURCE(IDI_SMALL));

	return RegisterClassEx(&wcex);
}

//
//   FUNCTION: InitInstance(HINSTANCE, int)
//
//   PURPOSE: Saves instance handle and creates main window
//
//   COMMENTS:
//
//        In this function, we save the instance handle in a global variable and
//        create and display the main program window.
//
BOOL InitInstance(HINSTANCE hInstance, int nCmdShow)
{
   //HWND hWnd;

   hInst = hInstance; // Store instance handle in our global variable

   hWnd = CreateWindow(szWindowClass, szTitle, 
						///*WS_OVERLAPPED|WS_CAPTION|WS_SYSMENU|WS_THICKFRAME|
						//WS_MINIMIZEBOX|WS_CLIPSIBLINGS|WS_CLIPCHILDREN*/
						WS_OVERLAPPEDWINDOW,
						CW_USEDEFAULT,
						0,
						SCREEN_WIDTH + GetSystemMetrics(SM_CXFIXEDFRAME) * 2 + GetSystemMetrics(SM_CXBORDER) * 2 ,
						SCREEN_HEIGHT + GetSystemMetrics(SM_CYCAPTION) + GetSystemMetrics(SM_CYMENU) 
						+ GetSystemMetrics(SM_CYFIXEDFRAME) * 2 + GetSystemMetrics(SM_CYBORDER) * 2,
						NULL, NULL, hInstance, NULL);

   if (!hWnd)
   {
      return FALSE;
   }

   ShowWindow(hWnd, nCmdShow);
   UpdateWindow(hWnd);

   /////////////////////////////////////////////////////////////////////////

   if(!InitOGLES()) //OpenGL ES Initialization
   {
		MessageBoxA(hWnd,"OpenGL ES init error.","Error",MB_OK | MB_ICONERROR);
		return false; 
   }
	


   return TRUE;
}

//
//  FUNCTION: WndProc(HWND, UINT, WPARAM, LPARAM)
//
//  PURPOSE:  Processes messages for the main window.
//
//  WM_COMMAND	- process the application menu
//  WM_PAINT	- Paint the main window
//  WM_DESTROY	- post a quit message and return
//
//
LRESULT CALLBACK WndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{
	int wmId, wmEvent;
	PAINTSTRUCT ps;
	HDC hdc;

	switch (message)
	{
	case WM_COMMAND:
		wmId    = LOWORD(wParam);
		wmEvent = HIWORD(wParam);
		// Parse the menu selections:
		switch (wmId)
		{
		case IDM_ABOUT:
			DialogBox(hInst, MAKEINTRESOURCE(IDD_ABOUTBOX), hWnd, About);
			break;
		case IDM_EXIT:
			DestroyWindow(hWnd);
			break;
		//case ID_VIEW_ROTATE90:
		//	break;
		default:
			return DefWindowProc(hWnd, message, wParam, lParam);
		}
		break;
	case WM_PAINT:
		hdc = BeginPaint(hWnd, &ps);
		// TODO: Add any drawing code here...
		EndPaint(hWnd, &ps);
		break;
	case WM_DESTROY:
		PostQuitMessage(0);
		break;
	default:
		return DefWindowProc(hWnd, message, wParam, lParam);
	}
	return 0;
}

// Message handler for about box.
INT_PTR CALLBACK About(HWND hDlg, UINT message, WPARAM wParam, LPARAM lParam)
{
	UNREFERENCED_PARAMETER(lParam);
	switch (message)
	{
	case WM_INITDIALOG:
		return (INT_PTR)TRUE;

	case WM_COMMAND:
		if (LOWORD(wParam) == IDOK || LOWORD(wParam) == IDCANCEL)
		{
			EndDialog(hDlg, LOWORD(wParam));
			return (INT_PTR)TRUE;
		}
		break;
	}
	return (INT_PTR)FALSE;
}
