using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

[RequireComponent(typeof(AccelerometerInput))]
[RequireComponent(typeof(PlayerLife))]
[RequireComponent(typeof(PlayerMoney))]
[RequireComponent(typeof(PlayerDistance))]
public class PlayerHandler : MonoBehaviour {
    
    public AccelerometerInput accelerometerInput;
    public PlayerLife lifeScript;
    public PlayerMoney moneyScript;
    public PlayerDistance distanceScript;
    public PlayerShoot playerShoot;

    public List<Fish> fishCaughtList = new List<Fish>();

    // Use this for initialization
    void Awake ()
    {
        accelerometerInput = GetComponent<AccelerometerInput>();
        lifeScript = GetComponent<PlayerLife>();
        moneyScript = GetComponent<PlayerMoney>();
        distanceScript = GetComponent<PlayerDistance>();
        playerShoot = GetComponent<PlayerShoot>();
    }

}
