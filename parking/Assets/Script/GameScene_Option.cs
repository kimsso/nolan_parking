using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class GameScene_Option : MonoBehaviour {
	
	bool optionFlag;

	public GameObject spot;

	public int spotNum;

	public GUIText _elapsedTime;
	public GUIText _bestTime;
	public string bTime;
	public static float _time;
	public static string timeStr;


	private FileInfo srcFile = null;
	private StreamReader reader = null;
	private String strFileName = null;

	// Use this for initialization
	void Start () {
		optionFlag=false;

		if (Mode_Select.modeNum == 1) {
			strFileName = "./laptime/t1_1.txt";
		} else if (Mode_Select.modeNum == 2) {
			strFileName = "./laptime/t2_1.txt";
		} else if (Mode_Select.modeNum == 3) {
			strFileName = "./laptime/t3_1.txt";
		}
		
		srcFile = new FileInfo (strFileName);
		reader = srcFile.OpenText ();
		reader.ReadLine ();// 이름 버리고,
		bTime = (reader.ReadLine ()).Replace (".", ":");

		reader.Close ();
		//strRank1 = strRank1 + " - " + (reader.ReadLine()).Replace (".", ":");
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

		if (Input.GetKey (KeyCode.Z) || Input.GetAxis ("Stop")>0 ) {
			optionFlag=false;
		}

		if(Input.GetKey (KeyCode.P) || Input.GetButton("GearParking") ){
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
		timeStr = _time.ToString ("00.00");
		timeStr = timeStr.Replace (".", ":");
		_elapsedTime.text = "Time " + timeStr;
		_bestTime.text = "Best " + bTime;


	}
}
