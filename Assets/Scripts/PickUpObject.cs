using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class PickUpObject : MonoBehaviour
{
    [SerializeField] private Transform CameraTransform;
    [SerializeField] private float DistanceHit = 3f;
    [SerializeField] private LayerMask pickupLayerMusk;
    [SerializeField] private Transform PointGrabTransform;
    [SerializeField] private InputActionReference interaction,use,drop;
    [SerializeField] private GameObject UiPickUpPanel;
    [SerializeField] private TextMeshProUGUI TextPickUp;
    [SerializeField] private float RadiusRayCast;
    [SerializeField] private float DistanceRayCast;
    private ObjectCatch ObjectCatch;
    Ray ray;
    RaycastHit hit;

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
                UiPickUpPanel.SetActive(true);
                TextPickUp.text = "Press Q drop";
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
        TextPickUp.text = "Press E to PickUp";
        ObjectCatch.Drop();
        ObjectCatch = null;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Physics.Raycast(CameraTransform.transform.position, CameraTransform.transform.forward, out RaycastHit raycastHit, DistanceHit, pickupLayerMusk))
        {
            if (raycastHit.transform.TryGetComponent(out ObjectCatch objectCatch))
            {
                UiPickUpPanel.SetActive(true);
            }
            else
            {
                UiPickUpPanel.SetActive(false);
            }
        }
        
    }
}
