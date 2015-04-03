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


	//---------------------------MANAGER OF THE SCENE...------------------------------

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
		//GUI.Label(new Rect(10,10,1,1),"CAR TUTORIAL by matt",Title);

		//GUI.Label(new Rect(10,60,1,1),"Press number 1 to change CAR_V1",buttons);
		//GUI.Label(new Rect(10,90,1,1),"Press number 2 to change CAR_V2",buttons);
		//GUI.Label(new Rect(10,120,1,1),"Press number 3 to change CAR_V3",buttons);
		//GUI.Label(new Rect(10,150,1,1),"Press number 4 to change TRUCK",buttons);

		//GUI.Label(new Rect(10,200,1,1),"Press H to change Normal Material",buttons);
		//GUI.Label(new Rect(10,230,1,1),"Press J to change Transparent Material",buttons);
		//GUI.Label(new Rect(10,290,1,1),"Press ESC to QUIT",buttons);

		/*if(GUI.Button(new Rect(Screen.width-550,Screen.height-30,300,50),"MATTS CREATIONS OFFICIAL SITE",buttons))
		{
			Application.OpenURL("http://matts-creations.webnode.sk/");
		}*/
	}
}
