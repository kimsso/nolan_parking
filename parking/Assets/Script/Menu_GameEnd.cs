using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class Menu_GameEnd : MonoBehaviour {

	public int selectedNum;
	
	public float selectDelay = 0.2f;
	public float enableSelectTime = 0.0f;

	private bool isNewRecord = false;

	// restarts
	public GameObject menuRestart;
	public GameObject menuSelectMap;	
	public GameObject menuSelectMode;
	public GameObject menus;
	public GameObject names;

	public GameObject txtSuccess;
	public GameObject txtNewScore;

	public GUIText laptime;

	// new records
	public GUIText char1;
	public GUIText char2;
	public GUIText char3;
	private int charnum = 1;

	private char strChar1 = 'A';
	private char strChar2 = 'A';
	private char strChar3 = 'A';

	private string strFileName;
	private FileInfo srcFile = null;
	private StreamReader reader = null;
	private StreamWriter writer = null;

	private float lap;
	private float myLap;

    public string sceneName;
    public bool possible = true;
	
	// Use this for initialization
	void Start () {


			selectedNum = 1;
			
			// 이전 laptime 받아와서 비교.
			if (Mode_Select.modeNum == 1) {
				strFileName = "./laptime/t1_1.txt";
			} else if (Mode_Select.modeNum == 2) {
				strFileName = "./laptime/t2_1.txt";
			} else if (Mode_Select.modeNum == 3) {
				strFileName = "./laptime/t3_1.txt";
			}

			srcFile = new FileInfo (strFileName);
			reader = srcFile.OpenText ();
			reader.ReadLine ();
			lap = float.Parse(reader.ReadLine ());
			myLap = GameScene_Option._time;
			
			if (myLap < lap) { // 신기록 갱신일 시,
				menus.SetActive(false);
				names.SetActive(true);
				txtNewScore.SetActive(true);
				txtSuccess.SetActive(false);
				
				isNewRecord = true;
			} else {
				menus.SetActive(true);
				names.SetActive(false);
				txtNewScore.SetActive(false);
				txtSuccess.SetActive(true);
			}
			
			menuRestart.SetActive (true);
			//menus.SetActive (false);
			
			reader.Close ();



	}
	
	// Update is called once per frame
	void Update () {

		if (isNewRecord) {

			laptime.text = "Lap " + GameScene_Option.timeStr;

			names.SetActive (true);
			menus.SetActive(false);

			if (Time.time > enableSelectTime) {
				enableSelectTime = Time.time + selectDelay;
				
				//// 입력된 방향에 따른 처리
                if ((Input.GetKey(KeyCode.LeftArrow)) || ( possible && (Input.GetButton("Gear") == true) ) )
                {
                    possible = false;
					if ( charnum == 1 ) {
						if ( strChar1 > 'A') strChar1--;
						else if ( strChar1 == 'A' ) strChar1 = 'Z';
					}
					else if ( charnum == 2 ) {
						if ( strChar2 > 'A') strChar2--;
						else if ( strChar2 == 'A' )	strChar2 = 'Z';
					}
					else if ( charnum == 3 ) {
						if ( strChar3 > 'A') strChar3--;
						else if ( strChar3 == 'A' )	strChar3 = 'Z';
					}
				}
                if ((Input.GetKey(KeyCode.RightArrow)) || ( possible && (Input.GetButton("GearBack") == true) ) )
                {
					if ( charnum == 1 ) {
						if ( strChar1 < 'Z') strChar1++;
						else if ( strChar1 == 'Z' ) strChar1 = 'A';
					}
					else if ( charnum == 2 ) {
						if ( strChar2 < 'Z') strChar2++;
						else if ( strChar2 == 'Z' ) strChar2 = 'A';
					}
					else if ( charnum == 3 ) {
						if ( strChar3 < 'Z') strChar3++;
						else if ( strChar3 == 'Z' ) strChar3 = 'A';
					}

				}
                if (!possible && (Input.GetButton("GearBack") == false) && (Input.GetButton("Gear") == false))
                {
                    possible = true;
                }

				// 각 char 색 변경 및 문자 변경 
				if ( charnum == 1 ){
					char1.material.color = Color.yellow;
					char2.material.color = Color.white;
					char3.material.color = Color.white;
					char1.text = strChar1.ToString();
				}
				else if ( charnum == 2 ){
					char2.material.color = Color.yellow;
					char3.material.color = Color.white;
					char1.material.color = Color.white;
					char2.text = strChar2.ToString();
				}
				else if ( charnum == 3 ){
					char3.material.color = Color.yellow;
					char1.material.color = Color.white;
					char2.material.color = Color.white;
					char3.text = strChar3.ToString();
				}

				
				// 선택 키 처리,
                if (Input.GetKey(KeyCode.X) || (Input.GetAxis("Accel") > 0))
                {
					if ( charnum < 3 ) {
						charnum++;
					}
					else{
						isNewRecord = false;
						// 여기서 local DB에 저장.

						writer = new StreamWriter(strFileName);

						writer.WriteLine ( ""+strChar1+strChar2+strChar3 );
						writer.WriteLine ( myLap );

						writer.Close ();

						menus.SetActive (true);

					}
				}
				// 취소 키 처리,
                if (Input.GetKey(KeyCode.Z) || (Input.GetAxis("Stop") > 0))
                {
					if ( charnum > 1 ) {
						charnum--;
					}

				}

			}

		} else {

			laptime.text = "Lap " + GameScene_Option.timeStr;

			menus.SetActive (true);
			if (Time.time > enableSelectTime) {
				enableSelectTime = Time.time + selectDelay;
				
				// 입력된 방향에 따른 처리
				if ( (Input.GetKey ( KeyCode.LeftArrow )) && (selectedNum >= 1)) {
					selectedNum--;
				}
				if ( (Input.GetKey ( KeyCode.RightArrow )) && (selectedNum <= 2)) {
					selectedNum++;
				}

				// 입력된 방향에 따른 처리
				if ( possible && (Input.GetButton ( "Gear" ) == true) && (selectedNum >= 2)  ) {
					selectedNum -= 1;
					possible=false;
				}
				
				if ( possible && (Input.GetButton ( "GearBack" ) == true) && (selectedNum <= 1	) ) {
					selectedNum += 1;
					possible=false;
				}
				
				if( !possible && (Input.GetButton ( "GearBack" ) == false) && (Input.GetButton ( "Gear" ) == false)){
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
}