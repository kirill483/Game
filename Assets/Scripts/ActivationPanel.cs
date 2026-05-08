using UnityEngine;

public class ActivationPanel : MonoBehaviour
{
    public bool IsActive { get; private set; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PickupObject>() != null)
        {
            IsActive = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PickupObject>() != null)
        {
            IsActive = false;
        }
    }
}