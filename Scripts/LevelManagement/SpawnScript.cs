using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour {

    public GameObject[] obj;
    private int Sleep = 0;
  //  public float spawnMin = 1f;
 //   public float spawnMax = 2f;




	// Use this for initialization
	void Start ()
    {
        Spawn(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Spawn(bool always)
    {
        if (Sleep > 0)
        {
            Sleep--;
        }
        else
        {
            int Range = Random.Range(1, 4);
            if(Range > 1)
                Instantiate(obj[Random.Range(0, obj.GetLength(0))], transform.position, Quaternion.identity);
        }
        
    }
    public void addSleep(int amount)
    {
        Sleep = amount;
    }
}
