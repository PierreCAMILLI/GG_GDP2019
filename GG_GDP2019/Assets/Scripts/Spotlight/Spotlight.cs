using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spotlight : MonoBehaviour
{
    public int numberDetectedWaste = 0;
    public float timeDetectingWaste = 0.0f;
    public float thresholdTime = 1000.0f;

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
            timeDetectingWaste = 0;
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
