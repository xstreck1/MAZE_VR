using UnityEngine;
using UnityEngine.XR;

public class VRJoyMove : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f; // Speed of the movement
    [SerializeField] private XRNode inputSource; // The VR controller to use
    [SerializeField] private Transform headTransform;

    private Vector2 inputAxis; // Store the joystick input

    void LateUpdate()
    {
        // Get the device of the specified input source
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);

        // Get joystick input
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);

        // Create a Vector3 movement direction (assuming the joystick moves the player on the X and Z axes)
        var movement = new Vector3(inputAxis.x, 0.0f, inputAxis.y);

        var forward = headTransform.forward;
        forward.y = 0;
        var headForward = forward.normalized;
        
        // convert movement to the head's local space
        movement = Quaternion.LookRotation(headForward) * movement;
        
        // Move the GameObject
        transform.Translate(movement * speed * Time.deltaTime);
    }
}
