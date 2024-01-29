using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class HeadDark : MonoBehaviour
{
    public MeshRenderer meshRenderer; // Reference to the MeshRenderer component
    private int triggerCount; // Counter for active triggers
    private Coroutine fadeCoroutine; // Reference to the fade coroutine
    public float wallHitDuration = 1.0f; // Duration of the fade

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

    public void FadeOut(float duration)
    {
        if (fadeCoroutine != null)
        {
            StopCoroutine(fadeCoroutine); 
        }
        fadeCoroutine = StartCoroutine(FadeAlpha(1.0f, duration));
    }
    
    public void FadeIn(float duration)
    {
        if (fadeCoroutine != null)
        {
            StopCoroutine(fadeCoroutine); 
        }
        fadeCoroutine = StartCoroutine(FadeAlpha(0.0f, duration));
    }
    
    private void CheckFade()
    {
        if (fadeCoroutine != null)
        {
            StopCoroutine(fadeCoroutine); // Stop any existing coroutine
        }

        // Start fading in or out based on the trigger count
        fadeCoroutine = StartCoroutine(
            triggerCount > 0 
                ? FadeAlpha(1.0f, wallHitDuration) 
                : FadeAlpha(0.0f, wallHitDuration)
                );
    }

    public IEnumerator FadeAlpha(float targetAlpha, float duration)
    {
        var currentColor = meshRenderer.material.color;
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
        fadeCoroutine = null;
    }
}