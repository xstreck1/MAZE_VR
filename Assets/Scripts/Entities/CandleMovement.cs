using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleMovement : MonoBehaviour
{
    public float radius = 5.0f;
    public float movementSpeed = 1.0f;
    private Vector3 origin;
    private Vector3 targetPosition;

    void Start()
    {
        origin = transform.localPosition;
        targetPosition = GetRandomPosition();
    }

    void Update()
    {
        MoveTowardsTarget();
        if (Vector3.Distance(transform.localPosition, targetPosition) < 0.1f)
        {
            targetPosition = GetRandomPosition();
        }
    }

    private void MoveTowardsTarget()
    {
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPosition, movementSpeed * Time.deltaTime);
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 randomDirection = Random.insideUnitSphere.normalized;
        float randomDistance = Random.Range(0, radius);
        
        // Bias towards the origin: reduce the distance for points further from the origin
        float distanceFromOrigin = Vector3.Distance(transform.localPosition, origin);
        if (distanceFromOrigin > radius / 2)
        {
            randomDistance *= 0.5f; // adjust this factor to control the bias strength
        }

        return origin + randomDirection * randomDistance;
    }
}
