using UnityEngine;

public class MouseVertical : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 100.0f; // Sensitivity of the mouse
    [SerializeField] private  float xRotation; // Store the calculated X-axis rotation

    void Start()
    {
        // Lock the cursor to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Get vertical mouse input
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Calculate rotation around the X-axis
        xRotation -= mouseY; // Subtract mouseY to invert the vertical mouse movement
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Clamp the rotation to -90 and 90 degrees

        // Apply the rotation around the X-axis
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}