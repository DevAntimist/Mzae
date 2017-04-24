using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : AbstractBehaviour
{
    public float speed = 50f;
    public float runMultiplier = 2f;
    public bool running;
    public GameObject Limiter;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        var velX = 0f;
        running = false;

        var right = inputState.GetButtonValue(inputButtons[0]);
        var left = inputState.GetButtonValue(inputButtons[1]);
        var run = inputState.GetButtonValue(inputButtons[2]); 

        if (right || left)
        {
            var tmpSpeed = speed;

            if(run && runMultiplier > 0)
            {
                tmpSpeed *= runMultiplier;
                running = true;
            }
            velX = tmpSpeed * (float)inputState.direction;

            if (left)
            {
                if (transform.position.x < Limiter.transform.position.x)
                    velX = 0;
            }
            body2d.velocity = new Vector2(velX, body2d.velocity.y);
        }
    }
}
