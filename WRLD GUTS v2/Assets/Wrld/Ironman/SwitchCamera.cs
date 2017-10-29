using UnityEngine;
using System.Collections;

public class SwitchCamera : MonoBehaviour
{
    public Camera mainCamera;
    public Camera previewCamera; 

    void Start()
    {
        this.mainCamera.enabled = true;
        this.previewCamera.enabled = false;
    }

    void Update()
    {
        
    }

    public void SwitchCameraPlayer()
    {
        this.mainCamera.enabled = true;
        this.previewCamera.enabled = false;
    }

    public void SwitchCameraMission()
    {
        this.mainCamera.enabled = false;
        this.previewCamera.enabled = true;
    }
}