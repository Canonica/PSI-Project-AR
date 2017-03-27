using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialDistanceTrigger : MonoBehaviour {
    PlayerHandler playerHandler;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && ContextManager.instance.CompareContext(ContextManager.GameContext.Ascent))
        {
            ContextManager.instance.SwitchContext(ContextManager.GameContext.TransitionAtoS);
        }
    }
}
