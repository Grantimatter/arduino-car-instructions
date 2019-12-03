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

void CarProgram::RunInstruction(Instruction instructions)
{
    ActivateMotors(instructions);
    Drive(instructions);
}

void CarProgram::Shutdown()
{
    digitalWrite(passF, LOW);
    digitalWrite(passR, LOW);
    digitalWrite(drivF, LOW);
    digitalWrite(drivR, LOW);
}

void CarProgram::ActivateMotors(Instruction instructions)
{
    // Activate or Deativate passenger motor based on maneuver type
    switch (instructions.dt)
    {
        case Instruction::DriveType::forward:
            digitalWrite(drivF, HIGH);
            digitalWrite(drivR, LOW);
            digitalWrite(passF, HIGH);
            digitalWrite(passR, LOW);
        break;

        case Instruction::DriveType::backward:
            digitalWrite(drivF, LOW);
            digitalWrite(drivR, HIGH);
            digitalWrite(passF, LOW);
            digitalWrite(passR, HIGH);
        break;

        case Instruction::DriveType::right:
            digitalWrite(drivF, HIGH);
            digitalWrite(drivR, LOW);
            digitalWrite(passF, LOW);
            digitalWrite(passR, HIGH);
        break;

        case Instruction::DriveType::left:
            digitalWrite(drivF, LOW);
            digitalWrite(drivR, HIGH);
            digitalWrite(passF, HIGH);
            digitalWrite(passR, LOW);
        break;
    
    default:
        break;
    }
}

void CarProgram::Drive(Instruction instructions)
{
    motor_run(drivP, instructions.dmp, drivM);
    motor_run(passP, instructions.pmp, passM);

    // Amount of time performing action
    delay(instructions.t);
    
    Shutdown();
    delay(instructions.das);
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