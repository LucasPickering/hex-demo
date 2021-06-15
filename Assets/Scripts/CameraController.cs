using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float rotateSpeed = 50.0f;
    public float minYAngle = 180.0f;
    public float maxYAngle = 270.0f;
    public KeyCode keyRotateLeft = KeyCode.Q;
    public KeyCode keyRotateRight = KeyCode.E;

    void Start()
    {
        this.transform.LookAt(Vector3.zero);
    }

    // Update is called once per frame
    void Update()
    {

        // Adjust camera zoom based on scroll wheel
        var camera = gameObject.GetComponent<Camera>();

        // Rotate the camera based on rotate keys
        var yRotation = GetYRotation();
        var currentYAngle = this.transform.eulerAngles.y;
        if ((yRotation < 0f && currentYAngle > this.minYAngle) || (yRotation > 0f && currentYAngle < this.maxYAngle))
        {
            this.transform.RotateAround(Vector3.zero, Vector3.up, yRotation);
        }
    }


    private float GetYRotation()
    {
        float yRotation = 0f;
        if (Input.GetKey(keyRotateLeft))
        {
            yRotation += 1f;
        }
        if (Input.GetKey(keyRotateRight))
        {
            yRotation -= 1f;
        }
        return yRotation * rotateSpeed * Time.deltaTime;
    }
}
