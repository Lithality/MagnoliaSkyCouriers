using UnityEngine;
using System.Collections;
using define;

public class Elf : Race
{
	private Speciality Specalize = Speciality.Magic;
	private double ldr_penalty;

	public Elf():base(2,ClassType.Elf)
	{
	}

	protected override void Relation(ClassType c)
	{
		switch (c) 
		{
		case ClassType.Fairy :
			Effeciency = 2;
			break;
		case ClassType.Human :
			Effeciency = -1;
			break;
		case ClassType.Elf :
			Effeciency = 2;
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
			workSpeed = 3;
			break;
		case partsType.Natural :
			workSpeed = 2;
			break;
		case partsType.ManMade :
		case partsType.Technical :
			workSpeed = 1;
			break;
		}
	}

	public override void calculateFatigue(Disaster disEvent)
	{
		double decRate;
		switch (disEvent) 
		{
		case Disaster.Dragon :
			decRate = 0.4;
			break;
		case Disaster.Ravages :
			decRate = 0.4;
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

