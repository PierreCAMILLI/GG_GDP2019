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
        instance.transform.position = position;
        instance.transform.rotation = Random.rotationUniform;

        instance.transform.parent = this.transform;
    }
}
