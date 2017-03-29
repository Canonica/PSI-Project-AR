using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeHandler : MonoBehaviour {
    public List<Upgrade> upgradeList;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void ExecuteEffect()
    {
        foreach(Upgrade upgrade in upgradeList)
        {
            upgrade.Effect();
        }
    }
}
