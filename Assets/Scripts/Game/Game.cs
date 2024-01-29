using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private UserRoot userRoot;

    private void Awake()
    {
        userRoot.OnExitHit += ExitHit;
    }

    private void ExitHit()
    {
        userRoot.DisplayMessage("YOU WIN!");
        userRoot.SetWin();
    }

    private void Start()
    {
        userRoot.DisplayMessage("FIND THE EXIT");
    }
}
