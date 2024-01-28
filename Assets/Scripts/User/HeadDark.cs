using System.Collections;
using UnityEngine;

public class HeadDark : MonoBehaviour
{
    public MeshRenderer meshRenderer; // Reference to the MeshRenderer component
    private int triggerCount; // Counter for active triggers
    private Coroutine fadeCoroutine; // Reference to the fade coroutine

    private void Start()
    {
        if (meshRenderer == null)
        {
            Debug.LogError("Mesh Renderer is not assigned!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        triggerCount++; // Increment counter on entering a trigger
        CheckFade();
    }

    private void OnTriggerExit(Collider other)
    {
        if (triggerCount > 0)
        {
            triggerCount--; // Decrement counter on exiting a trigger
        }
        CheckFade();
    }

    private void CheckFade()
    {
        if (fadeCoroutine != null)
        {
            StopCoroutine(fadeCoroutine); // Stop any existing coroutine
        }

        // Start fading in or out based on the trigger count
        fadeCoroutine = StartCoroutine(triggerCount > 0 ? FadeAlpha(1.0f) : FadeAlpha(0.0f));
    }

    private IEnumerator FadeAlpha(float targetAlpha)
    {
        float duration = 2.0f; // Duration of the fade
        Color currentColor = meshRenderer.material.color;
        float startAlpha = currentColor.a;

        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            // Lerp the alpha value over time
            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, t / duration);
            meshRenderer.material.color = new Color(currentColor.r, currentColor.g, currentColor.b, newAlpha);
            yield return null;
        }

        // Ensure final alpha value is set
        meshRenderer.material.color = new Color(currentColor.r, currentColor.g, currentColor.b, targetAlpha);
    }
}