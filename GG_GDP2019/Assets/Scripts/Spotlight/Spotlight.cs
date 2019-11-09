using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spotlight : MonoBehaviour
{
    public int numberDetectedWaste = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Move is called in the update method of SpotlightController 
    public void Move(float dx, float dz, float speed, Vector2Int direction)
    {
        float newdx = direction[0] * dx * speed * Time.deltaTime;
        float newdz = direction[1] * dz * speed * Time.deltaTime;
        transform.Translate(new Vector3(newdx, 0, newdz));
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
