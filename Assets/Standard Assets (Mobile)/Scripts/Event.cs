using UnityEngine;
using System.Collections;
using define;

public class Event{

	float duration;
	public enum eventType {ravager,dragon};
	bool hasEnded = false;
	string introEvent = "";
	float efficiency;

	public Event(Disaster  type)
	{
		Disaster eventT;
		eventT = type;
		hasEnded = false;
		efficiency = 1.0f;
		switch (eventT) {
		case Disaster.Dragon:
			duration = 600.0f;
			introEvent = "A dragon is fast approaching!";
			break;
		case Disaster.Ravages:
			duration = 3000.0f;
			introEvent = "A band of ravagers are fast approaching!";
			break;
		case Disaster.Fog:
			duration = 3000.0f;
			introEvent = "A thick mist of fog approaches!";
			break;
		case Disaster.ThunderStorm:
			duration = 3000.0f;
			introEvent = "Dark clouds are looming. A thunderstorm is arriving!";
			break;
		case Disaster.Normal:
			duration = 2000.0f;
			introEvent = "The skies are calm, the journey is proceeding smoothly";
			break;
		}

	}

	public void update()
	{
		duration -= 1.0f * efficiency;
		if (duration <= 0.0f) {
			hasEnded = true;
		}

	}

	public void setEfficiency(float e)
	{
		efficiency = e;
	}

	
	public float getEventDuration()
	{
		return duration;
		}

	public bool checkEventEnd()
	{
		return hasEnded;
		}

	public string getEventString(int state)
	{
		if (state == 0) {
			return introEvent;
		} else {
			return "Event has ended";
		}
	}




}
