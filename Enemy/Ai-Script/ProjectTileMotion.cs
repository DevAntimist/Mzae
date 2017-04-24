﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectTileMotion : MonoBehaviour {

   private Rigidbody2D body2D;
    public int speed = 100;
    private Animator anim;
    private int Direction ;

    private float scale;
    public bool left = false; 
    
	// Use this for initialization
	void Start () {
        anim = this.GetComponent<Animator>();
        body2D = GetComponent<Rigidbody2D>();
        scale = transform.localScale.x;
    }
	
	// Update is called once per frame
	void Update () {
        
        if (left)
        {

            body2D.velocity = new Vector2(-speed, 0);
            transform.localScale = new Vector3(-scale, transform.localScale.y , transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(scale, transform.localScale.y , transform.localScale.z);
            body2D.velocity = new Vector2(speed, 0);
        }
    }
}