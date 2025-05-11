using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform ball; 
    float smoothSpeed = 5f;  // Camera  speed
    float heightOffset = 5f; // Distance  ball

    private Vector3 initialOffset;

    void Start()
    {
        if (ball != null)
        {
            initialOffset = transform.position - ball.position;
        }
    }

    void LateUpdate()
    {
        if (ball == null) return;

        Vector3 targetPosition = new Vector3(transform.position.x, ball.position.y + heightOffset, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
    }
}
