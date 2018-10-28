using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TvCoutch : MonoBehaviour {

    public GameObject player;
    public Sprite sit;
    public float delay;
    public GameObject canvas;

    bool canInteract;

    public float footballTime;

    // Use this for initialization
    void Start () {
        canInteract = false;
	}
	
	// Update is called once per frame
	void Update () {
        if(canInteract&& Input.GetKeyDown(KeyCode.E))
        {
            gameObject.GetComponent<AudioSource>().Play();
            if ( canvas.GetComponent<UI_Manager>().GetHour() < footballTime)
            {
                player.GetComponent<PlayerMovement>().Ocupied(sit, delay, "It was daytime television", 10, true);
                canvas.GetComponent<UI_Manager>().AddHour(1);
            }
            else
            {
                player.GetComponent<PlayerMovement>().Ocupied(sit, delay, "It was football", 20, false);
                canvas.GetComponent<UI_Manager>().AddHour(1);

            }











        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canInteract = true;
        canvas.GetComponent<UI_Manager>().UpdateMessage("Press E to watch tv");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canInteract = false;
        canvas.GetComponent<UI_Manager>().UpdateMessage("");

    }

}
