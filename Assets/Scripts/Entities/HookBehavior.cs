using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookBehavior : MonoBehaviour {

    Vector3 gravity;
    public bool isUnderWater;
    Vector3 impactPosition;
    void Start()
    {
        gravity = Physics.gravity;
    }

    void FixedUpdate()
    {
        Physics.gravity = gravity;
        if(!isUnderWater && gravity.z != 9.81f)
        {
            gravity.x = 0;
            gravity.y = 0;
            gravity.z = 9.81f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Water")
        {
            isUnderWater = true;
            gravity.x = 0;
            gravity.y = -9.81f;
            gravity.z = 0;
            ContextManager.instance.TransitionWToD(other.gameObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position));
        }
    }

}
