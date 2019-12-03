#ifndef Instructions_h
#define Instructions_h

#if ARDUINO >= 100
#include "Arduino.h"
#else
#include "WProgram.h"
#include "pins_arduino.h"
#include "WConstants.h"
#endif

class Instruction
{
  public:
    enum class DriveType
    {
      forward,
      right,
      left,
      backward
    };

    

    Instruction(DriveType driveType, int time, int drivMotorPower, int passMotorPower, int delayAfterStop = 0)
    {
      dt = driveType;
      t = time;
      dmp = drivMotorPower;
      pmp = passMotorPower;
      das = delayAfterStop;
    }

    int t, dmp, pmp, das;
    DriveType dt;
    
};
#endif