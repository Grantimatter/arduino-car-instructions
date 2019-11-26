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
		
		// Fix the power variable
		Instructions DOAFLIP = Instructions(2000, 10, 175, 100, 100, 10, 255, 255);
		Instructions doATurn = Instructions(2000, 10, 175, 200, 100, 10, 75, 255);
		Instructions ForwardGainMomentum = Instructions(2000, 0, 150, 200, 100, 10, 200, 200);
		Instructions Forward = Instructions(0, 0, 100, 100, 0, 10, 100, 100);
		Instructions Turn = Instructions(800, 10, 150, 150, 0, 10, -150, 150);
		Instructions Reverse = Instructions(3000, 10, 150, 150, 0, 10, -150, -150);

		car.RunInstruction(ForwardGainMomentum);
		car.RunInstruction(Forward);
		car.RunInstruction(Turn);
		car.RunInstruction(Reverse);
		//car.RunInstruction(doATurn);

		Instructions SHUTDOWN = Instructions(0, 0, 0, 0, 0, 0, 0, 0);

		//car.RunInstruction(F1);
		
		car.RunInstruction(SHUTDOWN);

		if(!loopProgram)
			running = false;
	}
}