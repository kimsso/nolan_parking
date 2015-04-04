using UnityEngine;
using System.Collections;

public class Map_Select : MonoBehaviour {
	
	public string titleSceneName;
	public string gameSceneName;
	
	// Use this for initialization
	void Start () {
		titleSceneName = "Title_Scene";
		gameSceneName = "Game_Scene";
	}
	
	// Update is called once per frame
	void Update () {

		if ( Input.GetKey ( KeyCode.X ) ) {
			Application.LoadLevel ( gameSceneName );
		}
		
		if ( Input.GetKey ( KeyCode.Z ) ) {
			Application.LoadLevel ( titleSceneName );
		}
		
		
	}
}
