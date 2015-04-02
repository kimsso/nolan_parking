using UnityEngine;
using System.Collections;

public class Map_Rotate : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.RotateAround ( new Vector3( 0, 0, 0 ) , new Vector3( 0, 1, 0 ), 1 ); 
	}
}
