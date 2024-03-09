using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollow : MonoBehaviour
{
    public Transform playerPos;
    public Vector3 offset;
    private float cameraSpeed = 3f;
    void Start()
    {

    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, playerPos.position + offset, cameraSpeed * Time.deltaTime);
    }
}