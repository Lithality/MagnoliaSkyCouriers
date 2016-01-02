using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VisEnvironment : MonoBehaviour {

	public IList <GameObject> clouds;
	public GameObject Clouds;
	public GameObject cloud;
	public IList<Sprite> sprites;
	public List<Vector2> movement;

	Vector2 vectorTrans;
	// Use this for initialization

	void Awake() {
		vectorTrans = new Vector2 (0, 0);
		clouds = new List<GameObject> ();
		sprites = new List<Sprite> ();
		movement = new List<Vector2> ();
		foreach(Sprite g in Resources.LoadAll("Sprites/Environment", typeof(Sprite)))
		{
			Debug.Log("prefab found: " + g.name);
			Sprite stuff = g;
			sprites.Add(stuff);
		}

	
		for (int i = 0; i < 7; i++)
		{
			vectorTrans = new Vector2((float)Random.Range((Camera.main.rect.center.x - Camera.main.rect.width) * Camera.main.orthographicSize,Camera.main.rect.width * Camera.main.orthographicSize),
			                          (float)Random.Range((Camera.main.rect.center.y - Camera.main.rect.height) * Camera.main.orthographicSize,Camera.main.rect.height * Camera.main.orthographicSize));
			Clouds = Instantiate(Resources.Load ("Level/Clouds",typeof(GameObject)),vectorTrans,Quaternion.identity) as GameObject;
			//cloud = Instantiate(Clouds,vectorTrans,Quaternion.identity) as GameObject;
			Clouds.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0,sprites.Count)];
			
			//Sprite temp = cloud.GetComponent<SpriteRenderer>().sprite;
			
			//GameObject obj = Instantiate (cloud, vectorTrans,Quaternion.identity);
			clouds.Add (Clouds);
			movement.Add(Clouds.transform.position);


			
			
		}
	}

	void Start () {



		//sprites = Resources.LoadAll ("Textures", typeof(Sprite));


	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (clouds.Count);

	


	
	}

	void FixedUpdate()
	{
		for (int i = 0; i < clouds.Count; i++)
		{

			float newX = clouds[i].transform.position.x;
			newX -= .1f;
			//movement[i].x -= 1;
			clouds[i].transform.position = new Vector3(newX,clouds[i].transform.position.y,clouds[i].transform.position.z);
		}
	}
}
