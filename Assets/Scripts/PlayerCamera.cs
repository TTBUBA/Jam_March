using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private float SensX;
    [SerializeField] private float SensY;
    [SerializeField] private Transform Orientation;
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
        float MouseX = Input.GetAxis("Mouse X") * Time.deltaTime * SensX ;
        float MouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * SensY;

        Yrotation += MouseX;
        Xrotation -= MouseY;
        Xrotation = Mathf.Clamp(Xrotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(Xrotation, Yrotation, 0);
        Orientation.rotation = Quaternion.Euler(0, Yrotation, 0f);
    }
}