#include "CarProgram.h"

#define PassPWM 5   // pin for the passenger PWM signal 0->255.  This is proportional to the speed of the tire
#define PassFor 7   // pin to enable passenger tire forward (LOW off, HIGH forward)
#define PassRev 9   // pin to enable passenger tire reverse (LOW off, HIGH reverse)
#define PassMax 254 // maximum signal for the passenger motor

#define DrivPWM 6  // pin for the driver PWM signal 0->255.  This is proportional to the speed of the tire
#define DrivFor 10  // pin to enable driver tire forward (LOW off, HIGH forward)
#define DrivRev 8  // pin to enable driver tire reverse (LOW off, HIGH reverse)
#define DrivMax 255 // maximum signal for the driver motor

// Keep this, Arduino won't compile without it
void setup(){}

// Create bool so loop will end 
bool running = true, loopProgram = false;
void loop()
{
	if (running)
	{
		CarProgram car = CarProgram(PassPWM, PassFor, PassRev, PassMax, DrivPWM, DrivFor, DrivRev, DrivMax);

		Instruction::DriveType forward = Instruction::DriveType::forward;
		Instruction::DriveType backward = Instruction::DriveType::backward;
		Instruction::DriveType right = Instruction::DriveType::right;
		Instruction::DriveType left = Instruction::DriveType::left;
		
		// Instruction to drive forward 6 feet from start
		Instruction forward_6ft_str_wheel = Instruction(forward, 3100, 150, 125, 200);

		Instruction forward_1sec_str_wheel = Instruction(forward, 500, 148, 150, 200);

		// Instructon to turn right 90 degrees
		// DO NOT CHANGE IT IS PERFECT
		Instruction right_90_str_wheel = Instruction(right, 235, 158, 160, 250);
		
		// Reverse with wheel at 45 after right 90 turn
		Instruction backward_1sec_45_wheel = Instruction(backward, 500, 175, 100, 250);
		// Instruction to drive backward 6 feet
		Instruction backward_6ft_str_wheel(backward, 3100, 125, 125, 250);

		Instruction DriverForward = Instruction(forward, 1000, 100, 0, 1000);
		Instruction DriverReverse = Instruction(backward, 1000, 100, 0, 1000);
		Instruction PassForward = Instruction(forward, 1000, 0, 100, 1000);
		Instruction PassReverse = Instruction(backward, 1000, 0, 100, 1000);

		car.RunInstruction(DriverForward);
		car.RunInstruction(DriverReverse);
		car.RunInstruction(PassForward);
		car.RunInstruction(PassReverse);

		//car.RunInstruction(forward_6ft_str_wheel);
		//car.RunInstruction(forward_1sec_str_wheel);
		//car.RunInstruction(right_90_str_wheel);
		//car.RunInstruction(backward_1sec_45_wheel);
		//car.RunInstruction(backwardSixFeet);
		//car.RunInstruction(turnRight90);
		//car.RunInstruction(forwardSixFeet);

		car.Shutdown();

		if(!loopProgram)
			running = false;
	}
}