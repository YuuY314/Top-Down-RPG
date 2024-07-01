using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { get; private set; }

    void Awake()
    {
        if(Instance != null && Instance != this){
            Destroy(this);
        } else {
            Instance = this;
        }
    }

    private GameObject playerObject;
    private EntityStats playerStats;

    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        playerStats = playerObject.GetComponent<EntityStats>();
        LoadGame();
    }

    public void SaveGame()
    {
        //Player Position
        PlayerPrefs.SetFloat("positionX", playerObject.transform.position.x);
        PlayerPrefs.SetFloat("positionY", playerObject.transform.position.y);

        //Player Stats
        PlayerPrefs.SetFloat("maxHp", playerStats.maxHp);
        PlayerPrefs.SetFloat("hp", playerStats.hp);
        PlayerPrefs.SetFloat("baseSpeed", playerStats.baseSpeed);
        PlayerPrefs.SetInt("level", playerStats.level);
        PlayerPrefs.SetInt("exp", playerStats.exp);
        PlayerPrefs.SetFloat("bonusAttackDamage", playerStats.bonusAttackDamage);
        PlayerPrefs.SetFloat("bonusAttackSpeed", playerStats.bonusAttackSpeed);
        PlayerPrefs.SetInt("goldCoins", InventoryManager.Instance.goldCoins);

        //Options
        PlayerPrefs.SetFloat("audioVolume", OptionsManager.Instance.audioSlider.value);
    }

    void LoadGame()
    {
        //Player Position
        playerObject.transform.position = new Vector3(PlayerPrefs.GetFloat("positionX"), PlayerPrefs.GetFloat("positionY"), 0);
        Camera.main.transform.position = new Vector3(PlayerPrefs.GetFloat("positionX"), PlayerPrefs.GetFloat("positionY"), -10);
         if(playerObject.transform.position.x == 0 && playerObject.transform.position.y == 0){
            playerObject.transform.position = new Vector3(-16.98f, -21.58f, 0);
            Camera.main.transform.position = new Vector3(-16.98f, -21.58f, 0);
        }

        //Player Stats
        playerStats.maxHp = PlayerPrefs.GetFloat("maxHp");
        if(!PlayerPrefs.HasKey("maxHp")) { playerStats.maxHp = 20; }
        playerStats.hp = PlayerPrefs.GetFloat("hp");
        if(!PlayerPrefs.HasKey("hp")) { playerStats.hp = 20; }
        HUDManager.Instance.PlayerHUD();
        playerStats.baseSpeed = PlayerPrefs.GetFloat("baseSpeed");
        if(!PlayerPrefs.HasKey("baseSpeed")) { playerStats.baseSpeed = 1500; }
        playerStats.level = PlayerPrefs.GetInt("level");
        if(!PlayerPrefs.HasKey("level")) { playerStats.level = 1; }
        playerStats.exp = PlayerPrefs.GetInt("exp");
        playerStats.bonusAttackDamage = PlayerPrefs.GetFloat("bonusAttackDamage");
        playerStats.bonusAttackSpeed = PlayerPrefs.GetFloat("bonusAttackSpeed");
        InventoryManager.Instance.goldCoins = PlayerPrefs.GetInt("goldCoins");

        //Options
        OptionsManager.Instance.audioSlider.value = PlayerPrefs.GetFloat("audioVolume");
        if(OptionsManager.Instance.audioSlider.value == 0){ OptionsManager.Instance.audioSlider.value = 1; }
        OptionsManager.Instance.ApplyOptions();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
