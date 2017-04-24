using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : AbstractBehaviour
{

    public bool dashing;
    public float dashTime = 0.8f;
    public float dashVelocity = 3;
    private float timeRemaining;



    protected virtual void OnDash(bool value)
    {
        dashing = value;

        ToggleScripts(!dashing);



        if (dashing)
        {
            if (inputState.direction == Directions.Right)
            {
                if (dashVelocity < 0)
                    dashVelocity *= -1;
            }
            if(inputState.direction == Directions.Left)
            {
                if (dashVelocity > 0)
                    dashVelocity *= -1;
            }
            timeRemaining = dashTime;
                                                                                              
        }

    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var canDash = inputState.GetButtonValue(inputButtons[0]);
        if(dashing && timeRemaining > 0)
        {
            body2d.velocity = new Vector2(dashVelocity, body2d.velocity.y);

            timeRemaining -= Time.deltaTime;
        }
        if (dashing && timeRemaining < 0)
        {
            OnDash(false);
            body2d.velocity = new Vector2(0,0);

        }

        if (canDash && collisionState.standing && !dashing)
        {
            OnDash(true);
        }

    }
}
