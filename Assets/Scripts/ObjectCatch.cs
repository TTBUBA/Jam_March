using UnityEngine;

public class ObjectCatch : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform PointGrabTransform;
    [SerializeField] private Transform PointDropTransform;
    private float lerpSpeed = 10f;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        PointGrabTransform = this.gameObject.transform;
    }
    public void Grab(Transform PointGrabTransform)
    {
        this.PointGrabTransform = PointGrabTransform;
        rb.useGravity = false;
    }
    
    public void Use()
    {
        this.PointGrabTransform = PointDropTransform;
        rb.useGravity = false;
    }
    public void Drop()
    {
        this.PointGrabTransform = null;
        rb.useGravity = true;
    }
    private void FixedUpdate()
    {
        Vector3 DirectionOnject = Vector3.Lerp(transform.position, PointGrabTransform.position, Time.deltaTime * lerpSpeed);
        rb.MovePosition(DirectionOnject);
    }
}
