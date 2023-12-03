using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float cameraSpeed;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * cameraSpeed * Time.deltaTime);
    }
}
