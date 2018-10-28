using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bed : MonoBehaviour {

    public GameObject player;
    public GameObject canvas;
    bool isIntractable;
    bool bedTime;
    public float timeForBed;

	// Use this for initialization
	void Start () {
        bedTime = false;
		
	}
	
	// Update is called once per frame
	void Update () {
        bedTime = canvas.GetComponent<UI_Manager>().GetHour() >= timeForBed;

        if(isIntractable&& Input.GetKeyDown(KeyCode.E))
        {
            DeterminWin();

        }
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (bedTime)
        {
            isIntractable = true;
            canvas.GetComponent<UI_Manager>().UpdateMessage("Press E to go to Bed");
        }
        
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isIntractable = false;
    }

    private void DeterminWin()
    {
        if(canvas.GetComponent<UI_Manager>().getRatio() >=.75)
        {
            SceneManager.LoadScene("Youwin");
        }
        else
        {
            canvas.GetComponent<UI_Manager>().UpdateMessage("You had a bad day. Let's try again.");
            canvas.GetComponent<UI_Manager>().SetInBed();
        }

    }



}
