using UnityEngine;

public class GyroHandler : MonoBehaviour
{
    /*public Vector3 offset;
    void Start()
    {
        GetComponent<Camera>().transform.position = new Vector3(0, 0, 0);
    }

    protected void Update()
    {
        //transform.rotation = Input.gyro.attitude;
        //transform.rotation = Quaternion.Euler(Input.gyro.attitude.x, Input.gyro.attitude.y, Input.gyro.attitude.z);
        GyroModifyCamera();
    }
    // The Gyroscope is right-handed.  Unity is left handed.
    // Make the necessary change to the camera.
    void GyroModifyCamera()
    {
        Quaternion tmp = GyroToUnity(Input.gyro.attitude) * Quaternion.Euler(offset);
        tmp.z = 0;
        transform.rotation = tmp;

    }

    private static Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, q.y, q.z, q.w);
        //return  Quaternion.Euler(tempVector.x,tempVector.y,tempVector.z);
    }*/

    private float initialYAngle = 0f;
    private float appliedGyroYAngle = 0f;
    private float calibrationYAngle = 0f;

    void Start()
    {
        Application.targetFrameRate = 60;
        initialYAngle = transform.eulerAngles.y;
    }

    void Update()
    {
        ApplyGyroRotation();
        ApplyCalibration();
    }

    void OnGUI()
    {
        if (GUILayout.Button("Calibrate", GUILayout.Width(300), GUILayout.Height(100)))
        {
            CalibrateYAngle();
        }
    }

    public void CalibrateYAngle()
    {
        calibrationYAngle = appliedGyroYAngle - initialYAngle; // Offsets the y angle in case it wasn't 0 at edit time.
    }

    void ApplyGyroRotation()
    {
        transform.rotation = Input.gyro.attitude;
        transform.Rotate(0f, 0f, 180f, Space.Self); // Swap "handedness" of quaternion from gyro.
        transform.Rotate(90f, 180f, 0f, Space.World); // Rotate to make sense as a camera pointing out the back of your device.
        appliedGyroYAngle = transform.eulerAngles.y; // Save the angle around y axis for use in calibration.
    }

    void ApplyCalibration()
    {
        transform.Rotate(0f, -calibrationYAngle, 0f, Space.World); // Rotates y angle back however much it deviated when calibrationYAngle was saved.
    }
}