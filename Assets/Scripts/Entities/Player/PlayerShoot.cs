using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {
    public GameObject prefabZone;
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && ContextManager.instance.CompareContext(ContextManager.GameContext.Shoot))
        {
            Vector3 fingerPos = Input.GetTouch(0).position;
            fingerPos.z = 10;
            Vector3 objPos = Camera.main.ScreenToWorldPoint(fingerPos);
            Instantiate(prefabZone, objPos, Quaternion.identity);
        }
    }

}
