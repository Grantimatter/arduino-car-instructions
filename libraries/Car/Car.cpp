//#include <Arduino.h>
#include "Car.h"
#include <Arduino.h>

/*
void Car::Initialize()
{
    // Don't change this part.  It needs to be here to set up the pins for output later.
   
}
*/

Car::Car(int passPWM, int passFor, int passRev, int passMax, int drivPWM, int drivFor, int drivRev, int drivMax)
{
    passP = passPWM;
    passF = passFor;
    passR = passRev;
    passM = passMax;

    drivP = drivPWM;
    drivF = drivFor;
    drivR = drivRev;
    drivM = drivMax;

    pinMode(passP, OUTPUT);
    pinMode(passF, OUTPUT);
    pinMode(passR, OUTPUT);
    pinMode(drivP, OUTPUT);
    pinMode(drivF, OUTPUT);
    pinMode(drivR, OUTPUT);
}

void Car::RunInstruction(Instructions instructions)
{
    if (!initialized)
        Initialize();
    Drive(instructions);
}

void Car::Drive(Instructions instructions)
{
    for (int i(instructions.rsv); i < instructions.ruev; i++)
    {
        motor_run(drivP, i, drivM);
        motor_run(passP, i, passM);
        delay(instructions.rut);
    }

    // Amount of time to run at full speed
    delay(instructions.t);

    // Ramping down from full throttle
    for (int i(instructions.ruev); i > instructions.rdev; i--)
    {
        motor_run(drivP, i, drivM);
        motor_run(passP, i, passM);
        delay(instructions.rdt);
    }
}

void Car::Shutdown()
{
    digitalWrite(passP, LOW);
    digitalWrite(passR, LOW);
    digitalWrite(drivP, LOW);
    digitalWrite(drivR, LOW);
}

void Car::motor_run(int pin, int PWM, int PWMMax)
{
    if (PWM > PWMMax)
    {
        analogWrite(pin, PWMMax);
    }
    else
    {
        analogWrite(pin, PWM);
    }
    return;
}