using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour {
    public int price;
    public bool isBought;
    public string description;

    public enum UpgradeType
    {
        Weapon,
        Reel,
        MoreMoney,
        Shield
    }

    public UpgradeType upgradeType;

    public virtual void Effect()
    {

    }
}
