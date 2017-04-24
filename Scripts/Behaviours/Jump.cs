﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : AbstractBehaviour {

    public float jumpSpeed = 200f;
    public float jumpDelay = 1f;
    public int jumpCount = 2;

    protected float lastJumpTime = 0;
    protected int jumpsRemaining = 0;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var canJump = inputState.GetButtonValue(inputButtons[0]);
        var holdTime = inputState.GetButtonHoldTime(inputButtons[0]);
        if(collisionState.standing)
        {
            if(canJump && holdTime < .1f)
            {
                jumpsRemaining = jumpCount - 1;
                OnJump(); //On subject to Change....Can stop the jump from jumping constantly...episode after jump
            }
        }
        else
        {
            if (canJump && holdTime <.1f && Time.time - lastJumpTime > jumpDelay)
            {
                if (jumpsRemaining > 0)
                {
                    
                    OnJump(); //On subject to Change....Can stop the jump from jumping constantly...episode after jump
                    jumpsRemaining--;
                }
            }
        }
	}

    protected virtual void OnJump()
    {
        var vel = body2d.velocity;
        lastJumpTime = Time.time;
        body2d.velocity = new Vector2(vel.x, jumpSpeed);
    }
}
