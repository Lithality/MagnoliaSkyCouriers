using UnityEngine;
using System.Collections;
using define;

public class UIManager : MonoBehaviour {

	public GUIStyle customStyle;
	public static string leader;
	int currentScene;
	public static bool leaderSelected = false;
	GameObject txt_1,txt_2,txt_3,txt_4;

	void OnGUI() {
		Debug.Log (currentScene);
		switch (currentScene) {
		case 0:
			GUI.Label (new Rect (Screen.width / 4, 70, 200, 200), "Please press 'A' to set leader", customStyle);
			GUI.Label (new Rect (Screen.width / 2, 180, 200, 200), "Choosse a Race for your leader.\n[1] Human\n" +
			           "[2] Fairy\n[3] Elf\n[4] Were ", customStyle);
			GUI.Label (new Rect (50, 70, 200, 200), "Leader : " + leader, customStyle);
			break;
		case 1:
			//MainGame.eventM.printLog(customStyle);
			//MainGame.crewmem.printLog(customStyle);
			//MainGame.ship.printLog(customStyle);
			MainGame.crewmem.printLog(customStyle);
			break;



				}





	}

	void Awaken() {

	}

	// Use this for initialization
	void Start () {

		currentScene = Application.loadedLevel;
		txt_1 = GameObject.Find ("lbl_1");
		txt_2 = GameObject.Find ("lbl_2");
		txt_3 = GameObject.Find ("lbl_3");
		txt_4 = GameObject.Find ("lbl_4");

	
	}
	
	// Update is called once per frame
	void Update () {
		switch (currentScene) {
		case 0:
			selectLeader ();


			break;
		case 1:
			MainGame.eventM.printLog(txt_1,txt_2,txt_3);

			MainGame.ship.printLog(txt_4);
			break;
		
				}
		 

		/*
		if (Input.GetKeyDown (KeyCode.A) && leaderSelected) {
			crewmem.setLeader(ldr);
			Application.LoadLevel (1);
		}
		*/
	

	
	}




	void selectLeader(){

		//Race ldr = new Human ();
		if (Input.GetKeyDown (KeyCode.Alpha1)){
			leader = "Human";
			leaderSelected = true;
		}
		if (Input.GetKeyDown (KeyCode.Alpha2)){
			leader = "Fairy";
			leaderSelected = true;
		}
		if (Input.GetKeyDown (KeyCode.Alpha3)){
			leader = "Elf";
			leaderSelected = true;
		}
		if (Input.GetKeyDown (KeyCode.Alpha4)){
			leader = "Were";
			leaderSelected = true;
		}


	}
}
