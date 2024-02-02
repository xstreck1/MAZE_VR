using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private UserRoot userRoot;
    [SerializeField] private AudioSource soundEffects;
    [SerializeField] private AudioClip winSound;

    private void Awake()
    {
        userRoot.OnExitHit += ExitHit;
    }

    private void ExitHit()
    {
        userRoot.DisplayMessage("YOU WIN!\nREPEAT.");
        soundEffects.PlayOneShot(winSound);
        userRoot.SetWin();
    }

    private void Start()
    {
        userRoot.DisplayMessage("FIND THE EXIT");
    }
}
