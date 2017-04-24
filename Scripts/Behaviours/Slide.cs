using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slide : AbstractBehaviour {

    public float scale = .5f;
    public bool sliding;
    public float centerOffsetY = 0;

    private CircleCollider2D circleCollider;
    private Vector2 originalCenter;

    protected override void Awake()
    {
        base.Awake();

        circleCollider = GetComponent<CircleCollider2D>();
        originalCenter = circleCollider.offset;
    }

    protected virtual void OnSlide(bool value)
    {
        sliding = value;

        ToggleScripts(!sliding);

        var size = circleCollider.radius;

        float newOffsetY;
        float sizeReciprocal;

        if(sliding)
        {
            sizeReciprocal = scale;
            newOffsetY = circleCollider.offset.y - size / 2 + centerOffsetY;
        }
        else
        {
            sizeReciprocal = 1 / scale;
            newOffsetY = originalCenter.y;
        }
        size = size * sizeReciprocal;
        circleCollider.radius = size;
        circleCollider.offset = new Vector2(circleCollider.offset.x, newOffsetY);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var canSlide = inputState.GetButtonValue(inputButtons[0]);
        if(canSlide && collisionState.standing && !sliding)
        {
            OnSlide(true);
        }
        else if(sliding && !canSlide)
        {
            OnSlide(false);
        }
	}
}
