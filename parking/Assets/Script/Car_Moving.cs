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


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		// scene move test
		if(Input.GetKey (KeyCode.X )) {
			Application.LoadLevel ( "Game_Scene" );
		}
		
		if(Input.GetKey (KeyCode.Z)) {
			Application.LoadLevel ( "SelectMap_Scene" );
		}

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
		else
		{
			speed = Mathf.Lerp(speed,0,acceleration);
		}
		
		if(Input.GetAxis("Vertical")<0)
		{
			speed = Mathf.Lerp(speed,MINspeed,acceleration);
			this.transform.Rotate(-Vector3.up	 * turning);
		}
		
		/** direction, left/right **/
		if(Input.GetAxis("Horizontal")>0) //right key down
		{
			if(turning < 0.5f){
				turning += 0.05f;
			}								
		}
		
		if(Input.GetAxis("Horizontal")<0) //left key down
		{
			if(turning > -0.5f){
				turning -= 0.05f;
			}
			//this.transform.Rotate (Vector3.up * turning * Input.GetAxis("Vertical"));
		}
	}

}
