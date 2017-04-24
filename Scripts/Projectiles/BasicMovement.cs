using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour {

    public float Speed = 50;
    public int Direction = 1;
    public float Life = 3;

    private float Countdown = 0;
    private Rigidbody2D body2d;
    private GameObject Temp;

    private void Awake()
    {
        Countdown = Life;
        body2d = GetComponent<Rigidbody2D>();
    }
    // Use this for initialization
    void Start () {
        body2d.velocity = new Vector2(Speed * Direction, 0);
	}
	
	// Update is called once per frame
	void Update ()
    {
        Countdown -= Time.deltaTime;
        if (Countdown < 0)
            Destroy(gameObject);
	}

    /*private void OnTriggerEnter2D(Collider2D target)
    {
        Debug.Log("UNITAYT USKCS ASS");
        Destroy(gameObject);
        if (target.tag == "Enemy")
        {
            Debug.Log("FML");

            Temp = target.gameObject;
            Temp.GetComponent<EnemyMotion>().Death();
        }
    } */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //ebug.Log("FUCKKK YEAH");
            Destroy(gameObject);
            GameObject GO = collision.gameObject;
            GO.GetComponent<EnemyMotion>().Death();
            //collision.gameObject.transform.gameObject.GetComponent<EnemyMotion>().Death();
            // Temp.transform.parent.gameObject.GetComponent<EnemyMotion>().Death();
            
        } 
    }
 
}
