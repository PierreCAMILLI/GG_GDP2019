﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    CapsuleCollider newCollider;

    public int numSegments = 128;

    private SpotlightController spotlightcontrol;

    void Start()
    {
        newCollider = GetComponentInParent<CapsuleCollider>();
        spotlightcontrol = GetComponentInParent<SpotlightController>();

    }

    public void Update()
    {
        LineRenderer lineRenderer = gameObject.GetComponent<LineRenderer>();

        Color color = Color.Lerp(Color.white, Color.red, spotlightcontrol.timeDetectingWaste / spotlightcontrol.thresholdTime);
       
        lineRenderer.SetColors(color, color);
        lineRenderer.SetWidth(0.2f, 0.2f);
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
