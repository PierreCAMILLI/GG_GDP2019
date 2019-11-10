using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacuumCone : MonoBehaviour
{
    MeshCollider cone_collider;
    Transform transform_hero;
    Rigidbody rigidbody;

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
            Vector3 vectForce = (transform_hero.position - other.transform.position).X0Z() / 2f;
            rigidbody.AddForce(vectForce, ForceMode.Force);
            

        }
    }
}
