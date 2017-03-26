using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AccelerometerInput : MonoBehaviour
{
    private Gyroscope gyro;
    Vector3 originalPos;
    float distance;
    void Start()
    { 
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
        }
    }

    void OnGUI()
    {
        /*
        GUILayout.Label("Gyroscope attitude : " + gyro.attitude);
        GUILayout.Label("Gyroscope gravity : " + gyro.gravity);
        GUILayout.Label("Gyroscope rotationRate : " + gyro.rotationRate);
        GUILayout.Label("Gyroscope rotationRateUnbiased : " + gyro.rotationRateUnbiased);
        GUILayout.Label("Gyroscope updateInterval : " + gyro.updateInterval);
        GUILayout.Label("Gyroscope userAcceleration : " + gyro.userAcceleration);
        */
    }

    void FixedUpdate()
    {
        if(ContextManager.instance.CompareContext(ContextManager.GameContext.Diving))
        {
            transform.Translate(new Vector3(Input.acceleration.x, -1, 0) * 10 * Time.fixedDeltaTime, Space.Self);
        }
        if (ContextManager.instance.CompareContext(ContextManager.GameContext.Ascent))
        {
            transform.Translate(new Vector3(Input.acceleration.x, 1, 0) * 10 * Time.fixedDeltaTime, Space.Self);
        }
        Vector3 test = originalPos - transform.position;
        distance = Vector3.Distance(originalPos, transform.position);
    }
}
