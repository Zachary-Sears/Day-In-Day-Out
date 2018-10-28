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

    public float firstwarningTime;
    bool FwarningGiven;

    public float secondwarningTime;
    bool SwarningGiven;

    public float forcedSleep;

    float currentTime;

    public Sprite exuasted;

	// Use this for initialization
	void Start () {
        bedTime = false;
		
	}
	
	// Update is called once per frame
	void Update () {
        bedTime = canvas.GetComponent<UI_Manager>().GetHour() >= timeForBed;
        currentTime = canvas.GetComponent<UI_Manager>().GetHour();

        if (isIntractable&& Input.GetKeyDown(KeyCode.E))
        {
            DeterminWin();

        }

        if(currentTime>= firstwarningTime&&FwarningGiven==false)
        {
            canvas.GetComponent<UI_Manager>().UpdateBMessage("Time for bed", Color.green);
            FwarningGiven = true;
        }

        if (currentTime >= secondwarningTime && SwarningGiven == false)
        {
            canvas.GetComponent<UI_Manager>().UpdateBMessage("It's really late go to bed!", Color.red);
            canvas.GetComponent<UI_Manager>().DecreaseHappiness(5);
            SwarningGiven = true;
        }
        if (currentTime >= forcedSleep)
        {
            player.GetComponent<PlayerMovement>().Ocupied(exuasted, 500,"You fell over from exaustion", 15, true);
            canvas.GetComponent<UI_Manager>().DecreaseHappiness(15);

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

    private void OnTriggerStay2D(Collider2D collision)
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
