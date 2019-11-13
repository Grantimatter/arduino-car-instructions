#include "Car.h"
//#include "libraries/Instructions.h"

#define PassPWM 9   // pin for the passenger PWM signal 0->255.  This is proportional to the speed of the tire
#define PassFor 8   // pin to enable passenger tire forward (LOW off, HIGH forward)
#define PassRev 7   // pin to enable passenger tire reverse (LOW off, HIGH reverse)
#define PassMax 233 // maximum signal for the passenger motor

#define DrivPWM 10  // pin for the driver PWM signal 0->255.  This is proportional to the speed of the tire
#define DrivFor 12  // pin to enable driver tire forward (LOW off, HIGH forward)
#define DrivRev 13  // pin to enable driver tire reverse (LOW off, HIGH reverse)
#define DrivMax 249 // maximum signal for the driver motor

// Keep this, Arduino won't compile without it
void setup(){}

// Create bool so loop will end 
bool running = true, loopProgram = false;
void loop()
{
	if (running)
	{
		Car car = Car(PassPWM, PassFor, PassRev, PassMax, DrivPWM, DrivFor, DrivRev, DrivMax);
		Instructions F1 = Instructions(2000, 1, 0, 255, 0, 1);
		Instructions F2 = Instructions(1000, 1, 100, 255, 100, 1, 100, 255);
		Instructions SHUTDOWN = Instructions(0, 0, 0, 0, 0, 0, 0, 0);

		car.RunInstruction(F1);


		
		car.RunInstruction(SHUTDOWN);

		if(!loopProgram)
			running = false;
	}
}