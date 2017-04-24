using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWorld : AbstractBehaviour
{

    public GameObject[] Objs;
    private float[] Position;
    private float furtherestPosition = 0;
    private List<int> nextGeneration = new List<int>();
    public GameObject[] Spawners;
    private int secondaryPlatforms = 0;
    private int sleepCounter = 0;
    private float MoveBackground = 450;

	// Use this for initialization
	void Start ()
    {
        nextGeneration.Add(0);
        nextGeneration.Add(6);
        nextGeneration.Add(12);
        nextGeneration.Add(18);
        Position = new float[Objs.Length];
	   	for(int i = 0; i < Objs.Length;i++)
        {

            Position[i] = Objs[i].transform.position.x;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (transform.position.x > furtherestPosition)
            furtherestPosition = transform.position.x;
        if (inputState.direction == Directions.Right && transform.position.x >= furtherestPosition - 0.02) 
        {
            for(int i = 0; i < Objs.Length; i++)
            {
                Objs[i].transform.position = new Vector3(Position[i] + transform.position.x, Objs[i].transform.position.y, Objs[i].transform.position.z);
            }
        }
        if(furtherestPosition > MoveBackground)
        {
           // Debug.Log("Crap");
            MoveBackground += 450;
            GameObject.FindGameObjectWithTag("Terrain").GetComponent<ScrollScript>().onCall();
        }
        if(transform.position.x > nextGeneration[0])
        {
            nextGeneration.RemoveAt(0);
            nextGeneration.Add(nextGeneration[2] + 6);
            if (sleepCounter > 0)
            {
                sleepCounter--;
             //   Debug.Log("Status 0");

            }
            else
            {
                //   Debug.Log("Status 1");
                if (secondaryPlatforms == 0)
                {

                        Spawners[0].GetComponent<SpawnScript>().Spawn(true);

                }
                else
                {
                    for (int i = 0; i < Spawners.Length; i++)
                    {
                        Spawners[i].GetComponent<SpawnScript>().Spawn(false);

                    }
                }
                if (secondaryPlatforms < 2)
                {
                    secondaryPlatforms++;

                }
                else if (Random.Range(1, 2) == 1 && secondaryPlatforms < 5)
                {
                    secondaryPlatforms++;
                //    Debug.Log("Status 2");
                }
                else
                {
                    for (int i = 0; i < Spawners.Length; i++)
                    {
                        sleepCounter = Random.Range(2, 4);
                        Spawners[i].GetComponent<SpawnScript>().addSleep(sleepCounter);
                        secondaryPlatforms = 0;
                   //     Debug.Log("Status 3");


                    }
                }
            }

        }
		
	}
    public float getDistance()
    {
        return furtherestPosition;
    }
}
