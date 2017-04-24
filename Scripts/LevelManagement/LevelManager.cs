using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private float Score;
    private MoveWorld MW;
    public Text score;
	// Use this for initialization
	void Start ()
    {
        MW = GameObject.FindGameObjectWithTag("Player").GetComponent<MoveWorld>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Score = MW.getDistance();
        score.text = "Score: " + (int)Score;
	}
   
}
