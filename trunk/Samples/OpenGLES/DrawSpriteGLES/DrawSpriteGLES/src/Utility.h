#pragma once

#include <time.h>
class CUtility
{
public:
	CUtility(void);
	~CUtility(void);
	static inline unsigned long GetTime(){return clock();}
};
