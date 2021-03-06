﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Debug.Break();
            return;
        }
        if (other.gameObject.tag != "DontDelete")
        {
            if (other.gameObject.transform.parent)
            {
                Destroy(other.gameObject.transform.parent.gameObject);
            }
            else
            {
                Destroy(other.gameObject);
            }
        }
    }
}
