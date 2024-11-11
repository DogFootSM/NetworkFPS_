using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Target { get; set; }
    [SerializeField] private Vector3 _cameraDefaultPosition;

    private void LateUpdate()
    {
        CameraTransformSet();
    }

    private void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * 50f, Color.red);
    }

    private void CameraTransformSet()
    {
        if (Target == null)
            return;

        transform.position = Target.position + Target.forward + _cameraDefaultPosition;
        transform.rotation = Target.rotation;
    }

    

}
