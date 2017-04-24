using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour {

    public float speed = 0;

    private Rigidbody2D body2D;
	// Use this for initialization
	void Start ()
    {
        body2D = this.GetComponent<Rigidbody2D>();
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        body2D.velocity = new Vector2(-speed, 0);
	}
}
