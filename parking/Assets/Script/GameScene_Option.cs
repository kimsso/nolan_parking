using UnityEngine;
using System.Collections;

public class GameScene_Option : MonoBehaviour {
	
	bool optionFlag;

	// Use this for initialization
	void Start () {
		optionFlag=false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.O) ) {
			optionFlag=true;
		}

		if (Input.GetKey (KeyCode.Z) ) {
			optionFlag=false;
		}
	}

	void OnGUI(){

		if(optionFlag){	
			if( GUI.Button(new Rect(Screen.width/2-65, Screen.height/2+10, 60, 25), "Restart") == true)
				Application.LoadLevel("Game_Scene");

			if( GUI.Button(new Rect(Screen.width/2, Screen.height/2+10, 80, 25), "Select Map") == true)
				Application.LoadLevel("SelectMap_Scene");
		}
	}
}
