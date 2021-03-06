﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmScript : MonoBehaviour {
    private Animator anim;
    
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ChangeState(int state)
    {
        anim.SetInteger("Fire", state);
    }
    public void Fire()
    {
        if(GetComponentInParent<InputState>().direction == Directions.Right)
            GetComponentInParent<FireProjectile>().CreateProjectile(new Vector2(transform.position.x + 0.5f, transform.position.y ));
        else
            GetComponentInParent<FireProjectile>().CreateProjectile(new Vector2(transform.position.x - 0.5f, transform.position.y ));

    }
    public void FireWave(int number)
    {
        if (GetComponentInParent<InputState>().direction == Directions.Right)
            GetComponentInParent<WaveAttack>().CreateProjectile(new Vector2(transform.position.x + 0.5f + (number * 1.5f), transform.position.y - 0.8f));
        else
            GetComponentInParent<WaveAttack>().CreateProjectile(new Vector2(transform.position.x - 0.5f - (number * 1.5f), transform.position.y - 0.8f));

    }
}
 