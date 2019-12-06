#include "CarProgram.h"

#define PassPWM 6   // pin for the passenger PWM signal 0->255.  This is proportional to the speed of the tire
#define PassFor 10   // pin to enable passenger tire forward (LOW off, HIGH forward)
#define PassRev 9   // pin to enable passenger tire reverse (LOW off, HIGH reverse)
#define PassMax 255 // maximum signal for the passenger motor

#define DrivPWM 5   // pin for the driver PWM signal 0->255.  This is proportional to the speed of the tire
#define DrivFor 8  // pin to enable driver tire forward (LOW off, HIGH forward)
#define DrivRev 7   // pin to enable driver tire reverse (LOW off, HIGH reverse)
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
		Instruction forward_6ft_str_wheel1(forward, 2575, 175, 172, 500);

		Instruction forward_6ft_str_wheel2(forward, 2780, 160, 160, 500);

		// Instructon to turn right 90 degrees
		// DO NOT CHANGE IT IS PERFECT
		Instruction right_90_str_wheel(right, 280, 160, 160, 500);
		Instruction right_90_str_wheel2(right, 280, 160, 160, 500);

		// Instruction to drive backward 6 feet
		Instruction backward_6ft_str_wheel(backward, 3100, 130, 130, 500);

		// Turn 405 degrees
		Instruction left_405_str_wheel(left, 1000, 160, 160, 500);

		Instruction turn_right_sharp(forward, 500, 210, 120);
		Instruction turn_right_slight(forward, 750, 175, 120);

		Instruction turn_left_sharp(forward, 500, 120, 210);
		Instruction turn_left_slight(forward, 500, 120, 175);

		
		car.RunInstruction(forward_6ft_str_wheel1);
		car.RunInstruction(right_90_str_wheel);
		car.RunInstruction(backward_6ft_str_wheel);
		car.RunInstruction(right_90_str_wheel2);
		car.RunInstruction(forward_6ft_str_wheel2);

		car.RunInstruction(left_405_str_wheel);
		car.RunInstruction(turn_right_sharp);
		car.RunInstruction(turn_right_slight);

		car.RunInstruction(turn_left_sharp);
		car.RunInstruction(turn_left_slight);

		car.RunInstruction(turn_right_sharp);
		car.RunInstruction(turn_right_slight);

		car.Shutdown();

		if(!loopProgram)
			running = false;
	}
}