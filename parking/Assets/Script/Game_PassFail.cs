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

	public bool frontLeft_flag;
	public bool frontRight_flag;
	public bool backLeft_flag;
	public bool backRight_flag;

	// Use this for initialization
	void Start () {
		spot_pos=spot.GetComponent<Transform>().position;
		spot_scale=spot.GetComponent<Transform>().localScale;

		frontLeft_flag=false;
		frontRight_flag=false;
		backLeft_flag=false;
		backRight_flag=false;
	}

	// Update is called once per frame
	void Update () {
		frontLeft_pos=front_left.GetComponent<Transform>().position;
		frontRight_pos=front_right.GetComponent<Transform>().position;
		backLeft_pos=back_left.GetComponent<Transform>().position;
		backRight_pos=back_right.GetComponent<Transform>().position;
	}

	void OnTriggerStay(Collider col){
		frontLeft_flag=ParkingPass(frontLeft_pos);
		frontRight_flag=ParkingPass(frontRight_pos);
		backLeft_flag=ParkingPass(backLeft_pos);
		backRight_flag=ParkingPass(backRight_pos);

		if(Input.GetKey(KeyCode.P)){
			if(frontLeft_flag && frontRight_flag && backLeft_flag && backRight_flag)
				Application.LoadLevel("Game_Success");
			else
				Application.LoadLevel ("Game_Over");
		}
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
