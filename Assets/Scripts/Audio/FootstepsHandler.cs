using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FootstepsHandler : MonoBehaviour
{
    public AudioSource footstepSource; // Assign in the inspector
    public List<AudioClip> footsteps; // Populate this list in the inspector with your footstep sounds
    private bool isMoving ;
    private float targetVolume = 1f; // Target volume for AudioSource when fully faded in

    private Vector3 lastPosition;
    private float minDelta = .1f;
    
    [SerializeField] private float delay = 0.3f;
    private float timer;
    private int sound;

    private void Start()
    {
        lastPosition = transform.position;
        footstepSource.volume = 0f;
    }

    void Update()
    {
        // Check if the object is moving
        if (IsObjectMoving()) // You'll need to implement this function
        {
            if (!isMoving)
            {
                isMoving = true;
                StartCoroutine(FadeSound(1)); // Fade in
            }
        }
        else
        {
            if (isMoving)
            {
                isMoving = false;
                StartCoroutine(FadeSound(0)); // Fade out
            }
        }
        if (!footstepSource.isPlaying)
        {
            timer += Time.deltaTime;
            if (timer > delay)
            {
                PlayFootstepSound();
                timer = 0f;
            }
        }
    }

    IEnumerator FadeSound(int direction)
    {
        float startVolume = footstepSource.volume;

        float fadeTime = 0.1f;
        float startTime = Time.time;

        while (Time.time < startTime + fadeTime)
        {
            footstepSource.volume = Mathf.Lerp(startVolume, direction * targetVolume, (Time.time - startTime) / fadeTime);
            yield return null;
        }

        footstepSource.volume = direction * targetVolume;
    }

    void PlayFootstepSound()
    {
        if (footsteps.Count > 1)
        {
            sound = (sound + 1) % 2;
            footstepSource.clip = footsteps[sound];
            footstepSource.Play();
        }
    }

    // Implement this function based on your object's movement logic
    bool IsObjectMoving()
    {
        var nowPosition = transform.position;
        bool isMoving = Vector3.Distance(lastPosition, nowPosition) > minDelta * Time.deltaTime;
        lastPosition = nowPosition;
        return isMoving;
    }
}
