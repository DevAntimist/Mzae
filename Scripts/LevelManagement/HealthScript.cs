using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour {

    public int health = 5;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (health <= 0)
            CallDeath();
	}
    public void SubtractHeath(int amount)
    {
        health -= amount;   
    }
    void CallDeath()
    {
        //Code to reset the level, or display the score
    }
}
