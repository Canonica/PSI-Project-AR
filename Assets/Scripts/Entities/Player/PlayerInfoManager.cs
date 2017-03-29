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
    public int moneyBonus;
    public float fireRate;
    public int weaponDamage;

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


    void Start()
    {
        LoadPlayerInfo();
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

        if (PlayerPrefs.HasKey("moneyBonus"))
        {
            moneyBonus = PlayerPrefs.GetInt("moneyBonus");
        }
        else
        {
            moneyBonus = 0;
        }

        if (PlayerPrefs.HasKey("fireRate"))
        {
            fireRate = PlayerPrefs.GetFloat("fireRate");
        }
        else
        {
            fireRate = 0.5f;
        }

        if (PlayerPrefs.HasKey("weaponDamage"))
        {
            weaponDamage = PlayerPrefs.GetInt("weaponDamage");
        }
        else
        {
            weaponDamage = 1;
        }
    }

    void SavePlayerInfo()
    {
        if(playerHandler != null)
        {
            PlayerPrefs.SetInt("currentMoney", playerHandler.moneyScript.currentMoney);
            PlayerPrefs.SetInt("maxLife", playerHandler.lifeScript.maxLife);
            PlayerPrefs.SetInt("maxDistance", playerHandler.distanceScript.maxDistance);
            PlayerPrefs.SetInt("moneyBonus", playerHandler.moneyScript.bonusMoney);
            PlayerPrefs.SetFloat("fireRate", playerHandler.playerShoot.fireRate);
            PlayerPrefs.SetInt("weaponDamage", playerHandler.playerShoot.damage);
        }
        else
        {
            PlayerPrefs.SetInt("currentMoney", currentMoney);
            PlayerPrefs.SetInt("maxLife", maxLife);
            PlayerPrefs.SetInt("maxDistance", maxDistance);
            PlayerPrefs.SetInt("moneyBonus", moneyBonus);
            PlayerPrefs.SetFloat("fireRate", fireRate);
            PlayerPrefs.SetInt("weaponDamage", weaponDamage);
        }
        
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
        playerHandler = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHandler>();

        if(playerHandler != null)
        {
            if (playerHandler.lifeScript.maxLife != maxLife)
            {
                playerHandler.lifeScript.maxLife = maxLife;
            }

            if (playerHandler.moneyScript.currentMoney != currentMoney)
            {
                playerHandler.moneyScript.currentMoney = currentMoney;
            }

            if (playerHandler.moneyScript.bonusMoney != moneyBonus)
            {
                playerHandler.moneyScript.bonusMoney = moneyBonus;
            }

            if (playerHandler.playerShoot.fireRate != fireRate)
            {
                playerHandler.playerShoot.fireRate = fireRate;
            }

            if (playerHandler.playerShoot.damage != weaponDamage)
            {
                playerHandler.playerShoot.damage = weaponDamage;
            }
        }
    }

    public void EndGameInfo()
    {
        currentMoney = playerHandler.moneyScript.currentMoney;
    }
}
