using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class EnemySpawn : MonoBehaviour {

    public GameObject[] Enemy;
    public bool Triggered = false;
    private int willSpawn;
    public void Start()
    {
        DetermineSpawn(transform.position.x,transform.position.y,3);
    }
    public void DetermineSpawn(float posX, float posY, int Difficulty)
    {
        willSpawn = Random.Range(1, 10);
        if (Difficulty == 1)
        {
            if (willSpawn == 5)
            {
                GameObject toInstantiate = Enemy[Random.Range(0, Enemy.Length)];

                GameObject instance = Instantiate(toInstantiate, new Vector3(posX, posY, 0f), Quaternion.identity) as GameObject;

            }
        }
        if (Difficulty == 2)
        {
            if (willSpawn == 3 || willSpawn == 6)
            {
                GameObject toInstantiate = Enemy[Random.Range(0, Enemy.Length)];
                GameObject instance = Instantiate(toInstantiate, new Vector3(posX, posY, 0f), Quaternion.identity) as GameObject;
                toInstantiate = Enemy[Random.Range(0, Enemy.Length)];
                GameObject instance2 = Instantiate(toInstantiate, new Vector3(posX + 2, posY, 0f), Quaternion.identity) as GameObject;
            }
        }
        if (Difficulty == 3)
        {
            if (willSpawn == 2 || willSpawn == 5 || willSpawn == 7)
            {
                GameObject toInstantiate = Enemy[Random.Range(0, Enemy.Length)];
                GameObject instance = Instantiate(toInstantiate, new Vector3(posX, posY, 0f), Quaternion.identity) as GameObject;
                toInstantiate = Enemy[Random.Range(0, Enemy.Length)];
                GameObject instance2= Instantiate(toInstantiate, new Vector3(posX + 2, posY, 0f), Quaternion.identity) as GameObject;
                toInstantiate = Enemy[Random.Range(0, Enemy.Length)];
                GameObject instance3= Instantiate(toInstantiate, new Vector3(posX + 4, posY, 0f), Quaternion.identity) as GameObject;

            }//hello
        }
    }
    }




