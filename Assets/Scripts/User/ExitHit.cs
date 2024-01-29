using System;
using UnityEngine;

public class ExitHit : MonoBehaviour
{
    public event Action OnExitHit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Exit"))
        {
            OnExitHit?.Invoke();
        }
    }
}
