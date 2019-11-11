using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    CapsuleCollider newCollider;

    public int numSegments = 128;

    private Spotlight spotlight;

    [SerializeField]
    private float width;

    void Start()
    {
        newCollider = GetComponentInParent<CapsuleCollider>();
        spotlight = GetComponentInParent<Spotlight>();

    }

    public void Update()
    {
        LineRenderer lineRenderer = gameObject.GetComponent<LineRenderer>();

        Color color = Color.Lerp(Color.white, Color.red, spotlight.timeDetectingWaste / spotlight.thresholdTime);
       
        lineRenderer.SetColors(color, color);
        lineRenderer.SetWidth(width, width);
        lineRenderer.SetVertexCount(numSegments + 1);
        lineRenderer.useWorldSpace = false;

        float deltaTheta = (float)(2.0 * Mathf.PI) / numSegments;
        float theta = 0f;

        float radius = newCollider.radius;

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
