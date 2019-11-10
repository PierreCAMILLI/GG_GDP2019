using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightPositionController : MonoBehaviour
{
    [SerializeField]
    private Transform[] positions;
    
    private Transform targetPosition;

    [SerializeField]
    private Spotlight spotlight;

    [SerializeField]
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        NewPosition(); 
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = targetPosition.position - transform.position;


        spotlight.MoveTowards(direction.XZ(), speed);

        if (direction.XZ().magnitude < 0.1f)
            NewPosition();
    }

    void NewPosition()
    {
        targetPosition = positions[Random.Range(0, positions.Length)];

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        foreach (Transform position in positions) {
            Gizmos.DrawSphere(position.position, 1f);
        }
    }
}
