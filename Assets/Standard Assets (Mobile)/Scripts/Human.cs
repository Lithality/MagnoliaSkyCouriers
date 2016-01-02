using UnityEngine;
using System.Collections;
using define;

public class Human : Race
{
	private Speciality Specalize = Speciality.Negotiation;
	private double ldr_penalty;

	public Human():base(2,ClassType.Human)
	{
	}

	protected override void Relation(ClassType c)
	{
		switch (c) 
		{
		case ClassType.Fairy :
			Effeciency = 1;
			break;
		case ClassType.Human :
			Effeciency = 2;
			break;
		case ClassType.Elf :
			Effeciency = -1;
			break;
		case ClassType.Were :
			Effeciency = -2;
			break;
		default :
			Effeciency = 2;
			break;
		}
	}

	protected override void workRate(partsType pType)
	{
		switch(pType)
		{
		case partsType.Magical :
		case partsType.Natural :
			workSpeed = 1;
			break;
		case partsType.ManMade :
		case partsType.Technical :
			workSpeed = 2;
			break;
		}
	}
	
	/*public override void calculateWorkEffec(partsType pt, ClassType c = ClassType.Null)
	{
		Relation (c);
		workRate (pt);
		workEffec = workSpeed * Effeciency * (getPanicTH () / 100);
	}*/
	
	public override void calculateFatigue(Disaster disEvent)
	{
		double decRate;
		switch (disEvent) 
		{
		case Disaster.Dragon :
			decRate = 0.4;
			break;
		case Disaster.Ravages :
			decRate = 0.3;
			break;
		case Disaster.ThunderStorm :
			decRate = 0.4;
			break;
		case Disaster.Fog :
		default :
			decRate = 0.0;
			break;
		}
		gettingTired (decRate);
	}
}

