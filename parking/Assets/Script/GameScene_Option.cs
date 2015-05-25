using UnityEngine;
using System.Collections;

public class GameScene_Option : MonoBehaviour {
	
	bool optionFlag;

	public GameObject spot;

	public int spotNum;

	public GUIText _elapsedTime;
	public static float _time;
	public static string timeStr;

	// Use this for initialization
	void Start () {
		optionFlag=false;
		/*
		System.Random r = new System.Random ();

		spotNum = r.Next (1, 5);

		switch (spotNum) {
		case 1:
			parkingSpot1.SetActive(true);
			spot = parkingSpot1;
			break;
		case 2:
			parkingSpot2.SetActive(true);
			spot = parkingSpot2;
			break;
		case 3:
			parkingSpot3.SetActive(true);
			spot = parkingSpot3;
			break;
		case 4:
			parkingSpot4.SetActive(true);
			spot = parkingSpot4;
			break;
		}*/

		_time = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.O) ) {
			optionFlag=true;
		}

		if (Input.GetKey (KeyCode.Z) ) {
			optionFlag=false;
		}

		if(Input.GetButton("GearParking")){
			if( spot.GetComponent<Game_PassFail>().success_flag )
				Application.LoadLevel("Game_Success");
			else
				Application.LoadLevel ("Game_Over");

		}


		// 경과 시간.

		_time += Time.deltaTime;

	}

	void OnGUI(){

		if(optionFlag){	
			if( GUI.Button(new Rect(Screen.width/2-65, Screen.height/2+10, 60, 25), "Restart") == true)
				Application.LoadLevel("Game_Scene");

			if( GUI.Button(new Rect(Screen.width/2, Screen.height/2+10, 80, 25), "Select Map") == true)
				Application.LoadLevel("SelectMap_Scene");
		}

		// 경과시간
		timeStr = "" + _time.ToString ("00.00");
		timeStr = timeStr.Replace (".", ":");
		_elapsedTime.text = "Time " + timeStr;
	}
}
