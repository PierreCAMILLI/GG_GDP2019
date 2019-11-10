using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private TransformGrouper _grouper;

    [SerializeField]
    private Bounds1D _fieldOfView;

    [SerializeField]
    private float _zoomLimiter;

    [SerializeField]
    private float distance;

    private Vector3 _direction;

    // Start is called before the first frame update
    void Start()
    {
        _direction = transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = _grouper.transform.position + (-_direction * distance);

        float greatestDistance = _grouper.Bounds.size.x / 2f;
        float newZoom = Mathf.Lerp(_fieldOfView.Min, _fieldOfView.Max, greatestDistance / _zoomLimiter);
        Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, newZoom, 2 * Time.deltaTime);
    }


}
