using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    private float smoothSpeed = 0.125f;
    private Vector3 offset = new Vector3(0f, 0f, -1f);

    void FixedUpdate () 
    {
        Vector3 desiredPos = target.position + offset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);
        transform.position = smoothedPos;
    }
}
