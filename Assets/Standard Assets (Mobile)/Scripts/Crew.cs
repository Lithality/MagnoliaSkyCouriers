using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using define;

public class Crew : MonoBehaviour
{
	public Race leader;
	public List<Race> crews;
	public double crewMorale;
	public int crewMember = 0;
	int sel = 0;
	public Crew ()
	{


	}

	public void initializeCrewMembers()
	{
		crews = new List<Race>();
		crews.Add(new Elf ());
		crews.Add(new Fairy ());
		crews.Add(new Human ());
		crews.Add(new Were ());
		crews.Add(leader);
	}

	public void updateCrewWorkEffeciency(int charc, partsType part, Disaster dEvent, ClassType c = ClassType.Null)
	{
		crews [charc].calculateWorkEffec (part, c);
	}

	public int findChar(ClassType c)
	{
		int count = 0;
		foreach (Race r in crews)
		{
			if (r.getType().Equals(c))
			{
				return count;
			}
			count++;
		}
		return count;
	}

	public void setLeader(Race ldrChoice)
	{
		leader = ldrChoice;
		initializeCrewMembers ();
	}

	public Race getLeader()
	{
		return leader;
	}

	public double getCrewWork(int charc)
	{
		return crews [charc].getWork ();
	}

	public double getFatigueLv(int charc)
	{
		return crews [charc].getFatigueLv ();
	}

	public ClassType getChar(int charc)
	{
		return crews [charc].getType();
	}


	public void setFatigue(bool working, int crew, Disaster dEvent)
	{
		if (working) 
		{
			crews [crew].calculateFatigue (dEvent);
		} else {
			crews[crew].fatigueRecovery();
		}
	}


	public int selectRace()
	{
		if (Input.GetKeyDown (KeyCode.Alpha1)){
			sel = 0;
		}
		else if (Input.GetKeyDown (KeyCode.Alpha2)){
			sel = 1;
		}
		else if (Input.GetKeyDown (KeyCode.Alpha3)){
			sel = 2;
		}
		else if (Input.GetKeyDown (KeyCode.Alpha4)){
			sel = 3;
		}
		else if (Input.GetKeyDown (KeyCode.Alpha5)){
			sel = 4;
		}
		else if (Input.GetKeyDown (KeyCode.C)){
			crewMember = sel;
			return crewMember;
		}
		return sel;
	}


	public void printLog(GUIStyle customStyle) {
		GUI.Label (new Rect (10, 150, 50, 10), "Selecting : " +crews[sel], customStyle);
		GUI.Label (new Rect (10, 170, 50, 10), "Crew Selected : " +crews[crewMember], customStyle);
		GUI.Label (new Rect (10, 200, 50, 10), "" +crews[crewMember], customStyle);
	}
}

