using UnityEngine;
using System.Collections;
using define;

public class Were :Race 
{
	private Speciality Specalize = Speciality.Combat;
	private double ldr_penalty;

	public Were():base(3,ClassType.Were)
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
			Effeciency = -2;
			break;
		case ClassType.Elf :
			Effeciency = -2;
			break;
		case ClassType.Were :
			Effeciency = 2;
			break;
		default :
			Effeciency = 3;
			break;
		}
	}

	protected override void workRate(partsType pType)
	{
		switch(pType)
		{
		case partsType.Magical :
		case partsType.ManMade :
			workSpeed = 2;
			break;
		case partsType.Natural :
			workSpeed = 1;
			break;
		case partsType.Technical :
			workSpeed = 3;
			break;
		}
	}

	public override void calculateFatigue(Disaster disEvent)
	{
		double decRate;
		switch (disEvent) 
		{
		case Disaster.Dragon :
			decRate = 0.3;
			break;
		case Disaster.Ravages :
			decRate = 0.3;
			break;
		case Disaster.ThunderStorm :
			decRate = 0.5;
			break;
		case Disaster.Fog :
		default :
			decRate = 0.0;
			break;
		}
		gettingTired (decRate);
	}
}

