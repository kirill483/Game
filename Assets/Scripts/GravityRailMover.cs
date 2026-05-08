using UnityEngine;

public class GravityRailMover : MonoBehaviour
{
    public Transform[] points;
    public float moveSpeed = 3f;

    private int currentIndex = 0;

    private void Start()
    {
        currentIndex = FindClosestPointIndex();
    }

    private void Update()
    {
        if (points == null || points.Length == 0)
            return;

        Vector3 targetPosition = points[currentIndex].position;

        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPosition,
            moveSpeed * Time.deltaTime
        );
    }

    public void MoveNext()
    {
        if (currentIndex < points.Length - 1)
        {
            currentIndex++;
        }
    }

    public void MovePrevious()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
        }
    }

    public void MoveLoop()
    {
        if (points == null || points.Length == 0)
            return;

        currentIndex++;

        if (currentIndex >= points.Length)
        {
            currentIndex = 0;
        }
    }

    private int FindClosestPointIndex()
    {
        if (points == null || points.Length == 0)
            return 0;

        int closestIndex = 0;
        float closestDistance = Vector3.Distance(transform.position, points[0].position);

        for (int i = 1; i < points.Length; i++)
        {
            float distance = Vector3.Distance(transform.position, points[i].position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestIndex = i;
            }
        }

        return closestIndex;
    }
}