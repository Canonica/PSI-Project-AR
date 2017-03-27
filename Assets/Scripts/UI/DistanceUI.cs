using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class DistanceUI : MonoBehaviour {

    PlayerHandler playerHandler;
    List<TextMeshProUGUI> listText;
    string meterColor = "<color=#f09885>m</color>";
    // Use this for initialization
    void Start ()
    {
        playerHandler = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHandler>();
        listText = GetComponentsInChildren<TextMeshProUGUI>().ToList();
        listText[0].text = 0 + meterColor;
        listText[1].text = playerHandler.distanceScript.maxDistance + meterColor;
    }
	
	// Update is called once per frame
	void Update () {
		if(ContextManager.instance.CompareContext(ContextManager.GameContext.Diving) || ContextManager.instance.CompareContext(ContextManager.GameContext.Ascent))
        {
            listText[0].text = (int)Mathf.Round(playerHandler.distanceScript.currentDistance) + meterColor;
        }
	}
}
