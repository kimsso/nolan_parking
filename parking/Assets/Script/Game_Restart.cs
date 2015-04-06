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
		if( GUI.Button(new Rect(200, 150, 60, 25), "Restart") == true )
		   Application.LoadLevel("Game_Scene");		
	}
}
