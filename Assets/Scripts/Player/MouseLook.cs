using System;
using System.Collections;
using System.Collections.Generic;
// using Unity.Mathematics;
using UnityEngine;
// using System.Numerics;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    public Transform playerBody;

    private float xRotation;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    private void FixedUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity  * Time.fixedDeltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity /* / 19 */ * Time.fixedDeltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, 0f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX * mouseSensitivity * Time.fixedDeltaTime);   
        /*if (transform.rotation.x >= -0.2f && transform.rotation.x <= 0.2)
        {
            Debug.Log(transform.rotation.x * 10);
            
        }
        
        if (transform.rotation.x <= -0.2)
        {
            transform.Rotate(-10, 0, 0);
            Debug.Log("Passou acima");
        }
        if (transform.rotation.x >= 0.2)
        {
            transform.Rotate(10,0,0);
            Debug.Log("passou abaixo");
        }
        */
        
    }
}
