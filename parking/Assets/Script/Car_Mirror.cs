using UnityEngine;
using System.Collections;

public class Car_Mirror : MonoBehaviour {

	Camera cam;

	void Start(){
		cam = GetComponent<Camera>();
	}

	void OnPreCull(){
		cam.ResetWorldToCameraMatrix();
		cam.ResetProjectionMatrix();
		cam.projectionMatrix = cam.projectionMatrix * Matrix4x4.Scale(new Vector3(-1, 1, 1));
	}

	void OnPreRender(){
		GL.SetRevertBackfacing(true);
	}

	void OnPostRender(){
		GL.SetRevertBackfacing(false);
	}
}
