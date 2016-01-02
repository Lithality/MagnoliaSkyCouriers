using UnityEngine;
using System.Collections;
using define;

public class CrewSelectionScript : MonoBehaviour {


	// Use this for initialization
	void Start () {
	


	}


	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.A) && UIManager.leaderSelected) {

			Application.LoadLevel (1);
		}

	
	}

	public static Race setLeader() {
		//Human by default
		Race leader = new Human();
		switch (UIManager.leader) {
		case "Human":
			leader = new Human();
			break;
		case "Fairy":
			leader = new Fairy();
			break;
		case "Elf":
			leader = new Elf();
			break;
		case "Were":
			leader = new Were();
			break;
				}
		return leader;



	}




}
