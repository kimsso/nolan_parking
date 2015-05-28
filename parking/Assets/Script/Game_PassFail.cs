using UnityEngine;
using System.Collections;

public class Game_PassFail : MonoBehaviour {
	
	public GameObject spot;
	
	public GameObject front_left;
	public GameObject front_right;
	public GameObject back_left;
	public GameObject back_right;
	
	Vector3 spot_pos;
	Vector3 spot_scale;
	
	Vector3 frontLeft_pos;
	Vector3 frontRight_pos;
	Vector3 backLeft_pos;
	Vector3 backRight_pos;
	
	public bool success_flag;
	
	public bool frontLeft_flag;
	public bool frontRight_flag;
	public bool backLeft_flag;
	public bool backRight_flag;
	
	public bool mode_flag;
	
	public int wheel_cnt;
	
	// Use this for initialization
	void Start () {
		spot_pos=spot.GetComponent<Transform>().position;
		spot_scale=spot.GetComponent<Transform>().localScale;
		
		success_flag=false;
		
		frontLeft_flag=false;
		frontRight_flag=false;
		backLeft_flag=false;
		backRight_flag=false;
		
		mode_flag=false;
	}
	
	// Update is called once per frame
	void Update () {
		
		frontLeft_pos=front_left.GetComponent<Transform>().position;
		frontRight_pos=front_right.GetComponent<Transform>().position;
		backLeft_pos=back_left.GetComponent<Transform>().position;
		backRight_pos=back_right.GetComponent<Transform>().position;
		
	}
	/*
	void OnTriggerEnter(Collider col){
		if(Mode_Select.modeNum == 1){
			if(col.name == "front_collider")
				mode_flag=true;
			else
				mode_flag=false;
			//mode_flag=ParkingPass (frontCol_pos);
		}
		
		if(Mode_Select.modeNum == 2){
			if(col.name == "back_collider")
				mode_flag=true;
			else
				mode_flag=false;
			//mode_flag=ParkingPass (backCol_pos);
		}
		
		if(Mode_Select.modeNum == 3){
			mode_flag=true;
		}
	}*/
	
	void OnTriggerStay(Collider col){
		wheel_cnt=0;
		
		frontLeft_flag=ParkingPass(frontLeft_pos);
		frontRight_flag=ParkingPass(frontRight_pos);
		backLeft_flag=ParkingPass(backLeft_pos);
		backRight_flag=ParkingPass(backRight_pos);
		
		if(frontLeft_flag)
			wheel_cnt++;
		if(frontRight_flag)
			wheel_cnt++;
		if(backLeft_flag)
			wheel_cnt++;
		if(backRight_flag)
			wheel_cnt++;
		
		if(wheel_cnt == 2){
			if(Mode_Select.modeNum == 1){
				if(frontLeft_flag && frontRight_flag)
					mode_flag=true;
				else
					mode_flag=false;
			}
			else if(Mode_Select.modeNum == 2){
				if(backLeft_flag && backRight_flag)
					mode_flag=true;
				else
					mode_flag=false;
			}
		}

		if(Mode_Select.modeNum == 3){
			mode_flag=true;
		}
		
		if(mode_flag &&
		   frontLeft_flag && frontRight_flag && backLeft_flag && backRight_flag)
			success_flag=true;
		else
			success_flag=false;
		
	}
	
	bool ParkingPass(Vector3 pos){
		if( (spot_pos.x - spot_scale.x/2) <= pos.x
		   && pos.x <= (spot_pos.x + spot_scale.x/2) ){
			
			if( (spot_pos.z - spot_scale.z/2) <= pos.z
			   && pos.z <= (spot_pos.z + spot_scale.z/2) ){
				return true;                        
			}
		}
		
		return false;
	}
}