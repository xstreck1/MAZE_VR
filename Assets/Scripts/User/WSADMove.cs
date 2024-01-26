using UnityEngine;

public class WSADMove : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f; // Speed of the movement
    
    void LateUpdate()
    {
        // Get input from keyboard
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Create a Vector3 movement direction
        var movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Apply the movement to the Rigidbody
        transform.Translate(movement * speed * Time.deltaTime);
    }
}
