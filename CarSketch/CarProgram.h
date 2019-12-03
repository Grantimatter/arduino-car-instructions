#ifndef CarProgram_h
#define CarProgram_h

#if ARDUINO >= 100
#include "Arduino.h"
#else
#include "WProgram.h"
#include "pins_arduino.h"
#include "WConstants.h"
#endif

#include "Instruction.h"

class CarProgram
{
  public:
    CarProgram(int passPWM, int passFor, int passRev, int passMax, int drivPWM, int drivFor, int drivRev, int drivMax);

    void RunInstruction(Instruction);
    void Shutdown();

  private:
    int passP, passF, passR, passM, drivP, drivF, drivR, drivM;
    bool initialized;

    void Drive(Instruction);
    void ActivateMotors(Instruction);
    void motor_run(int pin, int PWM, int PWMMax);
};

#endif