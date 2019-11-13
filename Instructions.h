#ifndef Instructions_h
#define Instructions_h

#if ARDUINO >= 100
#include "Arduino.h"
#else
#include "WProgram.h"
#include "pins_arduino.h"
#include "WConstants.h"
#endif

class Instructions
{
public:
  Instructions(int timeSpentAtEndValue, int rampUpTimestep, int rampStartingValue, int rampUpEndValue, int rampDownEndValue, int rampDownTimestep, int drivMotorPower = 255, int passMotorPower = 255)
  {
    t = timeSpentAtEndValue;
    rut = rampUpTimestep;
    rsv = rampStartingValue;
    ruev = rampUpEndValue;
    rdev = rampDownEndValue;
    rdt = rampDownTimestep;
    dmp = drivMotorPower;
    pmp = passMotorPower;
  }

  int t, rut, rsv, ruev, rdev, rdt, dmp, pmp;

private:
};
#endif