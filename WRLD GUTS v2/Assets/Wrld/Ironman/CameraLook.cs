using UnityEngine;
using System.Collections;

public class CameraLook : MonoBehaviour
{
    public float horizontalSpeed = 2.0F;
    public float verticalSpeed = 2.0F;

    void Update() {

        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        float v = -verticalSpeed * Input.GetAxis("Mouse Y");

        transform.RotateAround(transform.position, transform.right, v);
        transform.RotateAround(transform.position, transform.forward, -h);
    }
}