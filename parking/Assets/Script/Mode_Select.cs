using UnityEngine;
using System.Collections;

public class Mode_Select : MonoBehaviour {

	public int mode;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		if( GUI.Button(new Rect(Screen.width/2-65, Screen.height/2+10, 60, 25), "전진주차") == true ){
		    Application.LoadLevel("SelectMap_Scene");		
			mode = 1;
		}

		if( GUI.Button(new Rect(Screen.width/2, Screen.height/2+10, 60, 25), "후진주차") == true ){
			Application.LoadLevel("SelectMap_Scene");
			mode = 2;
		}

		if( GUI.Button(new Rect(Screen.width/2+65, Screen.height/2+10, 60, 25), "평행주차") == true ){
			Application.LoadLevel("SelectMap_Scene");
			mode = 3;
		}
	}
}