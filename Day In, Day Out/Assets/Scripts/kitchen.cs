using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kitchen : MonoBehaviour {



    public GameObject player;
    public Sprite cook;
    public float delay;
    public GameObject canvas;

    bool canInteract;


    public float breakfastBegin;
    public float breakfastEnd;

    public float lunchBegin;
    public float lunchEnd;

    public float supperBegin;
    public float supperEnd;


    bool hadBreakfast;
    bool hadLunch;
    bool hadsupper;

    // Use this for initialization
    void Start () {
        canInteract = false;
        hadBreakfast = false;
        hadLunch = false;
        hadsupper = false;
          
		
	}
	
	// Update is called once per frame
	void Update () {
        if ((canvas.GetComponent<UI_Manager>().GetHour() >= breakfastEnd) && hadBreakfast == false)
        {
            player.GetComponent<PlayerMovement>().Ocupied(0, "You missed Breakfast", 15, true);
            hadBreakfast = true;

        }
        if ((canvas.GetComponent<UI_Manager>().GetHour() >= lunchEnd) && hadLunch == false)
        {
            player.GetComponent<PlayerMovement>().Ocupied(0, "You missed Lunch", 10, true);
            hadLunch = true;
        }
        if ((canvas.GetComponent<UI_Manager>().GetHour() >= supperEnd) && hadsupper == false)
        {
            player.GetComponent<PlayerMovement>().Ocupied(0, "You missed Supper", 5, true);
            hadsupper = true;
        }


        float time = canvas.GetComponent<UI_Manager>().GetHour();
        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {

            if(time >= breakfastBegin && time < breakfastEnd && hadBreakfast == false)
            {
                hadBreakfast = true;
                player.GetComponent<PlayerMovement>().Ocupied(cook, 0, "You had Breakfast", 10, false);

            }

            if (time >= lunchBegin && time < lunchEnd && hadLunch == false)
            {
                hadLunch = true;
                player.GetComponent<PlayerMovement>().Ocupied(cook, 0, "You had Lunch", 10, false);
            }
            if (time >= supperBegin && time < supperEnd && hadsupper == false)
            {
                hadsupper = true;
                player.GetComponent<PlayerMovement>().Ocupied(cook, 0, "You had Supper", 10, false);

            }















        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        float time = canvas.GetComponent<UI_Manager>().GetHour();
        if ( (time >= breakfastBegin && time < breakfastEnd && hadBreakfast == false)||(time >= lunchBegin && time < lunchEnd&&hadLunch==false)|| (time>=supperBegin&&time<supperEnd&&hadsupper==false))
        {
            canvas.GetComponent<UI_Manager>().UpdateMessage("Press E to eat.");
            canInteract = true;
        }



    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        float time = canvas.GetComponent<UI_Manager>().GetHour();
        if ((time > breakfastBegin && time < breakfastEnd && hadBreakfast == false) || (time > lunchBegin && time < lunchEnd && hadLunch == false) || (time > supperBegin && time < supperEnd && hadsupper == false))
        {
            canvas.GetComponent<UI_Manager>().UpdateMessage("Press E to eat.");
            canInteract = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canvas.GetComponent<UI_Manager>().UpdateMessage("");
        canInteract = false;

    }


}
