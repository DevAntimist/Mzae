using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectTileMotion : MonoBehaviour {

   private Rigidbody2D body2D;
    public int speed = 100;
    private Animator anim;
    private int Direction ;

    private float scale;
    public bool left = false;
    public float Timer = 5f;
    
	// Use this for initialization
	void Start () {
        anim = this.GetComponent<Animator>();
        body2D = GetComponent<Rigidbody2D>();
        scale = transform.localScale.x;
    }
	
	// Update is called once per frame
	void Update () {
        if (Timer > 0)
        {
            Timer -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
        if (left)
        {

            body2D.velocity = new Vector2(-speed, 0);
            transform.localScale = new Vector3(-scale, transform.localScale.y , transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(scale, transform.localScale.y , transform.localScale.z);
            body2D.velocity = new Vector2(speed, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
    
            Destroy(gameObject);
            GameObject GO = collision.gameObject;
            GO.GetComponent<HealthScript>().SubtractHeath(1);


        }
    }
}
