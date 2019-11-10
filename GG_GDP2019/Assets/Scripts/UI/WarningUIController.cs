using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(WarningUI))]
public class WarningUIController : MonoBehaviour
{
    [System.Serializable]
    public struct BlinkFrequencyValue
    {
        [Range(0f, 1f)]
        public float rate;
        public float frequency;
    }

    [SerializeField]
    private BlinkFrequencyValue[] _values;

    private WarningUI _ui;

    // Start is called before the first frame update
    void Awake()
    {
        _ui = GetComponent<WarningUI>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(GameManager.Instance.GreaterDetectionRate);
        float frequency = _values.Last(bfv => GameManager.Instance.GreaterDetectionRate >= bfv.rate).frequency;
        _ui.Frequency = frequency; // _frequencies.Evaluate(GameManager.Instance.GreaterDetectionRate);
    }
}
