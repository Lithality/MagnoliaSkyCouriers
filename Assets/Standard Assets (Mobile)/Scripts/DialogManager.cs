using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;


public class DialogManager : MonoBehaviour // the Class
{
	public TextAsset GameAsset;
	public Texture2D chatBox;
	public Rect chatRectangle;
	public float letterPause = 20f;
	List<Dialog> Dialogs;
	string name = "Default";
	string speech = "Default";
	string emptySpeech = "";
	int index = 0;
	public GUIStyle customStyle;
		

	void OnGUI()
	{
		GUI.Label (new Rect (Screen.width /2, 10, 100,50), "" + Dialogs[index].getName(),customStyle);
		GUI.Label (new Rect (chatRectangle.x,chatRectangle.y, chatRectangle.width,chatRectangle.height), "" + emptySpeech,customStyle);
		GUI.DrawTexture (chatRectangle, chatBox);

	}
	
	void Start()
	{ 

		chatRectangle = new Rect (Screen.width * 0.1f, Screen.height * 0.6f, (float)chatBox.width * 3, (float)chatBox.height * 1.5f);


		//Timeline of the Level creator
		Dialogs = new List<Dialog> ();
		GetDialog ();
		StartCoroutine(TypeText (Dialogs[index].getSpeech()));
	}

	void Update()
	{
		if (Input.GetButtonDown ("Jump") && index < Dialogs.Count - 1) {


				index += 1;
			StartCoroutine(TypeText (Dialogs[index].getSpeech()));

				}
	}

	IEnumerator TypeText (string speech) {
		emptySpeech = "";
		foreach (char letter in speech) {
			emptySpeech += letter;
			yield return 0;
			yield return new WaitForEndOfFrame();
		}      
	}

	public void GetDialog()
	{
		XmlDocument xmlDoc = new XmlDocument(); // xmlDoc is the new xml document.
		xmlDoc.LoadXml(GameAsset.text); // load the file.
		XmlNodeList DialogList = xmlDoc.GetElementsByTagName("Dialog"); // array of the level nodes.
		
		foreach (XmlNode Content in DialogList)
		{
			XmlNodeList speechcontent = Content.ChildNodes;

			foreach (XmlNode Attribute in speechcontent) // levels itens nodes.
			{

				if(Attribute.Name == "name")
				{
					name = Attribute.InnerText;
				}
				
				if(Attribute.Name == "Speech")
				{
					speech = Attribute.InnerText;
				}
				

			}
			Dialog d = new Dialog(name,speech);
			Dialogs.Add(d);
			Debug.Log ("Added" + d.getName());
		}
	}
}