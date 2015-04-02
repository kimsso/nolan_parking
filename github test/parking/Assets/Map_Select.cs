using UnityEngine;
using System.Collections;

public class Map_Select : MonoBehaviour {
	
	public string titleSceneName;
	
	// Use this for initialization
	void Start () {
		titleSceneName = "Title_Scene";
	}
	
	// Update is called once per frame
	void Update () {

		if ( Input.GetKey ( KeyCode.X ) ) {
			// 선택된 맵으로 게임 시작!
		}
		
		if ( Input.GetKey ( KeyCode.Z ) ) {
			Application.LoadLevel ( titleSceneName );
		}
		
		
	}
}
