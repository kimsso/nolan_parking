﻿using UnityEngine;
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
	
	public GUIText _guiRank1;

	
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
			
			_guiRank1.text = strRank1;

			reader.Close ();
			fopenFlag = false;
		}

		if ( Input.GetKey ( KeyCode.X ) ) {
			Application.LoadLevel ( gameSceneName );
		}
		
		if ( Input.GetKey ( KeyCode.Z ) ) {
			Application.LoadLevel ( preSceneName );
		}
		
	}

}
