using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    public Camera playerCamera;
    public Transform holdPoint;

    public float pickupDistance = 3f;
    public float interactDistance = 3f;

    private PickupObject heldObject;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldObject != null)
            {
                DropObject();
                return;
            }

            if (TryPressButton())
            {
                return;
            }

            TryPickUp();
        }
    }

    private bool TryPressButton()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, interactDistance))
        {
            RailControlButton button = hit.collider.GetComponent<RailControlButton>();

            if (button != null)
            {
                button.Press();
                return true;
            }
        }

        return false;
    }

    private void TryPickUp()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, pickupDistance))
        {
            PickupObject pickupObject = hit.collider.GetComponent<PickupObject>();

            if (pickupObject != null)
            {
                heldObject = pickupObject;
                heldObject.PickUp(holdPoint);
            }
        }
    }

    private void DropObject()
    {
        heldObject.Drop();
        heldObject = null;
    }
}