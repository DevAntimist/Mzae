using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public GameObject cameraObject;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update ()
    {
		if(transform.position.y > 0)
        {
            cameraObject.transform.position = new Vector3(cameraObject.transform.position.x, transform.position.y, cameraObject.transform.position.z);
        }
        else
        {
            if (transform.position.y < 0)
                cameraObject.transform.position = new Vector3(cameraObject.transform.position.x, 0, cameraObject.transform.position.z);
        }
	}
}
