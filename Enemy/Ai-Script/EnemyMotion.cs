using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMotion : MonoBehaviour {
    Transform playerLoc;
    Transform EnemyLoc; 
    public Rigidbody2D body2D;
    public GameObject projectile;
    public int speed = 1;
    public float distanceNeededForAim = 5;
    public bool left = false;
        private Animator anim;
    
    private float scale;

    // Use this for initialization
    void Start ()
    {
        playerLoc = GameObject.FindGameObjectWithTag("Player").transform;
        body2D = GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
        scale = transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update () {
        
        if (left)
        {
            body2D.velocity = new Vector2(-speed, body2D.velocity.y);
            transform.localScale = new Vector3(-scale, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(scale, transform.localScale.y, transform.localScale.z);
            body2D.velocity = new Vector2(speed, body2D.velocity.y);
        }
        DetermineifAttack();
       
	}

    public void hit()
    {
        
        
            anim.SetInteger("State", 2);
        

    }

    public void Death()
    {
        Debug.Log("I FUCKING WIN");
        anim.SetInteger("State", 3);
        

    }

    public void Shooting()
    {
        
            CreateProjectile();
            anim.SetInteger("State", 1);
        
    }

    public void CreateProjectile()
    {
        Vector2 FUCKME = new Vector2(transform.position.x + 0.7f, transform.position.y + 0.4f);
        if (left)
            FUCKME = new Vector2(transform.position.x - 0, transform.position.y + 0);
        var clone = Instantiate(projectile, FUCKME, Quaternion.identity) as GameObject;
        clone.transform.localScale = transform.localScale;

        //determine if the projectile must go in the opposite direction
        if (left)
        {
            this.GetComponent<ProjectTileMotion>().left = left; 
        }
    }
        
    private void DetermineifAttack()
    {
        if (anim.GetInteger("State") != 3)
        {
            var distance = this.transform.localPosition.x - playerLoc.localPosition.x;
            var yDistance = this.transform.localPosition.y - playerLoc.localPosition.y;
            if(yDistance < 0)
            {
                anim.SetInteger("State", 0);
                distance = 0;
            }
            if (distance > 0)
            {
                
                if (distance < distanceNeededForAim)
                {
                    left = true;
                    speed = 0;
                    anim.SetInteger("State", 1);
                    Debug.Log("Target detected");
                    speed = 1;
                }
                else
                {
                    Debug.Log("nothing found");
                    anim.SetInteger("State", 0);
                }
            }
            else if (distance < 0)
            {
                left = false; 
                if (-distance < distanceNeededForAim)
                {
                    speed = 0;
                    anim.SetInteger("State", 1);
                    Debug.Log("Target detected");
                    speed = 1;
                }
                else
                {
                    Debug.Log("nothing found");
                    anim.SetInteger("State", 0);
                }
            }
        }
    }

    public void ChangeDirection(bool Left)
    {
        if(Left == true)
        {
            left = true;
        }
        else
        {
          
            left = false;
        }
    }
    public void ChangeState(int state)
    {
        anim.SetInteger("State", state);

    }

    public void ByeBye()
    {
        Destroy(gameObject);
    }
    
}
