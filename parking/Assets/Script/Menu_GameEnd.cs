using UnityEngine;
using System.Collections;

public class Menu_GameEnd : MonoBehaviour {

	public int selectedNum;
	
	public float selectDelay = 0.2f;
	public float enableSelectTime = 0.0f;
	
	public GameObject menuRestart;
	public GameObject menuSelectMap;	
	
	public string sceneName;
	
	// Use this for initialization
	void Start () {
		selectedNum = 1;
		menuRestart.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Time.time > enableSelectTime) {
			enableSelectTime = Time.time + selectDelay;
			
			// 입력된 방향에 따른 처리
			if ( (Input.GetKey ( KeyCode.LeftArrow )) && (selectedNum >= 1) ) {
				selectedNum -= 1;
			}
			if ( (Input.GetKey ( KeyCode.RightArrow )) && (selectedNum <= 2) ) {
				selectedNum += 1;
			}
			
			// selectedNum에 따른 커서 처리
			if (selectedNum == 1) { // play
				menuRestart.SetActive ( true );
				menuSelectMap.SetActive ( false );
				sceneName = "Game_Scene";
			} else if (selectedNum == 2) { // help
				menuRestart.SetActive ( false );
				menuSelectMap.SetActive ( true );
				sceneName = "SelectMap_Scene";
			}
			
			
			
			// 선택 키 처리,
			if ( Input.GetKey ( KeyCode.X ) ) {

				Application.LoadLevel ( sceneName );
			}
			
			
			
		}
		
		
		
		
	}
}
