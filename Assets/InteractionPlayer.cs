using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionPlayer : MonoBehaviour
{
    [SerializeField] private Transform Trash;
    [SerializeField] private Transform TransformPointTrash;
    private bool IsCollision;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && IsCollision)
        {
            UseTrash();
        }

        if (Input.GetKeyDown(KeyCode.Q) && IsCollision)
        {
            DropTrash();
        }
    }

    private void UseTrash()
    {
        Trash.SetParent(TransformPointTrash.transform);
        Trash.localPosition = new Vector3(0,0,1);
        Trash.localRotation = Quaternion.Euler(0,90,0);
    }
    private void DropTrash()
    {
        Trash.SetParent(null);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Basket"))
        {
            Debug.Log(other.name);
            IsCollision = true;
        }        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Basket"))
        {
            Debug.Log(other.name);
            IsCollision = false;
        }
    }
}
