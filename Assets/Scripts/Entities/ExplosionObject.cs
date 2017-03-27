using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 0.5f);
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Fish")
        {
            other.GetComponent<Fish>();
        }
    }
}
