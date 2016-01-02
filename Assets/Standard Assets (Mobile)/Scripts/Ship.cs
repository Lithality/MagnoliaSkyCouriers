using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using define;
//Ship class, consist of 2 child classes, facilities & Components
public class Ship :MonoBehaviour{

	//Variables
	public shipType type;
	int hitPoints = 100;
	int Speed = 1;
	public List<Facility> facilities;

	public Ship()
	{


	}


	public void initializeShipFaci(shipType type)
	{
		hitPoints = 100;
		facilities = new List<Facility> ();
		switch (type) {
		case shipType.Aviance:
			facilities.Add(new Facility(faciType.bowTurret));
			facilities.Add(new Facility(faciType.magiTurret));
			facilities.Add(new Facility(faciType.stabilizer));
			facilities.Add(new Facility(faciType.crewQuartz));
			
			break;
		case shipType.Magnolia:
			facilities.Add(new Facility(faciType.bowTurret));
			facilities.Add(new Facility(faciType.magiTurret));
			facilities.Add(new Facility(faciType.stabilizer));
			facilities.Add(new Facility(faciType.crewQuartz));
			break;
		default:
			break;
		}
	}


	public void assignTask(Race race, Facility f)
	{
		f.Assign (race);
		Debug.Log ("Task Assigned!");
	}


	public void Travel(int Dist)
	{
		Dist += Speed;
	}

	public void damageShip(int dmg)
	{
		hitPoints -= dmg;
	}

	public void repairFacility(Facility f)
	{
		f.Repair (20);
	}


	public void repairShip(int repairPt)
	{
		hitPoints += repairPt;
		if (hitPoints > 100) {
			hitPoints = 100;
		}
	}
	public int showHP()
	{
		return hitPoints;
	}

	public void printLog(GameObject g)
	{
		//GUI.Label (new Rect (100, 100, 200, 200), "Ship's Hp : " + showHP (), customStyle);
		g.GetComponent<Text> ().text = "Ship's Hp : " + showHP ();

	}

}
