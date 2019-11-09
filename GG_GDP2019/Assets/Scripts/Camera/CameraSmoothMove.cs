using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSmoothMove : MonoBehaviour
{
    [SerializeField]
    private Transform _target;

    [SerializeField]
    [Tooltip("Time for the transform to reach its target.")]
    [Range(0f, 1f)]
    private float _smoothTime;

    private Vector3 _velocity;

    void FixedUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, _target.position, ref _velocity, _smoothTime, Mathf.Infinity, Time.fixedDeltaTime);
    }
}
