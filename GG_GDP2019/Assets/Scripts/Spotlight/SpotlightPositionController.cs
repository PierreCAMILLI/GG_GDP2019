using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightPositionController : MonoBehaviour
{
    [SerializeField]
    public Transform[] positions;
    
    private Transform targetPosition;

    [SerializeField]
    public Spotlight spotlight;

    [SerializeField]
    public float speed;

    [SerializeField]
    public float beginTime;
    private bool began;
    // Start is called before the first frame update
    void Start()
    {
        
        began = false;
        NewPosition();
        Invoke("Begin", beginTime);
    }

    void Begin()
    {
        began = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (began)
        {
            Vector3 direction = targetPosition.position - transform.position;


            spotlight.MoveTowards(direction.XZ(), speed);

            if (direction.XZ().magnitude < 0.1f)
                NewPosition();
        }
    }

    public void NewPosition()
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
