using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float SensX;
    [SerializeField] private float SensY;

    float Xrotation;
    float Yrotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    // Update is called once per frame
    void Update()
    {
        float MouseX = Input.GetAxis("Mouse X") * SensX * Time.deltaTime;
        float MouseY = Input.GetAxis("Mouse Y") * SensY * Time.deltaTime;

        Xrotation += MouseX;
        Yrotation -= MouseY;

        Yrotation = Mathf.Clamp(Yrotation, -90f, 90f);
        transform.rotation = Quaternion.Euler(Yrotation, Xrotation, 0f);
    }
}
