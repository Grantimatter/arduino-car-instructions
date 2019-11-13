#ifndef Instructions_h
#define Instructions_h

#if ARDUINO >= 100
  #include "Arduino.h"
#else
  #include "WProgram.h"
  #include "pins_arduino.h"
  #include "WConstants.h"
#endif

#include <Arduino.h>

enum DriveType
{
	forward,
	backward,
	turn,
	turnInPlace
};

class Instructions
{
    public:
	Instructions(DriveType driveType, int timeSpentAtEndValue, int rampUpTimestep, int rampStartingValue, int rampUpEndValue, int rampDownEndValue, int rampDownTimestep, int drivMotorPower = 255, int passMotorPower = 255)
	{
		dt = driveType;
		t = timeSpentAtEndValue;
		rut = rampUpTimestep;
		rsv = rampStartingValue;
		ruev = rampUpEndValue;
		rdev = rampDownEndValue;
		rdt = rampDownTimestep;
		dmp = drivMotorPower;
		pmp = passMotorPower;
	}

    private:
	int dt, t, rut, rsv, ruev, rdev, rdt, dmp, pmp;

};
#endif