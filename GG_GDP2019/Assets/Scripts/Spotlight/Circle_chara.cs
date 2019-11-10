using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle_chara : MonoBehaviour
{
    public int numSegments = 128;
    public Color color;
    CharacterController newCollider;


    void Start()
    {
        newCollider = GetComponentInParent<CharacterController>();
    }

    public void Update()
    {
        LineRenderer lineRenderer = gameObject.GetComponent<LineRenderer>();       
        lineRenderer.SetColors(color, color);
        lineRenderer.SetWidth(0.1f, 0.1f);
        lineRenderer.SetVertexCount(numSegments + 1);
        lineRenderer.useWorldSpace = false;

        float deltaTheta = (float)(2.0 * Mathf.PI) / numSegments;
        float theta = 0f;

        float radius = 1.2f * newCollider.radius;

        for (int i = 0; i < numSegments + 1; i++)
        {
            float x = radius * Mathf.Cos(theta);
            float z = radius * Mathf.Sin(theta);
            Vector3 pos = new Vector3(x, 0, z);
            lineRenderer.SetPosition(i, pos);
            theta += deltaTheta;
        }

    }
}
