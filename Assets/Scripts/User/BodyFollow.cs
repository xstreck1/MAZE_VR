using UnityEngine;

public class BodyFollow : MonoBehaviour
{
    [SerializeField] Transform headTransform;
    
    void LateUpdate()
    {
        // Copy x and z position from head
        var headPos = headTransform.position;
        var selfPos = transform;
        selfPos.position = new Vector3(headPos.x, selfPos.position.y, headPos.z);
    }
}
