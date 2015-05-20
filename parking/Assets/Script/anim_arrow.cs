using UnityEngine;
using System.Collections;

public class anim_arrow : MonoBehaviour {

	private float speed;
	private bool isForward;
	private int cnt;

	// Use this for initialization
	void Start () {
		speed = 0.5f;
		isForward = true;
		cnt = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if (isForward) {
			cnt++;
			transform.position += transform.forward * speed;

			if ( cnt == 20 )
			{
				cnt = 0;
				isForward = false;
			}
		} else {
			cnt++;
			transform.position -= transform.forward * speed ;
			if ( cnt == 20 )
			{
				cnt = 0;
				isForward = true;
			}
		}

	}
}
