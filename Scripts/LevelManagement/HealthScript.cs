using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour {

    public int health = 1;
    public bool Player = false;
    public bool Enemy = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (health <= 0)
            CallDeath();
	}
    void SubtractHeath(int amount)
    {
        health -= amount;
    }
    void CallDeath()
    {
        if (Enemy)
            GameObject.Destroy(this);
    }
}
