using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CheckEndGame : MonoBehaviour {
    PlayerHandler playerHandler;
	// Use this for initialization
	void Start ()
    {
        playerHandler = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHandler>();
	}
	
	// Update is called once per frame
	void Update () {
        if (ContextManager.instance.CompareContext(ContextManager.GameContext.Shoot))
        {
            if(playerHandler.fishCaughtList.All(item => !item.GetComponentInChildren<Renderer>().isVisible))
            {
                StartCoroutine(ContextManager.instance.EndGame());
            }
            
        }
	}
}
