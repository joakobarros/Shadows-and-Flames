using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPointer : MonoBehaviour
{

    public Transform orientation;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        orientation.forward = transform.forward;
    }
}
