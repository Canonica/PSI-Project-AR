using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDistance : MonoBehaviour {
    public int currentDistance;
    public int maxDistance;

    public void AddMaxDistance(int amount)
    {
        maxDistance += amount;
    }
}
