using UnityEngine;
using System.Collections;

public class Game_Restart : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		if( GUI.Button(new Rect(Screen.width/2-35, Screen.height/2+10, 60, 25), "Restart") == true )
		   Application.LoadLevel("Game_Scene");		
	}
}
