using UnityEngine;
using System.Collections;

public class Car_Collider : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	
	
	}

	void OnCollisionEnter(Collision col){

		Application.LoadLevel ("Game_Scene");
		
	}

}
