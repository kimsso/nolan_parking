using UnityEngine;
using System.Collections;

public class Menu_Select : MonoBehaviour {

	public int selectedNum;

	public float selectDelay = 0.2f;
	public float enableSelectTime = 0.0f;

	public GameObject menuPlay;
	public GameObject menuHelp;
	public GameObject menuCredits;
	public GameObject menuExit;

	public GameObject pageHelp;
	public GameObject pageCredits;
	public bool isPageOpen = false;
	public bool possible = true;


	public string sceneName;

	// Use this for initialization
	void Start () {
		selectedNum = 1;
		menuPlay.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
	

		if (Time.time > enableSelectTime) {
			enableSelectTime = Time.time + selectDelay;

			// 입력된 방향에 따른 처리
			if ( possible && (Input.GetButton ( "GearBack" ) == true) && (selectedNum >= 2)  ) {
				selectedNum -= 1;
				possible=false;
			}

			if ( possible && (Input.GetButton ( "Gear" ) == true) && (selectedNum <= 3) ) {
				selectedNum += 1;
				possible=false;
			}

			if( !possible && (Input.GetButton ( "GearBack" ) == false) && (Input.GetButton ( "Gear" ) == false)){
				possible = true;
			}
			// selectedNum에 따른 커서 처리
			if (selectedNum == 1) { // play
				menuPlay.SetActive ( true );
				menuHelp.SetActive ( false );
				menuCredits.SetActive ( false );
				menuExit.SetActive ( false );
				sceneName = "SelectMode_Scene";
			} else if (selectedNum == 2) { // help
				menuPlay.SetActive ( false );
				menuHelp.SetActive ( true );
				menuCredits.SetActive ( false );
				menuExit.SetActive ( false );
			} else if (selectedNum == 3) { // credits
				menuPlay.SetActive ( false );
				menuHelp.SetActive ( false );
				menuCredits.SetActive ( true );
				menuExit.SetActive ( false );
			} else if (selectedNum == 4) { // exit
				menuPlay.SetActive ( false );
				menuHelp.SetActive ( false );
				menuCredits.SetActive ( false );
				menuExit.SetActive ( true );
			}

			// 선택 키 처리,
			if ( Input.GetAxis ( "Accel" ) > 0 ) {
				
				// 상세 페이지 오픈 시 
				if ( isPageOpen ) {
					pageHelp.SetActive ( false );
					pageCredits.SetActive ( false );
					isPageOpen = false;
				}
				// 기본 UI 조작
				else {
					if ( selectedNum == 1 ) {
						Application.LoadLevel ( sceneName );
					} else if ( selectedNum == 2 ) {
						pageHelp.SetActive ( true );
						isPageOpen = true;
					} else if ( selectedNum == 3 ) {
						pageCredits.SetActive ( true );
						isPageOpen = true;
					} else if ( selectedNum == 4 ) {
						// 종료!
					}
					
				}
			}
			
			// 취소 키 처리,
			if ( Input.GetAxis ( "Stop" ) > 0) {
				// 상세 페이지 오픈 시 
				if ( isPageOpen ) {
					pageHelp.SetActive ( false );
					pageCredits.SetActive ( false );
					isPageOpen = false;
				}
				// 기본 UI 조작
				else {
					selectedNum = 4;	
				}

			}



		}




	}
}
