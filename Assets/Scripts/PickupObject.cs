using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PickupObject : MonoBehaviour
{
    private Rigidbody rb;
    private Transform originalParent;

    public bool IsHeld { get; private set; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        originalParent = transform.parent;
    }

    public void PickUp(Transform holdPoint)
    {
        IsHeld = true;

        rb.isKinematic = true;
        rb.useGravity = false;

        transform.SetParent(holdPoint);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }

    public void Drop()
    {
        IsHeld = false;

        transform.SetParent(originalParent);

        rb.isKinematic = false;
        rb.useGravity = true;
    }
}