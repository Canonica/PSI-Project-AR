using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ArrowDirectionUI : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        if (ContextManager.instance.CompareContext(ContextManager.GameContext.Diving))
        {
            if(transform.eulerAngles.x != 0)
            {
                transform.DORotate(new Vector3(0, 0, 0), 0.2f);
            }
        }

        if (ContextManager.instance.CompareContext(ContextManager.GameContext.Ascent))
        {
            if (transform.eulerAngles.x != 180)
            {
                transform.DORotate(new Vector3(0, 0, 180), 0.2f);
            }
        }
    }
}
