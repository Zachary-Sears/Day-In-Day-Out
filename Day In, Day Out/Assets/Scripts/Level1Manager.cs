using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Manager : MonoBehaviour {

    float timeleft;
    public float timeStart;
    public float happynessStart;
    public float happynessThreshhol;
    float happyness;

	// Use this for initialization
	void Start () {
        happyness = happynessStart;
        timeleft = timeStart;

		
	}
	
	// Update is called once per frame
	void Update () {

        timeleft -= Time.deltaTime;


		
	}

    private void updateHappyness(float adjustment)
    {
        happyness += adjustment;

    }


}
