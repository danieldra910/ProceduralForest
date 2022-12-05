using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float MouseX;
    float MouseY;

    [SerializeField]
    float MouseSensitivity = 15f;

    float xRotation;
    // Start is called before the first frame update
    void Start()
    {
        MouseX = 0;
        MouseY = 0;
    }

    // Update is called once per frame
    void Update()
    {
        MouseY += Input.GetAxis("Mouse X") * MouseSensitivity;
        MouseX += Input.GetAxis("Mouse Y") * -MouseSensitivity;

        transform.localEulerAngles = new Vector3 (MouseX, MouseY, 0);
    }
}
