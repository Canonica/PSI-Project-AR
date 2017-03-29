using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoney : MonoBehaviour {
    public int currentMoney;
    public int bonusMoney;

    public void AddMoney(int amount)
    {
        currentMoney += (amount+ bonusMoney);
    }

    public void SubStractMoney(int amount)
    {
        currentMoney -= amount;
        currentMoney = Mathf.Max(0, currentMoney);
    }

}
