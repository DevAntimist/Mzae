using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnAroundScript : MonoBehaviour {

    public bool Left = false;
    public bool Right = false;
    private GameObject Temp;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.gameObject.tag == "Enemy")
        {
            
            Temp = collision.gameObject;
            Temp.GetComponent<EnemyMotion>().ChangeDirection(!Left);
        }
    }
}
