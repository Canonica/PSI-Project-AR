using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDistance : MonoBehaviour {
    public int maxDistance;

    Vector3 originalPos;
    public float currentDistance;

    private void Start()
    {
        originalPos = transform.position;
    }

    public void AddMaxDistance(int amount)
    {
        
        maxDistance += amount;
    }

    private void Update()
    {
        currentDistance = Vector3.Distance(originalPos, transform.position);
    }
}
