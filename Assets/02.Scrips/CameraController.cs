using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject cat;
    void Start()
    {
        cat = GameObject.Find("cat");
    }

    void Update()
    {
        //ī�޶� y�� �������θ� �����̵���
        Vector3 catPos = cat.transform.position;
        transform.position = new Vector3(transform.position.x, catPos.y, transform.position.z);
    }
}
