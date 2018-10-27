using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour {

    bool canInteract;
    public GameObject player;
    bool isInteracting;


	// Use this for initialization
	void Start () {
        canInteract = false;
		
	}
	
	// Update is called once per frame
	void Update () {
        isInteracting = Input.GetKeyDown(KeyCode.E);
        if (canInteract == true && isInteracting == true)
        {
            player.GetComponent<PlayerMovement>().Trip();
        }
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canInteract = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canInteract = false;
    }
}
