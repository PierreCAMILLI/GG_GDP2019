using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformGrouperHeroes : TransformGrouper
{
    [SerializeField]
    private Transform heroes;

    // Start is called before the first frame update
    void Awake()
    {
        UpdateBounds();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateBounds();
        transform.position = _bounds.center;
    }

    private void UpdateBounds()
    {
        _bounds = new Bounds();
        if (heroes.childCount > 0)
        {
            _bounds = new Bounds(heroes.GetChild(0).position, Vector3.zero);
            for (int i = 1; i < heroes.childCount; ++i)
            {
                if(heroes.GetChild(i).gameObject.activeInHierarchy)
                    _bounds.Encapsulate(heroes.GetChild(i).position);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        UpdateBounds();

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(_bounds.center, 0.1f);
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(_bounds.center, _bounds.size);
    }
}
