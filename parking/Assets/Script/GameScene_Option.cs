﻿using UnityEngine;
using System.Collections;

public class GameScene_Option : MonoBehaviour {
	
	bool optionFlag;

	public GameObject parkingSpot1;
	public GameObject parkingSpot2;
	public GameObject parkingSpot3;
	public GameObject parkingSpot4;

	public int spotNum;

	// Use this for initialization
	void Start () {
		optionFlag=false;

		System.Random r = new System.Random ();

		spotNum = r.Next (1, 5);

		switch (spotNum) {
		case 1:
			parkingSpot1.SetActive(true);
			break;
		case 2:
			parkingSpot2.SetActive(true);
			break;
		case 3:
			parkingSpot3.SetActive(true);
			break;
		case 4:
			parkingSpot4.SetActive(true);
			break;
		}

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
