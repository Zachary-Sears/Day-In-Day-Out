﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpStairsStairs : MonoBehaviour {


    public GameObject player;
    bool isInteractable;
    public GameObject canvas;

    // Use this for initialization
    void Start () {
        isInteractable = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (isInteractable == true && Input.GetKeyDown(KeyCode.E))
        {
            
                player.transform.position = new Vector2(6, -7);
            

        }

      

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInteractable = true;
            canvas.GetComponent<UI_Manager>().UpdateMessage("Press E to go down stairs.");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInteractable = false;
            canvas.GetComponent<UI_Manager>().UpdateMessage("");
        }

    }

}
