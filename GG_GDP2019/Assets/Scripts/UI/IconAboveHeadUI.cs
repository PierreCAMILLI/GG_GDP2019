using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class IconAboveHeadUI : MonoBehaviour
{
    [SerializeField]
    private Transform _transform;
    public Transform Transform
    {
        get { return _transform; }
        set { _transform = value; }
    }

    [SerializeField]
    private Vector3 _offset;
    public Vector2 Offset
    {
        get { return _offset; }
        set { _offset = value; }
    }

    private RectTransform _rectTransform;
    private Image _image;

    // Start is called before the first frame update
    void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _image = GetComponent<Image>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (_transform != null)
        {
            _image.enabled = true;
            _rectTransform.position = _transform.position + _offset;
            _rectTransform.LookAt(Camera.main.transform.position);
        } else
        {
            _image.enabled = false;
        }
    }
}
