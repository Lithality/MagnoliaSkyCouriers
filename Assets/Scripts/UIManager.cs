using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	[SerializeField]
	Button btn;

	// Use this for initialization
	void Start () {

		btn.gameObject.transform.DOPunchRotation (new Vector3 (0, 0, 90), 3.0f, 10, 1).SetUpdate (true);


	
	}
	
	// Update is called once per frame
	void Update () {
	


	}

	public void loadLevel(string s)
	{
		Application.LoadLevel (s);
	}
}
