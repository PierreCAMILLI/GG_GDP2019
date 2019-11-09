using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformGrouper : MonoBehaviour
{
    [SerializeField]
    private List<Transform> _transforms;

    private Bounds _bounds;
    public Bounds Bounds
    {
        get { return _bounds; }
    }

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

        if (_transforms.Count > 0)
        {
            _bounds = new Bounds(_transforms[0].position, Vector3.zero);
            for (int i = 1; i < _transforms.Count; ++i)
            {
                _bounds.Encapsulate(_transforms[i].position);
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
