using UnityEngine;
using System.Collections;
using System.Xml.Serialization;

public class Dialog {
	
	string name;

	string Speech;

	public Dialog(string n, string s)
	{
		name = n;
		Speech = s;
	}

	public string getName()
	{
		return name;
	}

	public string getSpeech()
	{
		return Speech;
	}

}
