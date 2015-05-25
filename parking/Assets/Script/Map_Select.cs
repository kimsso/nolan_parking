using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class Map_Select : MonoBehaviour {
	
	public string preSceneName;
	public string gameSceneName;

	public GameObject map1;
	public GameObject map2;
	public GameObject map3;

	private FileInfo srcFile = null;
	private StreamReader reader = null;
	private String strFileName = null;
	private bool fopenFlag = true;

	private String strRank1;
	private String strRank2;
	private String strRank3;

	public GUIText _guiRank1;
	public GUIText _guiRank2;
	public GUIText _guiRank3;


	
	// Use this for initialization
	void Start () {
		preSceneName = "SelectMode_Scene";
		gameSceneName = "Game_Scene2";

		strFileName = "./laptime/t1_1.txt";
		srcFile = new FileInfo (strFileName);
		reader = srcFile.OpenText ();
	}
	
	// Update is called once per frame
	void Update () {



		if(Mode_Select.modeNum == 1){
			map1.SetActive(true);
			map2.SetActive(false);
			map3.SetActive(false);
		
			gameSceneName = "Game_Scene2";
		}
		else if(Mode_Select.modeNum == 2){
			map1.SetActive(false);
			map2.SetActive(true);
			map3.SetActive(false);
			
			gameSceneName = "Game_Scene";
		}
		else if(Mode_Select.modeNum == 3){
			map1.SetActive(false);
			map2.SetActive(false);
			map3.SetActive(true);
			
			gameSceneName = "Game_Scene3";
		}


		// ranking GUItext update
		if (fopenFlag) {
			strRank1 = "1. " + reader.ReadLine ();
			strRank1 = strRank1 + " " + reader.ReadLine ();
			strRank2 = "2. " + reader.ReadLine ();
			strRank2 = strRank2 + " " + reader.ReadLine ();
			strRank3 = "3. " + reader.ReadLine ();
			strRank3 = strRank3 + " " + reader.ReadLine ();
			
			_guiRank1.text = strRank1;
			_guiRank2.text = strRank2;
			_guiRank3.text = strRank3;

			reader.Close ();
			fopenFlag = false;
		}

		if ( Input.GetAxis ( "Accel" ) > 0 ) {
			Application.LoadLevel ( gameSceneName );
		}
		
		if ( Input.GetAxis ( "Stop" ) > 0 ) {
			Application.LoadLevel ( preSceneName );
		}
		
	}

}
