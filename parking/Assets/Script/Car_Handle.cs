using UnityEngine;
using System.Collections;

public class Car_Handle : MonoBehaviour {

	public GameObject car;
	
	public float turn;
	float pi;

	// Use this for initialization
	void Start () {
		car = GameObject.Find("Car");
		//pi=3.141592;
	}
	
	// Update is called once per frame
	void Update () {
		turn = car.GetComponent<Car_Moving>().turning;

		this.transform.Rotate (0, 0, -turn*10);
		//this.transform.RotateAround(center.transform.position,
		  //                          new Vector3(-1.0f, 0.0f, 0.0f), turn*10);
	}
}
