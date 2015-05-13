using UnityEngine;
using System.Collections;

public class Car_Moving : MonoBehaviour {
	
	public GameObject main_cam;
	public GameObject car_cam;

	public float speed;
	public float acceleration;
	
	public float MAXspeed;
	public float MINspeed;

	public float turning;
	public float brake;
	
	public float Engine_meter;

	public GUIStyle test;

	public bool optionFlag;

	// Use this for initialization
	void Start () {
		test.normal.textColor = Color.white;
		test.fontSize = 30;

		optionFlag=false;
	}
	
	// Update is called once per frame
	void Update () {

		// press option key
		if(Input.GetKey (KeyCode.O)) 
			optionFlag=true;

		if(Input.GetKey (KeyCode.Z))
			optionFlag=false;



		if(!optionFlag){
			/*
			// scene move test
			if(Input.GetKey (KeyCode.X )) {
				Application.LoadLevel ( "Game_Scene" );
			}
			
			if(Input.GetKey (KeyCode.Z)) {
				Application.LoadLevel ( "SelectMap_Scene" );
			}
			*/

			if(Input.GetKey (KeyCode.Space))
				speed = Mathf.Lerp(speed,0,brake);

			/** Sound 
			body.transform.GetComponent<AudioSource>().pitch = Engine_meter;	

			if(speed<=1)
			{
				Engine_meter = 1;
			}
			if(speed<=7 && speed>=1)
			{
				Engine_meter = speed;
			}		
			if(speed>=7)
			{
				Engine_meter = 7;
			}**/
			
			this.transform.position += this.transform.forward * speed * Time.deltaTime;

			main_cam.transform.position = Vector3.Lerp(main_cam.transform.position,car_cam.transform.position,0.05f);

			main_cam.transform.rotation = Quaternion.Lerp(main_cam.transform.rotation,car_cam.transform.rotation,0.05f);

			/** speed up/down **/
			if(Input.GetAxis("Vertical")>0)
			{
				speed = Mathf.Lerp(speed,MAXspeed,acceleration);
				this.transform.Rotate(Vector3.up	 * turning);
			}		
			else if(Input.GetAxis("Vertical")<0)
			{
				speed = Mathf.Lerp(speed,MINspeed,acceleration);
				this.transform.Rotate(-Vector3.up	 * turning);
			}
			else
			{
				speed = Mathf.Lerp(speed,0,acceleration);

				if (speed > 0.5 )
					this.transform.Rotate(Vector3.up	 * turning);
				else if (speed < -0.5 )
					this.transform.Rotate(-Vector3.up	 * turning);
				else
					speed = 0;
			}



			
			/** direction, left/right **/
			if(Input.GetAxis("Horizontal")>0) //right key down
			{
				if(turning < 0.8f){
					turning += 0.03f;
				}								
			}
			else if(Input.GetAxis("Horizontal")<0) //left key down
			{
				if(turning > -0.8f){
					turning -= 0.03f;
				}
				//this.transform.Rotate (Vector3.up * turning * Input.GetAxis("Vertical"));
			}
		}
	}

	void OnGUI(){
		GUI.Label(new Rect(0,0,1,1),"Turning: " + turning, test);
	}

}
