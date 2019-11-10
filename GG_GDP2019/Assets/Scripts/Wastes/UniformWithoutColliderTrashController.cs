using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UniformWithoutColliderTrashController : MonoBehaviour
{
    [SerializeField]
    private TrashCreator trashCreator;
    [SerializeField]
    private Bounds area;
    [SerializeField]
    private float trashDensity;

    [SerializeField]
    private List<Collider> colliders;

    [SerializeField]
    private Transform obstacles;
    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform child in obstacles)
            colliders.AddRange(child.GetComponentsInChildren<Collider>());

        int trashCount = (int) (4 * area.extents.x * area.extents.z * trashDensity);

        for(int i = 0; i < trashCount; i ++)
        {
            while(!trashCreator.CreateTrashOutsideColliders(new Vector3(Random.Range(-area.extents.x, area.extents.x),
                                                   Random.Range(0, area.extents.y),
                                                   Random.Range(-area.extents.z, area.extents.z)), colliders));
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
