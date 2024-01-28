using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private UserRoot userRoot;

    private void Start()
    {
        userRoot.DisplayMessage("FIND THE EXIT");
    }

    private void Update()
    {
        
    }
}
