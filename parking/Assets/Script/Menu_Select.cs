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
			if ( (Input.GetKey ( KeyCode.LeftArrow )) && (selectedNum >= 2) ) {
				selectedNum -= 1;
			}
			if ( (Input.GetKey ( KeyCode.RightArrow )) && (selectedNum <= 3) ) {
				selectedNum += 1;
			}

			// selectedNum에 따른 커서 처리
			if (selectedNum == 1) { // play
				menuPlay.SetActive ( true );
				menuHelp.SetActive ( false );
				menuCredits.SetActive ( false );
				menuExit.SetActive ( false );
				sceneName = "SelectMap_Scene";
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

		}

		if ( Input.GetKey ( KeyCode.X ) ) {
			if ( selectedNum == 1 ) {
				Application.LoadLevel ( sceneName );

			}

		}

		if ( Input.GetKey ( KeyCode.Z ) ) {
			selectedNum = 4;
		}


	}
}
