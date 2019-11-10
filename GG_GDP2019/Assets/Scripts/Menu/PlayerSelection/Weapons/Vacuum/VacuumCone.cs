using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacuumCone : MonoBehaviour
{
    MeshCollider cone_collider;
    Transform transform_hero;
    Rigidbody rigidbody;

    [SerializeField]
    private float ForceConstant;

    // Start is called before the first frame update
    void Start()
    {
        cone_collider = GetComponent<MeshCollider>();
        transform_hero = transform.parent;
    }

    // Update is called once per frame
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<Trash>() != null )
        {

            rigidbody = other.GetComponent<Rigidbody>();
            Vector3 direction = (transform_hero.position - other.transform.position);
            float distance = direction.magnitude;
            Vector3 force = ForceConstant * direction.normalized;
            rigidbody.AddForce(force, ForceMode.Force);
            

        }
    }
}
