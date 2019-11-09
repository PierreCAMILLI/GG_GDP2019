using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{

    CapsuleCollider newCollider;

    public int numSegments = 128;

    void Start()
    {
        newCollider = GetComponentInParent<CapsuleCollider>();
    }

    public void Update()
    {
        LineRenderer lineRenderer = gameObject.GetComponent<LineRenderer>();
        Color c1 = new Color(0f, 0f, 0f, 255f);
        //lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
        lineRenderer.SetColors(c1, c1);
        lineRenderer.SetWidth(0.2f, 0.2f);
        lineRenderer.SetVertexCount(numSegments + 1);
        lineRenderer.useWorldSpace = false;

        float deltaTheta = (float)(2.0 * Mathf.PI) / numSegments;
        float theta = 0f;

        float radius = newCollider.radius;

        for (int i = 0; i < numSegments + 1; i++)
        {
            float x = radius * Mathf.Cos(theta);
            float y = radius * Mathf.Sin(theta);
            Vector3 pos = new Vector3(x, y, 2);
            lineRenderer.SetPosition(i, pos);
            theta += deltaTheta;
        }
    }
}
