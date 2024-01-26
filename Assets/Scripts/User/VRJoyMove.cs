using UnityEngine;
using UnityEngine.XR;

public class VRJoyMove : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f; // Speed of the movement
    [SerializeField] private XRNode inputSource; // The VR controller to use

    private Vector2 inputAxis; // Store the joystick input

    void LateUpdate()
    {
        // Get the device of the specified input source
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);

        // Get joystick input
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);

        // Create a Vector3 movement direction (assuming the joystick moves the player on the X and Z axes)
        Vector3 movement = new Vector3(inputAxis.x, 0.0f, inputAxis.y);

        // Move the GameObject
        transform.Translate(movement * speed * Time.deltaTime);
    }
}
