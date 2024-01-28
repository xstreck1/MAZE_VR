using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public enum Direction { Forward, Backward, Left, Right }

public class BodyCollision : MonoBehaviour
{
    string wallTag = "Wall";
    private Dictionary<GameObject, Direction> triggerColliders;

    private void Start()
    {
        triggerColliders = new Dictionary<GameObject, Direction>();
    }

    private Direction GetCollisionDirection(GameObject other)
    {
        var direction = transform.position - other.transform.position;
        direction.y = 0;
        // Keep only the maximum value in direction
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.z))
        {
            return direction.x > 0 ? Direction.Right : Direction.Left;
        }
        else
        {
            return direction.z > 0 ? Direction.Forward : Direction.Backward;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(wallTag))
        {
            triggerColliders[other.gameObject] = GetCollisionDirection(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(wallTag))
        {
            triggerColliders.Remove(other.gameObject);
        }
    }

    private void Update()
    {
        string dirs = string.Join(", ", triggerColliders.Values);
        Debug.Log("Count: " + triggerColliders.Count + ". Directions: " + dirs);
    }
    
    // Returns a list of directions that are blocked by walls, remove duplicates
    public List<Direction> BlockedDirections()
        => triggerColliders.Values.Distinct().ToList();
    
    public Vector3 StopBlockedDirections(Vector3 movement)
    {
        var collisions = BlockedDirections();
        if (collisions.Contains(Direction.Forward) && movement.z < 0)
        {
            movement.z = 0;
        }
        if (collisions.Contains(Direction.Backward) && movement.z >= 0)
        {
            movement.z = 0;
        }
        if (collisions.Contains(Direction.Right) && movement.x < 0)
        {
            movement.x = 0;
        }
        if (collisions.Contains(Direction.Left) && movement.x >= 0)
        {
            movement.x = 0;
        }
        return movement;
    }
}