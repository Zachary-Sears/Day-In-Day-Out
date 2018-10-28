using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutSideTree : MonoBehaviour {

    public GameObject player;
    
    public float delay;
    public GameObject canvas;

    bool canInteract;
    bool alreadyUsed;

    // Use this for initialization
    void Start () {
        canInteract = false;
        alreadyUsed = false;

    }
	
	// Update is called once per frame
	void Update () {
        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            player.GetComponent<PlayerMovement>().Ocupied( delay, "That was a good apple", 10, false);
            alreadyUsed = true;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canInteract = !alreadyUsed;
        if (canInteract) canvas.GetComponent<UI_Manager>().UpdateMessage("Press E to use.");
        else canvas.GetComponent<UI_Manager>().UpdateMessage("");

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        canInteract = !alreadyUsed;
        if (canInteract) canvas.GetComponent<UI_Manager>().UpdateMessage("Press E to use.");
        else canvas.GetComponent<UI_Manager>().UpdateMessage("");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canInteract = false;
        canvas.GetComponent<UI_Manager>().UpdateMessage("");
    }
}
