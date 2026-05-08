using UnityEngine;

public class PanelDoorController : MonoBehaviour
{
    public ActivationPanel activationPanel;

    public Vector3 openOffset = new Vector3(0, 3.5f, 0);
    public float openSpeed = 2f;

    private Vector3 closedPosition;
    private Vector3 openPosition;

    private void Start()
    {
        closedPosition = transform.position;
        openPosition = closedPosition + openOffset;
    }

    private void Update()
    {
        bool shouldOpen = activationPanel != null && activationPanel.IsActive;

        Vector3 targetPosition = shouldOpen ? openPosition : closedPosition;

        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPosition,
            openSpeed * Time.deltaTime
        );
    }
}