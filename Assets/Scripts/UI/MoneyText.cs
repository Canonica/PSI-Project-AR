using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MoneyText : MonoBehaviour {
    PlayerHandler playerHandler;
    TextMeshProUGUI moneyText;
	// Use this for initialization
	void Start ()
    {
        moneyText = GetComponent<TextMeshProUGUI>();
        playerHandler = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHandler>();
    }
	
	// Update is called once per frame
	void Update () {
        if(moneyText.text != playerHandler.moneyScript.currentMoney.ToString())
        {
            moneyText.text = playerHandler.moneyScript.currentMoney.ToString();
        }
    }
}
