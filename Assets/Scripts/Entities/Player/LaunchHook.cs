using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchHook : MonoBehaviour {
    public GameObject hookPrefab;
    public float speedReduction;
    public void LaunchTheHook(float swipeStrength, Vector2 direction)
    {
        GameObject hook = Instantiate(hookPrefab, Camera.main.transform.position, Quaternion.identity);
        hook.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * swipeStrength / speedReduction, ForceMode.Impulse);
    }
}
