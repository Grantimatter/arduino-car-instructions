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
    ActivateMotors(instructions);
    Drive(instructions);
}

void Car::ActivateMotors(Instructions instructions)
{
    // Activate or Deativate passenger motor based on motor power (+ or -)
    if (instructions.pmp > 0)
    {
        digitalWrite(passF, HIGH);
        digitalWrite(passR, LOW);
    }
    else if (instructions.pmp < 0)
    {
        digitalWrite(passF, LOW);
        digitalWrite(passR, HIGH);

        instructions.pmp = abs(instructions.pmp);
    }
    else
    {
        digitalWrite(passF, LOW);
        digitalWrite(passR, LOW);
    }

    // Activate or Deativate driver motor based on motor power (+ or -)
    if (instructions.dmp > 0)
    {
        digitalWrite(drivF, HIGH);
        digitalWrite(drivR, LOW);
    }
    else if (instructions.dmp < 0)
    {
        digitalWrite(drivF, LOW);
        digitalWrite(drivR, HIGH);

        instructions.dmp = abs(instructions.dmp);
    }
    else
    {
        digitalWrite(drivF, LOW);
        digitalWrite(drivR, LOW);
    }
}

void Car::Drive(Instructions instructions)
{
    // Motor acceleration
    for (int i(instructions.rsv); i < instructions.ruev; i++)
    {
        motor_run(drivP, i, drivM);
        motor_run(passP, i, passM);
        delay(instructions.rut);
    }

    // Amount of time to run at full speed
    delay(instructions.t);

    // Motor deceleration
    for (int i(instructions.ruev); i > instructions.rdev; i--)
    {
        motor_run(drivP, i, drivM);
        motor_run(passP, i, passM);
        delay(instructions.rdt);
    }
}

void Car::Shutdown()
{
    digitalWrite(passF, LOW);
    digitalWrite(passR, LOW);
    digitalWrite(drivF, LOW);
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