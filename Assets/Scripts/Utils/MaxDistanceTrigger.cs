using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxDistanceTrigger : MonoBehaviour {
    PlayerHandler playerHandler;
	// Use this for initialization
	void Start ()
    {
        playerHandler = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHandler>();
        transform.position = new Vector3(0, -playerHandler.distanceScript.maxDistance, 0);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            ContextManager.instance.SwitchContext(ContextManager.GameContext.TransitionDToA);
        }
    }
}
