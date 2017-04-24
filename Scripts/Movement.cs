using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    public Rigidbody2D body2D;
    public int speed;
	// Use this for initialization
	void Start () {
        body2D = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        body2D.velocity = new Vector2(speed * Input.GetAxisRaw("Horizontal"),0 );
	}
}
