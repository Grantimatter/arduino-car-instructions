#ifndef Car_h
#define Car_h

#if ARDUINO >= 100
#include "Arduino.h"
#else
#include "WProgram.h"
#include "pins_arduino.h"
#include "WConstants.h"
#endif

#include "Instructions.h"

class Car
{
  public:
    Car(int passPWM, int passFor, int passRev, int passMax, int drivPWM, int drivFor, int drivRev, int drivMax);

    void RunInstruction(Instructions);

  private:
    int passP, passF, passR, passM, drivP, drivF, drivR, drivM;
    bool initialized;

    void Drive(Instructions);
    void Shutdown();
    void ActivateMotors(Instructions);
    void motor_run(int pin, int PWM, int PWMMax);
};

#endif