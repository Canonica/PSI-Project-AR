using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class AccelerometerInput : MonoBehaviour
{

    private Gyroscope gyro;

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
        GUILayout.Label("Gyroscope attitude : " + gyro.attitude);
        GUILayout.Label("Gyroscope gravity : " + gyro.gravity);
        GUILayout.Label("Gyroscope rotationRate : " + gyro.rotationRate);
        GUILayout.Label("Gyroscope rotationRateUnbiased : " + gyro.rotationRateUnbiased);
        GUILayout.Label("Gyroscope updateInterval : " + gyro.updateInterval);
        GUILayout.Label("Gyroscope userAcceleration : " + gyro.userAcceleration);
    }

    void FixedUpdate()
    {
        transform.Translate(new Vector3(Input.acceleration.x, 0, 0) * 10 * Time.fixedDeltaTime, Space.Self);
    }
}
