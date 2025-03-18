using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class PickUpObject : MonoBehaviour
{
    [SerializeField] private Transform CameraTransform;
    [SerializeField] private float DistanceHit = 3f;
    [SerializeField] private LayerMask pickupLayerMusk;
    [SerializeField] private Transform PointGrabTransform;
    [SerializeField] private InputActionReference interaction,use,drop;
    private ObjectCatch ObjectCatch;
    Ray ray;
    RaycastHit hit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interaction.action.performed += Interact;
        use.action.performed += Use;
        drop.action.performed += Drop;
    }

    private void Interact(InputAction.CallbackContext context)
    {
        if (Physics.Raycast(CameraTransform.transform.position, CameraTransform.transform.forward, out RaycastHit raycastHit, DistanceHit, pickupLayerMusk))
        {
            if (raycastHit.transform.TryGetComponent(out ObjectCatch objectCatch))
            {
                objectCatch.Grab(PointGrabTransform);
                ObjectCatch = objectCatch;
            }
        }
    }

    private void Use(InputAction.CallbackContext context)
    {
        ObjectCatch.Use();
    }

    private void Drop(InputAction.CallbackContext context)
    {
        ObjectCatch.Drop();
    }

    // Update is called once per frame
    void Update()
    {   
        Debug.DrawRay(CameraTransform.transform.position, CameraTransform.transform.forward * DistanceHit, Color.red);
    }
}
