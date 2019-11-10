using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniformTrashController : MonoBehaviour
{
    [SerializeField]
    private TrashCreator trashCreator;
    [SerializeField]
    private Bounds area;
    [SerializeField]
    private float trashDensity;
    // Start is called before the first frame update
    void Start()
    {
        int trashCount = (int) (4 * area.extents.x * area.extents.y * trashDensity);

        for(int i = 0; i < trashCount; i ++)
        {

            trashCreator.CreateTrash(new Vector3(Random.Range(-area.extents.x, area.extents.x),
                                                   Random.Range(0, area.extents.y),
                                                   Random.Range(-area.extents.z, area.extents.z)));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
