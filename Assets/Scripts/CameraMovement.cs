using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public float xOffset = 0f;

    public float minX = -10f;
    public float maxX = 10f;

    void LateUpdate()
    {
        if (target != null)
        {
            float desiredX = target.position.x + xOffset;
            float smoothedX = Mathf.Lerp(transform.position.x, desiredX, smoothSpeed);
            float clampedX = Mathf.Clamp(smoothedX, minX, maxX);

            transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
        }
    }
}
