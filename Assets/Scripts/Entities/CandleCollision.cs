using UnityEngine;

public class CandleCollision : MonoBehaviour
{
    public Light controlledLight; // Reference to the Light component
    private int triggerCount; // Counter for active triggers

    private void Start()
    {
        if (controlledLight == null)
        {
            Debug.LogError("Controlled Light is not assigned!");
        }

        // Initialize the light based on your requirements
        controlledLight.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        triggerCount++; // Increment counter on entering a trigger
    }

    private void OnTriggerExit(Collider other)
    {
        if (triggerCount > 0)
        {
            triggerCount--; // Decrement counter on exiting a trigger
        }
    }

    private void Update()
    {
        // If there are no active triggers, turn on the light
        controlledLight.enabled = triggerCount == 0;
    }
}