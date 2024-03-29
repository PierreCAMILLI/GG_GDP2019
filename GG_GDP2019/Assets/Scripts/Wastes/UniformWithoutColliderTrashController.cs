﻿using System.Collections;
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
    public float trashDensity;


    [SerializeField]
    private Transform obstacles;

    [SerializeField]
    private Transform spotlights;
    // Start is called before the first frame update
    public void CreateTrashes()
    {
        List<Collider> colliders = new List<Collider>();
        foreach(Transform child in obstacles)
            colliders.AddRange(child.GetComponentsInChildren<Collider>());
        foreach(Transform child in spotlights)
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
