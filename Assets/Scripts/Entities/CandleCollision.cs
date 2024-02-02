using UnityEngine;
using System.Collections;

public class CandleCollision : MonoBehaviour
{
    string wallTag = "Wall";
    public Light controlledLight; // Reference to the Light component
    public MeshRenderer holderMaterial;
    private int triggerCount; // Counter for active triggers
    private Coroutine fadeCoroutine; // Reference to the fade coroutine
    private float initialIntensity;
    private Color initialColor;
    public float duration = 1.0f; // Duration of the fade

    private void Start()
    {
        if (controlledLight == null)
        {
            Debug.LogError("Controlled Light is not assigned!");
            return;
        }
        initialIntensity = controlledLight.intensity;
        initialColor = holderMaterial.material.color;
        controlledLight.enabled = true; // Ensure the light is enabled initially
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(wallTag))
        {
            triggerCount++; // Increment counter on entering a trigger
            CheckFade();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(wallTag))
        {
            if (triggerCount > 0)
            {
                triggerCount--; // Decrement counter on exiting a trigger
            }
            CheckFade();
        }
    }

    private void CheckFade()
    {
        if (fadeCoroutine != null)
        {
            StopCoroutine(fadeCoroutine); // Stop any existing coroutine
        }

        // Start fading in or out based on the trigger count
        var fadeLightIntensity = triggerCount > 0
            ? FadeLightIntensity(0.0f, Color.black)
            : FadeLightIntensity(initialIntensity, initialColor);
        fadeCoroutine = StartCoroutine(fadeLightIntensity);
    }

    private IEnumerator FadeLightIntensity(float targetIntensity, Color color)
    {
        float startIntensity = controlledLight.intensity;
        Color startColor = holderMaterial.material.color;

        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            // Lerp the intensity over time
            float newIntensity = Mathf.Lerp(startIntensity, targetIntensity, t / duration);
            Color newColor = Color.Lerp(startColor, color, t / duration);
            controlledLight.intensity = newIntensity;
            holderMaterial.material.color = newColor;
            yield return null;
        }

        // Ensure final intensity value is set
        controlledLight.intensity = targetIntensity;
        holderMaterial.material.color = color;
    }
}