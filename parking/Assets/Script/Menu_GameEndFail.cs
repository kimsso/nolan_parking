using UnityEngine;
using System.Collections;

public class Menu_GameEndFail : MonoBehaviour {
	
	public int selectedNum;
	
	public float selectDelay = 0.2f;
	public float enableSelectTime = 0.0f;
	
	public GameObject menuRestart;
	public GameObject menuSelectMap;	
	public GameObject menuSelectMode;

    public string sceneName;
    public bool possible = true;
	
	// Use this for initialization
	void Start () {
		selectedNum = 1;
		menuRestart.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Time.time > enableSelectTime) {
			enableSelectTime = Time.time + selectDelay;
			
			// Keyboard 이용시 입력된 방향에 따른 처리
			if ( (Input.GetKey ( KeyCode.LeftArrow )) && (selectedNum >= 1) ) {
				selectedNum -= 1;
			}
			if ( (Input.GetKey ( KeyCode.RightArrow )) && (selectedNum <= 2) ) {
				selectedNum += 1;
            }
            // Logitech gear 이용시 입력된 방향에 따른 처리
            if (possible && (Input.GetButton("Gear") == true) && (selectedNum >= 1))
            {
                selectedNum -= 1;
                possible = false;
            }

            if (possible && (Input.GetButton("GearBack") == true) && (selectedNum <= 2))
            {
                selectedNum += 1;
                possible = false;
            }

            if (!possible && (Input.GetButton("GearBack") == false) && (Input.GetButton("Gear") == false))
            {
                possible = true;
            }
			
			// selectedNum에 따른 커서 처리
			if (selectedNum == 1) { // play
				menuRestart.SetActive ( true );
				menuSelectMode.SetActive ( false );
				if(Mode_Select.modeNum == 1){
					sceneName = "Game_Scene2";
				}
				else if(Mode_Select.modeNum == 2){
					sceneName = "Game_Scene";
				}
				else if(Mode_Select.modeNum == 3){
					sceneName = "Game_Scene3";
				}
			} else if (selectedNum == 2) { // help
				menuRestart.SetActive ( false );
				menuSelectMode.SetActive ( true );
				sceneName = "SelectMode_Scene";
			} 
			
			
			// 선택 키 처리,
            if (Input.GetKey(KeyCode.X) || (Input.GetAxis("Accel") > 0))
            {
				Application.LoadLevel ( sceneName );
			}

            
			
			
		}
		
		
		
		
	}
}