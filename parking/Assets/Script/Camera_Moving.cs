using UnityEngine;
using System.Collections;

public class Camera_Moving : MonoBehaviour {
	
	public GameObject CAR;
	public bool CAR_bool;

	public Material Normal;
	public Material Transparent;

	public GUIStyle Title;
	public GUIStyle names;
	public GUIStyle buttons;


	void Start () {

		CAR_bool = true;
		CAR.SetActive(true);
	}
	

	void Update () {
	    
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}

		if(CAR_bool)
		{
			if(Input.GetKeyDown(KeyCode.H))
			{
				CAR.transform.FindChild("car_body").GetComponent<Renderer>().material = Normal;
			}
			if(Input.GetKeyDown(KeyCode.J))
			{
				CAR.transform.FindChild("car_body").GetComponent<Renderer>().material = Transparent;
			}
		}

	}

	void OnGUI()

	{
		/*if(GUI.Button(new Rect(Screen.width-550,Screen.height-30,300,50),"MATTS CREATIONS OFFICIAL SITE",buttons))
		{
			Application.OpenURL("http://matts-creations.webnode.sk/");
		}*/
	}
}
