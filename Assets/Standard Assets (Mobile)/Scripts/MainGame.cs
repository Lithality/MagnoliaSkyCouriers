using UnityEngine;
using System.Collections;
using define;

public class MainGame : MonoBehaviour {

	float TotalDist = 5000;
	public float DistTravelled = 0;
	public static EventManager eventM;

	public static Ship ship;
	public GUIStyle customStyle;
	bool ldr_chosen, sel;
	Disaster dEvent;
	int randNum = 4;
	Race ldr;
	public static Crew crewmem;
	bool isGame = true;
	public GameObject Ship;
	int randCrew;
	void OnGUI()
	{

		GUI.Label (new Rect (Screen.width / 4, 50, 200, 200), "" + DistTravelled, customStyle);

		/*
		if (DistTravelled == 50) {


		} else if (DistTravelled > 50) {
			GUI.Label (new Rect (Screen.width / 4, 70, 200, 200), "Please press 'B' to Fix ship", customStyle);
			GUI.Label (new Rect (Screen.width / 4, 140, 200, 200), "Current fatigue lv of " + crewmem.getChar(crewmem.crewMember) + " : " 
			           + (int)crewmem.getFatigueLv(crewmem.crewMember), customStyle);
			crewmem.printLog(customStyle);
		}
		*/
		GUI.Label (new Rect (Screen.width / 4, 120, 200, 200), "Current Disaster :" + dEvent, customStyle);

	}

	void Awaken() {



	}

	// Use this for initialization
	void Start () {
		Ship = Instantiate (Resources.Load ("Core/Ship",typeof(GameObject)), Vector2.zero,Quaternion.identity) as GameObject;
		ship = Ship.GetComponent<Ship> ();
		//ship = GameObject.Find ("Ship(Clone)").GetComponent<Ship> ();
		ship.initializeShipFaci (shipType.Magnolia);
		crewmem = gameObject.GetComponent<Crew> ();
		crewmem.setLeader (CrewSelectionScript.setLeader ());
		ldr_chosen = false;
		randCrew = Random.Range (0, 4);
		sel = false;
		eventM = gameObject.GetComponent<EventManager> ();
	

	}
	
	// Update is called once per frame
	void Update () {

		var numberOfDisaster = System.Enum.GetValues (typeof(Disaster));



		if (DistTravelled == 50) {


		}
		//changes e Disaster based on e distance travelled
		dEvent = (Disaster)numberOfDisaster.GetValue(randNum);
		if (DistTravelled % 450 == 0) {
			randNum = Random.Range (0, numberOfDisaster.Length);
		}
		
		if (isGame) {
			DistTravelled ++;
			eventM.UpdateEvents (DistTravelled, TotalDist, ship, crewmem, dEvent, randCrew);
			eventM.ManageEvents ();
		}
	}


}
