using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_PlayerCamera : MonoBehaviour
{
    Camera PlayerCamera;
    Transform PlayerTransform;

    Vector3 CameraOffset = new Vector3(0, 0.75f, 0);

    float CameraSensitivity = 2.5f;
    float CameraX = 0f;
    float CameraY = 0f;

    private void Start()
    {
        PlayerCamera = GetComponentInChildren<Camera>();
        PlayerTransform = transform.Find("Body");
    }

    private void Update()
    {
        CameraX -= Input.GetAxis("Mouse Y")*CameraSensitivity;
        CameraY += Input.GetAxis("Mouse X")*CameraSensitivity;
        CameraX = Mathf.Clamp(CameraX, -85, 85);
        PlayerCamera.transform.position = PlayerTransform.position + (PlayerTransform.rotation * CameraOffset);
        PlayerCamera.transform.rotation = Quaternion.Euler(CameraX, CameraY, 0);
        

    }
}
