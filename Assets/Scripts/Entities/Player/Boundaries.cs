﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour {

    public bool isOnBoundaries;
    public float minX;
    public float maxX;
    private float width;
    private Vector3 pos;

    void Awake()
    {
        float camDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
        Vector2 bottomCorner = ContextManager.instance.cameraController.GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0, 0, camDistance));
        Vector2 topCorner = ContextManager.instance.cameraController.GetComponent<Camera>().ViewportToWorldPoint(new Vector3(1, 1, camDistance));
        if (GetComponent<Renderer>())
        {
            width = GetComponent<Renderer>().bounds.extents.x;
        }
        else if (GetComponent<BoxCollider>())
        {
            width = GetComponent<BoxCollider>().size.x;
        }
        
        minX = bottomCorner.x + width;
        maxX = topCorner.x - width;
    }

    void Update()
    {
        pos = transform.position;
        if (pos.x < minX)
        {
            pos.x = minX;
            isOnBoundaries = true;
        }
        else if (pos.x > maxX)
        {
            pos.x = maxX;
            isOnBoundaries = true;
        }
        else
        {
            isOnBoundaries = false;
        }
        transform.position = pos;
    }

}
