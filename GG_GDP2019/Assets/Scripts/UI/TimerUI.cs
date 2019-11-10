using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    [SerializeField]
    private Text _timer;

    [Header("Last Seconds")]
    [SerializeField]
    private float _lastSeconds;

    [SerializeField]
    private Color _lastSecondsColor;

    private Color _baseColor;

    // Start is called before the first frame update
    void Start()
    {
        _baseColor = _timer.color;
    }

    // Update is called once per frame
    void Update()
    {
        int time = Mathf.CeilToInt(GameManager.Instance.timer);
        UpdateText(time);
        UpdateColor(time);
    }

    void UpdateText(int time)
    {
        string timeText = time.ToString();
        if (timeText.Length < 2)
        {
            timeText = '0' + timeText;
        }
        _timer.text = timeText;
    }

    void UpdateColor(int time)
    {
        _timer.color = (time <= _lastSeconds ? _lastSecondsColor : _baseColor);
    }
}
