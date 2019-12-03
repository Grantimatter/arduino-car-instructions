#include "CarProgram.h"

#define PassPWM 5   // pin for the passenger PWM signal 0->255.  This is proportional to the speed of the tire
#define PassFor 8   // pin to enable passenger tire forward (LOW off, HIGH forward)
#define PassRev 7   // pin to enable passenger tire reverse (LOW off, HIGH reverse)
#define PassMax 255 // maximum signal for the passenger motor

#define DrivPWM 6  // pin for the driver PWM signal 0->255.  This is proportional to the speed of the tire
#define DrivFor 10  // pin to enable driver tire forward (LOW off, HIGH forward)
#define DrivRev 9  // pin to enable driver tire reverse (LOW off, HIGH reverse)
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
		Instruction forwardSixFeet = Instruction(forward, 3100, 150, 125, 125);

		// Instructon to turn right 90 degrees
		Instruction turnRight90 = Instruction(right, 310, 125, 125, 250);

		// Instruction to drive backward 6 feet
		Instruction backwardSixFeet(backward, 3100, 125, 125, 250);

		car.RunInstructionn(forwardSixFeet);
		car.RunInstruction(turnRight90);
		car.RunInstruction(backwardSixFeet);
		car.RunInstruction(turnRight90);
		car.RunInstruction(forwardSixFeet);

		car.Shutdown();

		if(!loopProgram)
			running = false;
	}
}