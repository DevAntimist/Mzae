using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public bool exitButton = false;
    public bool startButton = false;

    private Button button;
	// Use this for initialization
	void Start ()
    {
        button = this.GetComponent<Button>();
        button.onClick.AddListener(TaskOnClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void TaskOnClick()
    {
        if(exitButton)
        {
            Application.Quit();
        }
        else if(startButton)
        {
            SceneManager.UnloadSceneAsync("MainMenu");
            //SceneManager.UnloadScene("MainMenu");
            SceneManager.LoadScene("PlayerStaging", LoadSceneMode.Additive);
        }
    }
}
