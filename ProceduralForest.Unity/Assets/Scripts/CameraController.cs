using UnityEngine;

public class CameraController : MonoBehaviour
{
    float MouseX;
    float MouseY;

    [SerializeField]
    float MouseSensitivity = 15f;

    void Start()
    {
        MouseX = 0;
        MouseY = 0;
    }

    void Update()
    {
        MouseY += Input.GetAxis("Mouse X") * MouseSensitivity;
        MouseX += Input.GetAxis("Mouse Y") * -MouseSensitivity;

        transform.localEulerAngles = new Vector3 (MouseX, MouseY, 0);

        if(Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}
