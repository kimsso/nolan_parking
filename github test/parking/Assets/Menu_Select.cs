using UnityEngine;
using System.Collections;

public class Menu_Select : MonoBehaviour {

	public int selectedNum;

	public float selectDelay = 0.2f;
	public float enableSelectTime = 0.0f;

	public GameObject menuStart;
	public GameObject menuInfo;
	public GameObject menuExit;

	public string sceneName;

	// Use this for initialization
	void Start () {
		selectedNum = 1;
		menuStart.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > enableSelectTime) {
			enableSelectTime = Time.time + selectDelay;

			// 입력된 방향에 따른 처리
			if ( (Input.GetKey ( KeyCode.LeftArrow )) && (selectedNum >= 2) ) {
				selectedNum -= 1;
			}
			if ( (Input.GetKey ( KeyCode.RightArrow )) && (selectedNum <= 2) ) {
				selectedNum += 1;
			}

			// selectedNum에 따른 커서 처리
			if (selectedNum == 1) { // start
				menuStart.SetActive ( true );
				menuInfo.SetActive ( false );
				menuExit.SetActive ( false );
				sceneName = "SelectMap_Scene";
			} else if (selectedNum == 2) { // info
				menuStart.SetActive ( false );
				menuInfo.SetActive ( true );
				menuExit.SetActive ( false );
			} else if (selectedNum == 3) { // exit
				menuStart.SetActive ( false );
				menuInfo.SetActive ( false );
				menuExit.SetActive ( true );
			}

		}

		if ( Input.GetKey ( KeyCode.X ) ) {
			if ( selectedNum == 1 ) {
				Application.LoadLevel ( sceneName );

			}

		}

		if ( Input.GetKey ( KeyCode.Z ) ) {
			selectedNum = 3;
		}


	}
}
