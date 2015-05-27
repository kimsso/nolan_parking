using UnityEngine;
using System.Collections;

public class Save_NewRecord : MonoBehaviour {

	public GameObject userInput;

	private string txtField = "text field";

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnGUI()
	{

		GUI.SetNextControlName ("UserName");
		txtField = GUI.TextField (new Rect (25, 180, 100, 40), txtField); 
		GUI.FocusControl ("UserName");

		Event e = Event.current;

		if (e.type == EventType.KeyDown && e.keyCode == KeyCode.Return) {
			userInput.SetActive (false);
		}
		//GUI.Label (new Rect (25, 220, 100, 40), txtField);
	}
}
