using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    public float cloudSpeed;
    public float cloudDirection;
    Vector3 cloudPos;
    void Start()
    {
        cloudPos = transform.position;
    }

    void Update()
    {
        transform.Translate(cloudDirection * cloudSpeed * Time.deltaTime, 0, 0);
        if (transform.position.x <= cloudPos.x - 1.0f)
        {
            cloudDirection = 1.0f;
        }
        else if (transform.position.x >= cloudPos.x + 1.0f)
        {
            cloudDirection = -1.0f;
        }
    }
}
