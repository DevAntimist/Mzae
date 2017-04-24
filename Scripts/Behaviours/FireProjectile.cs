using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : AbstractBehaviour {

    public float shootDelay = .5f;
    public GameObject projectilePrefab;
    private BasicMovement projectileMovement;
    public GameObject arm;

    private float timeElapsed = 0f;

	// Use this for initialization

	
	// Update is called once per frame
	void Update ()
    {
		if(projectilePrefab != null)
        {
            Debug.Log("FIREDSDDD");
            var canFire = inputState.GetButtonValue(inputButtons[0]);

            if(canFire && timeElapsed > shootDelay)
            {
                arm.GetComponent<ArmScript>().ChangeState(1);
               // CreateProjectile(transform.position);
                timeElapsed = 0;
            }
            timeElapsed += Time.deltaTime;
        }
	}

    public void CreateProjectile(Vector2 pos)
    {
        var clone = Instantiate(projectilePrefab, pos, Quaternion.identity) as GameObject;
       // clone.transform.localScale = transform.localScale;
        projectileMovement = clone.GetComponent<BasicMovement>();
        //if(inputState.direction == Directions.Left)

        if (inputState.direction == Directions.Left)
            projectileMovement.Direction = -1;



    }
}
