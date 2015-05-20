﻿using UnityEngine;
using System.Collections;

public class Mode_Select : MonoBehaviour {
	
	public int selectedNum;
	
	public float selectDelay = 0.2f;
	public float enableSelectTime = 0.0f;
	
	public GameObject mode1;
	public GameObject mode2;	
	public GameObject mode3;
	
	public string sceneName;
	public static int modeNum;
	
	// Use this for initialization
	void Start () {
		selectedNum = 1;
		mode1.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Time.time > enableSelectTime) {
			enableSelectTime = Time.time + selectDelay;
			
			// 입력된 방향에 따른 처리
			if ( (Input.GetKey ( KeyCode.LeftArrow )) && (selectedNum >= 1) ) {
				selectedNum -= 1;
			}
			if ( (Input.GetKey ( KeyCode.RightArrow )) && (selectedNum <= 3) ) {
				selectedNum += 1;
			}
			
			// selectedNum에 따른 커서 처리
			if (selectedNum == 1) { // play
				mode1.SetActive ( true );
				mode2.SetActive ( false );
				mode3.SetActive ( false );
				//sceneName = "Game_Scene";
			} else if (selectedNum == 2) { // help
				mode1.SetActive ( false );
				mode2.SetActive ( true );
				mode3.SetActive ( false );
				//sceneName = "SelectMode_Scene";
			} else if (selectedNum == 3) { // help
				mode1.SetActive ( false );
				mode2.SetActive ( false );
				mode3.SetActive ( true );
				//sceneName = "SelectMode_Scene";
			} 

			// 선택 키 처리,
			if ( Input.GetKey ( KeyCode.X ) ) {
				modeNum = selectedNum;
				Application.LoadLevel ( "SelectMap_Scene" );
			}					
			
		}
		
	}
}
