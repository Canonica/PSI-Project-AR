using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchFish : MonoBehaviour {
    PlayerHandler playerHandler;
    bool hasLaunched;
	// Use this for initialization
	void Start ()
    {
        playerHandler = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHandler>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(!hasLaunched && ContextManager.instance.CompareContext(ContextManager.GameContext.Shoot))
        {
            LaunchFishRb();
        }

	}

    void LaunchFishRb()
    {
        if(playerHandler.fishCaughtList.Count > 0)
        {
            hasLaunched = true;
            foreach(Fish fish in playerHandler.fishCaughtList)
            {
                fish.beenCaught = true;
                fish.rb.isKinematic = false;
                fish.rb.constraints = RigidbodyConstraints.None | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
                fish.rb.AddForce(Random.Range(-0.7f, 0.7f), Random.Range(1, 1.2f), 0, ForceMode.Impulse);
            }
        }
        else
        {
            Debug.Log("No Fish Caught");
        }
    }
}
