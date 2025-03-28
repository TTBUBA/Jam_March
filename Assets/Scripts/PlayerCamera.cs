using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public static PlayerCamera Instance;
    [SerializeField] private float SensX;
    [SerializeField] private float SensY;
    [SerializeField] private Transform Orientation;
    [SerializeField] private Transform Player;
    public bool ActiveCamera = true;
    float Xrotation;
    float Yrotation;

    private void Start()
    {
        Instance = this;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (ActiveCamera)
        {
            Vector3 FollowPlayer = Player.transform.position;
            transform.position = new Vector3(FollowPlayer.x, FollowPlayer.y + 1 , FollowPlayer.z);
            float MouseX = Input.GetAxis("Mouse X") * Time.deltaTime * SensX ;
            float MouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * SensY;

            Yrotation += MouseX;
            Xrotation -= MouseY;
            Xrotation = Mathf.Clamp(Xrotation, -90f, 90f);

            transform.rotation = Quaternion.Euler(Xrotation, Yrotation, 0);
            Orientation.rotation = Quaternion.Euler(0, Yrotation, 0f);
        }
    }
}