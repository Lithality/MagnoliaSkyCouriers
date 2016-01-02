using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using define;

public class EventManager :MonoBehaviour{

	List <string> eventLog;
	List <Event> eventList;
	int debugCounter = 1;
	float percentDist = 0;
	bool toFix = false;
	int selectedCrew = -1;
	// Use this for initialization
	public EventManager () {
		eventLog = new List<string> ();
		eventList = new List<Event> ();
		debugCounter = 1;
		percentDist = 0;
	}
	

	public Event AddEvent()
	{
		int randNum = Random.Range (0, 2);
		//Debug.Log (randNum);
		Event e;
		if (randNum == 0) {
			e = new Event (Disaster.Dragon);
		} else {
			e = new Event (Disaster.Ravages);
		}
		return  e;
	}


	//#####################
	public void UpdateEvents(float distTravel, float totalDist, Ship ship, Crew crewm, Disaster dEvent, int cre)
	{
		percentDist = distTravel / totalDist * 100;
		//Debug.Log (percentDist);
		if (percentDist == 10) {
			eventList.Add(AddEvent());
			eventLog.Add (eventList[eventList.Count - 1].getEventString(0));
		}

		// Updates weather and damage to ship
		if (dEvent != Disaster.Normal && dEvent != Disaster.Fog) {
			if (distTravel % 70 == 0){
				ship.damageShip(9);
			}
		}

		//if (ship.showHP () < 100)
		//{
			selectedCrew = crewm.selectRace();
		//}

		if (distTravel % 50 == 0) {
			crewm.updateCrewWorkEffeciency (selectedCrew, partsType.Natural, dEvent);
		}

		//fixing of the ship...
		if (Input.GetKeyDown (KeyCode.B)) {
			Debug.Log (selectedCrew);
			toFix = true;
		}
		if (ship.showHP() >= 100)
		{
			toFix = false;
			crewm.setFatigue (toFix, selectedCrew, dEvent);
			selectedCrew = -1;
		}


		if (selectedCrew != -1) {
			crewm.setFatigue (toFix, selectedCrew, dEvent);
			//if (crewm.getFatigueLv(selectedCrew) <= 0){toFix = false;}
			//Debug.Log ("crew Selected " + selectedCrew);
			if (distTravel % 10 == 0) {
				if (toFix && crewm.getFatigueLv(selectedCrew) > 0){
					Debug.Log ("crew Fixing " + selectedCrew);
					fixShip (ship, crewm, selectedCrew);
				}else{toFix = false;}
			}
		}


	}

	public void fixShip(Ship ship, Crew crewm, int crew)
	{
		ship.repairShip((int)crewm.getCrewWork(selectedCrew));
	}
	//#####################

	public void ManageEvents()
	{
		if (eventList.Count > 0) {
			for (int i = 0; i < eventList.Count; i ++)
			{
				if (eventList[i].checkEventEnd() == false)
				{
					eventList[i].update();
				}
				else
				{
					eventLog.Add (eventList[eventList.Count - 1].getEventString(1));
					eventList.RemoveAt(i);
				}
			}
		}
	}


	public  void printLog(GameObject g1, GameObject g2, GameObject g3) {
		int offset = 50;
		if (eventLog.Count > 0) {
			for (int i = 0; i < eventLog.Count; i++) {
				//GUI.Label (new Rect (Screen.width / 2, i * offset, 200, 200), "" + eventLog [i], customStyle);
				g1.GetComponent<Text>().text = "" + eventLog [i];
			}
		}
		if (eventLog.Count > 3)
		{
			eventLog.RemoveAt(0);
		}
		for (int i = 0; i < eventList.Count; i++) {
			//GUI.Label (new Rect (Screen.width / 2 - 100, i * offset, 200, 200), "" + eventList[i].getEventDuration().ToString(), customStyle);
			g1.GetComponent<Text>().text =  "" + eventList[i].getEventDuration().ToString();
		}

		//###display crew action....now oni 1 crew member, fairy
		if (toFix) 
		{
			g3.GetComponent<Text>().text =  "Fixing Ship";
			//GUI.Label (new Rect (140, 4 * offset, 50, 10), "Fixing Ship", customStyle);
		}
		else 
		{
			g3.GetComponent<Text>().text =  "Crew on Idle";
			//GUI.Label (new Rect (140, 4 * offset, 50, 10), "Crew on Idle", customStyle);
		}

	}
}
