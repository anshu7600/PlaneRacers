using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Mouselook : MonoBehaviour
{
    private PlayerInput controls;

    private float mouseXSensitivity = 10f;
    private float mouseYSensitivity = 20f;

    private Vector2 mouselook;

    private float xRotation = 0f;

    private Transform playerbody;

    private float vectorup = 1f;

    void Awake()
    {
        playerbody = transform.parent;

        controls = new PlayerInput();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        Look();
    }

    private void Look()
    {
        mouselook = controls.Player.Look.ReadValue<Vector2>();

        float mouseX = mouselook.x * mouseXSensitivity * Time.deltaTime;
        float mouseY = mouselook.y * mouseYSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        vectorup *= mouseX;
        
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerbody.Rotate(Vector3.up * mouseX);
    }

    private void OnEnable()
    {
        controls.Enable()
;    }

    private void OnDisable()
    {
        controls.Disable();
    }
}
