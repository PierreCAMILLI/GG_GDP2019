using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spotlight : MonoBehaviour
{
    private static List<Spotlight> _spotlights;
    public static IList<Spotlight> Spotlights
    {
        get { return _spotlights; }
    }

    public int numberDetectedWaste = 0;
    public float timeDetectingWaste = 0.0f;
    public float thresholdTime = 1000.0f;

    public float DetectionRate
    {
        get { return timeDetectingWaste / thresholdTime; }
    }

    private void Awake()
    {
        if (_spotlights == null)
        {
            _spotlights = new List<Spotlight>();
        }
        _spotlights.Add(this);
    }

    private void OnDestroy()
    {
        _spotlights.Remove(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (numberDetectedWaste != 0)
        {
            timeDetectingWaste += Time.deltaTime * numberDetectedWaste;
        }
        else
        {
            timeDetectingWaste -= Time.deltaTime * thresholdTime;
            timeDetectingWaste = Mathf.Max(0, timeDetectingWaste);
        }

        if (timeDetectingWaste > thresholdTime)
        {
            GameManager.Instance.GameOver();
        }
    }

    //Move is called in the update method of SpotlightController 
    public void Move(Vector2 translation)
    {
        transform.Translate(translation.XZ());
    }

    public void MoveTowards(Vector2 direction, float speed) {
        Vector2 translation = direction.magnitude > 1f ? direction.normalized : direction;
        transform.Translate(translation.XZ() * speed * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Trash>() != null)
        {
            numberDetectedWaste++;
        }
    }   

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Trash>() != null)
        {
            numberDetectedWaste--;
        }
    }
}
