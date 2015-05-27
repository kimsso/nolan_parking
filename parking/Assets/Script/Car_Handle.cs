using UnityEngine;
using System.Collections;

public class Car_Handle : MonoBehaviour {

	public GameObject car;
	
	public float turn;
	public float preturn;
	public bool isFirst = true;
	float pi;

	// Use this for initialization
	void Start () {
		car = GameObject.Find("Car");
		//pi=3.141592;
	}
	
	// Update is called once per frame
	void Update () {

		if (isFirst) {
			turn = car.GetComponent<Car_Moving> ().turning;
			preturn = turn;
			isFirst = false;

			if (Input.GetAxis ("Handle") == 0) {
				this.transform.Rotate (0, 0, 0);
			} else {
				this.transform.Rotate (0, 0, -turn);
			} 
		} else {
			turn = car.GetComponent<Car_Moving> ().turning;

			if (Input.GetAxis ("Handle") == 0) {
				this.transform.Rotate (0, 0, 0);
			} else {
				this.transform.Rotate (0, 0, -(turn - preturn));
				preturn = turn;
			}
		}
		//this.transform.RotateAround(center.transform.position,
		  //                          new Vector3(-1.0f, 0.0f, 0.0f), turn*10);
	}
}
