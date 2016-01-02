using UnityEngine;
using System.Collections;
using define;

public abstract class Race
{
	private int Resource;
	private double fatigue;
	private const double panic_redux = 2;
	protected int workSpeed;
	protected int Effeciency;
	protected double workEffec;
	private ClassType type = ClassType.Null;
	private bool tired = false;

	public Race (int resc,  ClassType tp)
	{
		Resource = resc;
		fatigue = 100.0;
		type = tp;

	}

	public ClassType getType()
	{
		return type;
	}

	public int getResource()
	{
		return Resource;
	}

	public double getFatigueLv()
	{
		return fatigue;
	}

	public double getWork()
	{
		return workEffec;
	}

	public void gettingTired(double rate)
	{
		fatigue -= (rate * 1);
		if (fatigue < 0.0) 
		{
			fatigue = 0.0;
			tired = true;
		}
		//fatigueRecovery ();
	}

	public void fatigueRecovery()
	{
		fatigue += panic_redux;
		if (fatigue > 100.0)
		{
			fatigue = 100.0;
			tired = false;
		}
	}

	public void calculateWorkEffec(partsType pt, ClassType c = ClassType.Null)
	{
		Relation (c);
		workRate (pt);
		
		workEffec = workSpeed * Effeciency;// * (getPanicTH() / 100);
	}
	public abstract void calculateFatigue(Disaster disEvent);
	protected abstract void Relation(ClassType c);
	protected abstract void workRate(partsType pType);

}

