#include "CarProgram.h"
#include <Arduino.h>

CarProgram::CarProgram(int passPWM, int passFor, int passRev, int passMax, int drivPWM, int drivFor, int drivRev, int drivMax)
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

void CarProgram::RunInstruction(Instructions instructions)
{
    ActivateMotors(instructions);
    Drive(instructions);
}

void CarProgram::ActivateMotors(Instructions instructions)
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

void CarProgram::Drive(Instructions instructions)
{
    // Motor acceleration
    for (int i(instructions.rsv); i < instructions.ruev; i++)
    {
        motor_run(drivP, i, instructions.dmp);
        motor_run(passP, i, instructions.pmp);
        delay(instructions.rut);
    }

    // Amount of time to run at full speed
    delay(instructions.t);

    // Motor deceleration
    for (int i(instructions.ruev); i > instructions.rdev; i--)
    {
        motor_run(drivP, i, instructions.dmp);
        motor_run(passP, i, instructions.pmp);
        delay(instructions.rdt);
    }
}

void CarProgram::Shutdown()
{
    digitalWrite(passF, LOW);
    digitalWrite(passR, LOW);
    digitalWrite(drivF, LOW);
    digitalWrite(drivR, LOW);
}

void CarProgram::motor_run(int pin, int PWM, int PWMMax)
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