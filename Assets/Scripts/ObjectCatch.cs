using System.Collections;
using UnityEngine;

public class ObjectCatch : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform PointGrabTransform;
    [SerializeField] private Transform Trash;
    //[SerializeField] private Transform PointDropTransform;
    private float lerpSpeed = 10f;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        PointGrabTransform = this.gameObject.transform;
    }
    private void FixedUpdate()
    {
        if (PointGrabTransform != null)
        {
            Vector3 DirectionOnject = Vector3.Lerp(transform.position, PointGrabTransform.position, Time.deltaTime * lerpSpeed);
            rb.MovePosition(DirectionOnject);
        }
    }

    public void Grab(Transform PointGrabTransform)
    {
        this.PointGrabTransform = PointGrabTransform;
        rb.useGravity = false;
    }
    
    /*
    public void Use()
    {
        this.PointGrabTransform = PointDropTransform;
        rb.useGravity = false;
    }
    */
    public void Drop()
    {
        this.PointGrabTransform = null;
        rb.useGravity = true;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trash"))
        {
            this.gameObject.transform.SetParent(Trash.transform);
            StartCoroutine(DisactivePhysics());
            GameManager.instance.CountObjectPickUp += 1;
        }
    }

    IEnumerator DisactivePhysics()
    {
        yield return new WaitForSeconds(5f);
        Destroy(rb);
    }

}
