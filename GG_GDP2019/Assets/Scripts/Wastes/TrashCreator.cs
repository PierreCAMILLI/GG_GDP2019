using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCreator : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> trashes;

    public void CreateTrash(Vector3 position) {
        GameObject modele = trashes[Random.Range(0, trashes.Count)];
        GameObject instance = Instantiate(modele);
        instance.transform.rotation = Random.rotationUniform;

        instance.transform.parent = this.transform;
        instance.transform.localPosition = position;
    }

    public bool CreateTrashOutsideColliders(Vector3 position, List<Collider> colliders)
    {
        bool added = true;
        foreach (Collider collider in colliders)
        {
            if (collider.ClosestPoint(position + this.transform.position) == position + this.transform.position)
                added = false;
        }
        if(added)
            CreateTrash(position);
        return added;
    }
}
