using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UserRig : MonoBehaviour
{
    [SerializeField] private HeadDark headDark;
    [SerializeField] private TextMeshPro headText;
    [SerializeField] private ExitHit exitHit;

    public event Action OnExitHit
    {
        add => exitHit.OnExitHit += value;
        remove => exitHit.OnExitHit -= value;
    }
    
    private Coroutine activeCoR;

    private IEnumerator DisplayMessageCoR(string message, float duration)
    {
        yield return FadeInMessageCoR(1.0f);
        if (duration > 2)
        {
            yield return new WaitForSeconds(duration - 2);
        }
        yield return FadeOutMessageCoR(1.0f);
        activeCoR = null;
    }

    public void DisplayMessage(string message, float duration = 5.0f)
    {
        if (duration > 0)
        {
            if (activeCoR != null)
                StopCoroutine(activeCoR);
            headText.text = message;
            activeCoR = StartCoroutine(DisplayMessageCoR(message, duration));
        }
        else
        {
            headText.text = message;
        }
    }
    
    public void FadeOut(float duration)
    {
        headDark.FadeOut(duration);
    }
    
    public void FadeIn(float duration)
    {
        headDark.FadeIn(duration);
    }
    
    private IEnumerator FadeInMessageCoR(float time)
    {
        var c = headText.color;
        for (float f = 0; f <= time; f += Time.deltaTime)
        {
            c.a = f / time;
            headText.color = c;
            yield return null;
        }
        c.a = 1;
        headText.color = c;
    }

    private IEnumerator FadeOutMessageCoR(float time)
    {
        var c = headText.color;
        for (float f = 0; f <= time; f += Time.deltaTime)
        {
            c.a = 1 - f / time;
            headText.color = c;
            yield return null;
        }
        c.a = 0;
        headText.color = c;
    }
}
