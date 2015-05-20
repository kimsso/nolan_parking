using UnityEngine;
using System.Collections;

public class Map_Select : MonoBehaviour {
	
	public string preSceneName;
	public string gameSceneName;

	public GameObject map1;
	public GameObject map2;
	public GameObject map3;
	
	// Use this for initialization
	void Start () {
		preSceneName = "SelectMode_Scene";
		gameSceneName = "Game_Scene";

	}
	
	// Update is called once per frame
	void Update () {

		if(Mode_Select.modeNum == 1){
			map1.SetActive(true);
			map2.SetActive(false);
			map3.SetActive(false);
		
			gameSceneName = "Game_Scene";
		}
		else if(Mode_Select.modeNum == 2){
			map1.SetActive(false);
			map2.SetActive(true);
			map3.SetActive(false);
			
			gameSceneName = "Game_Scene2";
		}
		else if(Mode_Select.modeNum == 3){
			map1.SetActive(false);
			map2.SetActive(false);
			map3.SetActive(true);
			
			gameSceneName = "Game_Scene3";
		}


		if ( Input.GetKey ( KeyCode.X ) ) {
			Application.LoadLevel ( gameSceneName );
		}
		
		if ( Input.GetKey ( KeyCode.Z ) ) {
			Application.LoadLevel ( preSceneName );
		}
		
	}
}
