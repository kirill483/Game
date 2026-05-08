using UnityEngine;

public class GravityField : MonoBehaviour
{
    public Vector3 pushDirection = Vector3.up;
    public float pushSpeed = 10f;

    private void OnTriggerStay(Collider other)
    {
        PickupObject pickupObject = other.GetComponent<PickupObject>();

        if (pickupObject == null)
            return;

        if (pickupObject.IsHeld)
            return;

        Rigidbody rb = other.GetComponent<Rigidbody>();

        if (rb == null)
            return;

        Vector3 direction = pushDirection.normalized;

        rb.linearVelocity = direction * pushSpeed;
    }
}