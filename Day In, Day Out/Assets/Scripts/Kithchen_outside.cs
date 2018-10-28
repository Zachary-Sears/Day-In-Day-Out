﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kithchen_outside : MonoBehaviour {

    public GameObject player;
    bool isInteractable;
    public GameObject canvas;
    // Use this for initialization
    void Start()
    {
        isInteractable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isInteractable == true && Input.GetKeyDown(KeyCode.E))
        {
            if (player.transform.position.x > -10f)
            {
                player.transform.position = new Vector2(-12f, player.transform.position.y);
            }
            else if (player.transform.position.x < -10f)
            {
                player.transform.position = new Vector2(-8.4f, player.transform.position.y);
            }

            gameObject.GetComponent<AudioSource>().Play();



        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInteractable = true;
            canvas.GetComponent<UI_Manager>().UpdateMessage("Press E to go through door.");
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
