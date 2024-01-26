using UnityEngine;

public class MouseHorizontal : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 100.0f; // Sensitivity of the mouse
    [SerializeField] private float xRotation; // Store the calculated rotation

    void Start()
    {
        // Lock the cursor to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

        // Rotate the GameObject around the Y axis
        transform.Rotate(Vector3.up * mouseX);
    }
}