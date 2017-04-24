using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollScript : MonoBehaviour {
    Bounds bounds;
    Mesh mesh;
   // Renderer rend;
    //public float speed = 0;
	// Use this for initialization
	void Start () {
        // rend = GetComponent<Renderer>();
        mesh = GetComponent<MeshFilter>().mesh;
       bounds = mesh.bounds;
	}
	
	// Update is called once per frame
	void Update ()
    {
        
       
	}
    public void onCall()
    {
      //  Debug.Log("Double Crap: " + bounds.size.x);
        transform.position = new Vector3(transform.position.x + (bounds.size.x * transform.localScale.x), transform.position.y, transform.position.z) ;
    }
}
