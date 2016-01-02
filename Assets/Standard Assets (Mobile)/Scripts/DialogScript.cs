using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("DialogScript")]
public class DialogScript
{
	[XmlArray("Dialogs"),XmlArrayItem("Dialog")]
	public Dialog[] dialogs;
	
	public void Save(string path)
	{
		var serializer = new XmlSerializer(typeof(DialogScript));
		using(var stream = new FileStream(path, FileMode.Create))
		{
			serializer.Serialize(stream, this);
		}
	}
	
	public static DialogScript Load(string path)
	{
		var serializer = new XmlSerializer(typeof(DialogScript));
		using(var stream = new FileStream(path, FileMode.Open))
		{

			return serializer.Deserialize(stream) as DialogScript;
		}
	}
	
	//Loads the xml directly from the given string. Useful in combination with www.text.
	public static DialogScript LoadFromText(string text) 
	{
		var serializer = new XmlSerializer(typeof(DialogScript));
		return serializer.Deserialize(new StringReader(text)) as DialogScript;
	}
}