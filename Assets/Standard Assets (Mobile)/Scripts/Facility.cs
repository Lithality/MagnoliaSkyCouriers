using UnityEngine;
using System.Collections;
using define;
public class Facility {

	int hitPoints = 100;
	int resourceReq;
	int resourceCount;
	faciType fType;

	// Use this for initialization
	public Facility(faciType type)
	{
		//Keep track of what events this facility deals with


		fType = type;
		resourceCount = 0;
		switch (fType) {
		case faciType.bowTurret:

			resourceReq = 5;

			break;

		case faciType.magiTurret:

			resourceReq = 5;

			break;
		case faciType.crewQuartz:

			resourceReq = 0;

			break;
		case faciType.stabilizer:

			resourceReq = 7;

			break;


				}



	}

	public void Repair(int hp)
	{
		hitPoints += hp;
	}
	
	public void Assign(Race crew)
	{

		resourceCount += crew.getResource ();


	}

	void Running(Race crew) {
		if (resourceCount >= resourceReq) {

						switch (fType) {
						case faciType.bowTurret:


			
								break;
			
						case faciType.magiTurret:
			

								break;
						case faciType.crewQuartz:
			

			
								break;
						case faciType.stabilizer:
			

			
								break;
			
			
						}
				}



	}
	

}
