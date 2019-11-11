using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarningUI : MonoBehaviour
{
    [SerializeField]
    private Image _image;

    [SerializeField]
    private float _blinkingFrequency;
    public float Frequency
    {
        get { return _blinkingFrequency; }
        set { _blinkingFrequency = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_blinkingFrequency <= 0f)
        {
            _image.gameObject.SetActive(false);
        } else
        {
            float time = 1f / _blinkingFrequency;
            float t = Mathf.Repeat(Time.time, time * 2f);
            _image.gameObject.SetActive(t < time);
        }
    }
}
