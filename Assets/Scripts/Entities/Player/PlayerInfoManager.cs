using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerInfoManager : MonoBehaviour {
    public static PlayerInfoManager instance;
    public PlayerHandler playerHandler;


    public int currentMoney;
    public int maxLife;
    public int maxDistance;

    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        
    }

    void OnApplicationQuit()
    {
        SavePlayerInfo();
    }

    void LoadPlayerInfo()
    {
        if (PlayerPrefs.HasKey("currentMoney"))
        {
            currentMoney = PlayerPrefs.GetInt("currentMoney");
        }
        else
        {
            currentMoney = 0;
        }

        if (PlayerPrefs.HasKey("maxLife"))
        {
            maxLife = PlayerPrefs.GetInt("maxLife");
        }
        else
        {
            maxLife = 1;
        }

        if (PlayerPrefs.HasKey("maxDistance"))
        {
            maxDistance = PlayerPrefs.GetInt("maxDistance");
        }
        else
        {
            maxDistance = 50;
        }
    }

    void SavePlayerInfo()
    {
        PlayerPrefs.SetInt("currentMoney", playerHandler.moneyScript.currentMoney);
        PlayerPrefs.SetInt("maxLife", playerHandler.lifeScript.maxLife);
        PlayerPrefs.SetInt("maxDistance", playerHandler.distanceScript.maxDistance);
        PlayerPrefs.Save();
    }

    void OnEnable()
    {
        //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled.
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 1)
        {
            UpdatePlayerInfo();
        }
    }

    void UpdatePlayerInfo()
    {
        if (!playerHandler)
        {
            playerHandler = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHandler>();
        }

        if(playerHandler.lifeScript.maxLife != maxLife)
        {
            playerHandler.lifeScript.maxLife = maxLife;
        }

        if (playerHandler.moneyScript.currentMoney != currentMoney)
        {
            playerHandler.moneyScript.currentMoney = currentMoney;
        }

    }
}
