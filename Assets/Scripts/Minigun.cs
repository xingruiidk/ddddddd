using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Minigun : MonoBehaviour
{
    public Camera minigunCam;
    public Tank tank;
    private float mouseSensitivity = 2.0f;
    private float verticalRotation = 0f;
    private float horizontalRotation = 0f;
    private float maxVerticalRotation = 15f;
    private float minVerticalRotation = -90f;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        HandleCameraRotation();
    }


    private void HandleCameraRotation()
    {
        if (tank.IsMounted)
        {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        horizontalRotation += mouseX;

        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, minVerticalRotation, maxVerticalRotation);

        transform.Rotate(0, mouseX, 0);
        minigunCam.transform.localRotation = Quaternion.Euler(verticalRotation, horizontalRotation, 0);
        }
    }
}
