using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour {

    //we use serializable to embed a class with sub properties//
    [Serializable]
    public class Count
    {
        public int minimum; //min value for the count class//
        public int maximum; //max value for the count class//

        public Count(int min , int max)
        {
            minimum = min;
            maximum = max; 
        } // help

    }
    #region variables
    public int columns = 500;
    public int rows =2;
    public int counter = 0; 
    public Count TerrainCount = new Count(5, 500);
    public Count PlatformLimit = new Count(15, 20);
    public int Start;
    public int Stop;
    public GameObject[] floorTiles;
    public GameObject[] Platforms; 
    public GameObject[] Walls;
    public GameObject[] Enemy;
    public GameObject[] Traps;

    public int extraPlatformMax = 3;
    private int extraPlatform = 0;
    private bool spawnExtra = false;

    #endregion



    private Transform boardholder; 
    private List<Vector3> GridPositions= new List<Vector3>();

    //Clear the list GridPositions and generate a new Board//
    void InitialiseList()
    {
        //Clear the list GridPositions
        GridPositions.Clear();

        //fill the x axis with terrain//
        for (int x = 1; x < columns - 1; x++)
        {
            //fill the y axis with terrain//
            for (int y = 1; y < rows - 1; y++)
            {
                GridPositions.Add(new Vector3(x, y, 0f));
            }
        }

    }

    //setup the background of the game board//
    void BoardSetup()
    {
        //initialise the boardholder to its transform//
        boardholder = new GameObject("Board").transform;
        //loop along the x axis to fill up the terrain starting at the corner//
        for (int x = 0; x < columns; x++)
        {
           
            //loop along the y to do the same thing//
            for(int y = 0; y < rows ; y++)
            {

                
                //choose a random tile and fill the terrain with it//
                GameObject toInstantiate = floorTiles[Random.Range(0, floorTiles.Length)];
                
                //instantiate the game object instance using the prefab that has been chosen//
                GameObject instance = Instantiate(toInstantiate, new Vector3(x - 7, y-2, 0f), Quaternion.identity) as GameObject;
                instance.transform.SetParent(boardholder);
            } 

        }

        int PlatformLocation = Random.Range(3, 7);
        int Counter = 0;
        int isPlatform;
        int height;
        int size;
        //PlatForm Generation
        for (int i = 0; i < columns; i++)
        {
            Counter++;
            if (true)
            {
                isPlatform = Random.Range(2, 3); //Generates platform at etc
                if (isPlatform == 2 && !spawnExtra)
                {
                    height = Random.Range(3, 5);
                    size = Random.Range(1, 3);

                     i += PlatformCreation(i, size, height);
                    generateEnemy(i, height);
                }
                if (spawnExtra && extraPlatform < 3)
                {
                    extraPlatform++;

                    height = Random.Range(5, 7);
                    size = Random.Range(1, 4);
                    if (size == 3)
                        size = 4;
                    i += PlatformCreation(i, size, height);
                }
                else if (extraPlatform >= 3)
                    spawnExtra = false;

            }




        }
        
       

    }

    private void generateTrap(int one, int two)
    {
       for (int i = one -2; i < two + 6; i++)
        {
            GameObject toInstantiate = Traps[Random.Range(0, Enemy.Length)];
            GameObject instance = Instantiate(toInstantiate, new Vector3(i, -1, 0f), Quaternion.identity) as GameObject;
        }
    }

    void generateEnemy(int x, int height)
    {
        int DisplayEnemy = Random.Range(1, 6);
        if (DisplayEnemy == 2 || DisplayEnemy == 4)
        {
            GameObject toInstantiate = Enemy[Random.Range(0, Enemy.Length)];
            GameObject instance = Instantiate(toInstantiate, new Vector3(x + Random.Range(1, 4), height + 1 , 0f), Quaternion.identity) as GameObject;
        }
    }


    //void CreatePlatform(int x, int height)
   // {
      //  Start = x;
       // Debug.Log(x);
      //  int Whatever = Random.Range(0, Platforms.Length);
     //   GameObject toInstantiate = Platforms[Whatever];
      //  Stop = x + Whatever;
    //    Debug.Log(Stop);
     //   GameObject instance = Instantiate(toInstantiate, new Vector3(x, height, 0f), Quaternion.identity) as GameObject;
     //   generateTrap(Start, Stop);

  //  }



    //randomposition returns a random position from our list gridpositions//
    Vector3 RandomPostion()
    {
        int randomIndex = Random.Range(0, GridPositions.Count);

        //declare a variable that sets its value to the entry at randomIndex//
        Vector3 randomPosition = GridPositions[randomIndex];

        GridPositions.RemoveAt(randomIndex);
        
        return randomPosition;
    }

    void LayoutObjectAtRandom(GameObject[] tileArray, int minimum , int maximum)
    {
        int objectCount = Random.Range(minimum, maximum+1);

        for(int i = 0; i < objectCount; i++)
        {
            Vector3 randomPosition = RandomPostion();

            GameObject tileChoice = tileArray[Random.Range(0, tileArray.Length)];

            Instantiate(tileChoice, randomPosition, Quaternion.identity);
        }

    }

  

    public void SetupScene(int level)
    {
        BoardSetup();

        InitialiseList();

        

       
    }
    public int PlatformCreation(int x,int size, int height)
    {
        int i;
        for(i = x; i < x + (4*size); i++)
        {
            GameObject toInstantiate = Platforms[0];
            GameObject instance = Instantiate(toInstantiate, new Vector3(i, height, 0f), Quaternion.identity) as GameObject;
            TrapCreation(i);

        }
        counter = 0;
        if (!(Random.Range(1, 5) == 4) && extraPlatform < extraPlatformMax)
        {
            int Range = Random.Range(3, 5);
            spawnExtra = true;
            for (int o = 0; o < Range + 1; o++)
                TrapCreation(i + o);
            return (Range + (4 * size));
        }
        else
        {
            extraPlatform = 0;
            spawnExtra = false;
            return (Random.Range(25, 30) + (4 * size));
        }
    }

    public void TrapCreation(int x)
    {
        GameObject toInstantiate = Traps[Random.Range(0, Enemy.Length)];
        GameObject instance = Instantiate(toInstantiate, new Vector3(x + 3, -1, 0f), Quaternion.identity) as GameObject;
    }


}
