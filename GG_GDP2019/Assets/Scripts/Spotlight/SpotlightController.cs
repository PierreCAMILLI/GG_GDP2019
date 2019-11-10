using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightController : MonoBehaviour
{
    public float speed = 0.2f;
    Vector2Int direction = new Vector2Int(1, 1);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Spotlight spotlight = transform.GetComponent<Spotlight>();

        float thresholdX = 5; //length x
        float thresholdZ = 5; //length z

        // changes the direction to bounce off the walls
        if (transform.position.x >= thresholdX && direction[0] == 1)
        {
            direction[0] = -1;
        }
        else if (transform.position.x <= -thresholdX && direction[0] == -1)
        {
            direction[0] = 1;
        }

        if (transform.position.z >= thresholdZ && direction[1] == 1)
        {
            direction[1] = -1;
        }
        else if (transform.position.z <= -thresholdZ && direction[1] == -1)
        {
            direction[1] = 1;
        }
        Vector2 translation = (new Vector2(direction[0], direction[1])).normalized * speed;
        spotlight.Move(translation);


    }

}
