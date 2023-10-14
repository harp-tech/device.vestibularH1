#ifndef _MOTIONHEADER_
#define _MOTIONHEADER_
#include "cpu.h"

typedef struct Motion {
	/*uint8_t dummy[2];*/
	uint8_t isMotion;
	uint8_t isOnSurface;
	int16_t deltaA;
	int16_t deltaB;
	uint8_t Squal;
} Motion;

#endif /* _MOTIONHEADER_ */