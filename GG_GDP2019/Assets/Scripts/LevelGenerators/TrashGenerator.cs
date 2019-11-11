using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashGenerator : Generator
{
    [SerializeField]
    private UniformWithoutColliderTrashController trashController;

    public override float Generate(float difficulty)
    {
        trashController.trashDensity = 1f;
        trashController.CreateTrashes();
        return 0f;
    }
}
