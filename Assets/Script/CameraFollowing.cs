using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{

    private float targetXPosition = 20f;

    private Vector3 offset = new Vector3(0f, -0.5f, -10f);
    private float smoothTime = 0.125f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform target;
   
    void Update()
    {

        if (target.position.x <= targetXPosition)
        {
            Vector3 targetPosition = target.position + offset + new Vector3(3f, 0, 0);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        }
  
    }
}
