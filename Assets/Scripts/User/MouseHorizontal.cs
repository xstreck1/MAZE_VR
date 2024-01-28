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
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
    
    void LateUpdate()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

        // Rotate the GameObject around the Y axis
        if (Cursor.lockState == CursorLockMode.Locked)
            transform.Rotate(Vector3.up * mouseX);
    }
}