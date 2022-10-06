using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    float sensivity = 400;

    Transform playerTransform;
    float xRot;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerTransform = transform.parent;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensivity * Time.deltaTime;

        playerTransform.Rotate( Vector3.up * mouseX );

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -70, 50);
        transform.localRotation = Quaternion.Euler(new Vector3(xRot, 0, 0));
    }
}
