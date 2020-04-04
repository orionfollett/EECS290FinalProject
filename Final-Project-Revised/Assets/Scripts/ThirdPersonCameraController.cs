using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCameraController : MonoBehaviour
{
    public float RotationSpeed = 1;
    public Transform Target, Player;
    private Vector3 _offset;

    float mouseX, mouseY;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        CamControl();
    }

    private void CamControl()
    {
        mouseX += Input.GetAxis("Mouse X");
        mouseY -= Input.GetAxis("Mouse Y");

        
        mouseY = Mathf.Clamp(mouseY, -15, 40);

        

        Quaternion rotation = Quaternion.Euler(mouseY, mouseX, 0);
        transform.position = Target.position - (rotation * _offset);
        //Target.rotation = rotation;
        Player.rotation = Quaternion.Euler(mouseY, mouseX, 0);

        transform.LookAt(Target);
    }
}
