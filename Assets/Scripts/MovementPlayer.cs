using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    public static MovementPlayer Instance;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float gravity = -9.8f;
    [SerializeField] private CharacterController controller;
    public bool ActiveMovement = true;
    private Vector3 velocity;

    void Start()
    {
        Instance = this;
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (ActiveMovement)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 direction = transform.TransformDirection(horizontal, 0 , vertical);
            if (direction.magnitude > 1f)
            {
                direction.Normalize();
            }

            controller.Move(direction * speed * Time.deltaTime);

            // Applying gravity
            if (controller.isGrounded && velocity.y < 0)
            {
                velocity.y = -2f; // Small downward force to keep grounded
            }

            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);

            if (controller.isGrounded && Input.GetButtonDown("Jump"))
            {
                velocity.y = jumpForce;
            }          
        }

    }
}
