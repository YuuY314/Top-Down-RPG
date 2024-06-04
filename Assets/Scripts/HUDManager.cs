using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public static HUDManager Instance { get; private set; }

    void Awake()
    {
        if(Instance != null && Instance != this){
            Destroy(this);
        } else {
            Instance = this;
        }
    }

    private EntityStats playerStats;
    public Slider hpBar;
    public Slider expBar;
    public GameObject levelUpScreen;
    public Text[] statsInfo;
    public GameObject damagePopUp;

    void Start()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<EntityStats>();
    }

    void Update()
    {
        PlayerHUD();
    }

    void PlayerHUD()
    {
        hpBar.maxValue = playerStats.maxHp;
        hpBar.value = playerStats.hp;

        expBar.maxValue = playerStats.level * 100;
        expBar.value = playerStats.exp;
    }

    public void SelectStat(string stat)
    {
        if(stat == "hp"){
            playerStats.maxHp += 5;
            playerStats.hp += 5;
        }

        if(stat == "attackDamage"){
            playerStats.bonusAttackDamage += 5;
        }

        if(stat == "attackSpeed"){
            playerStats.bonusAttackSpeed += 2.5f;
        }

        if(stat == "moveSpeed"){
            playerStats.baseSpeed += 200;
        }

        levelUpScreen.SetActive(false);
    }

    public void SetupLevelUp()
    {
        levelUpScreen.SetActive(true);

        statsInfo[0].text = playerStats.maxHp.ToString();
        statsInfo[1].text = playerStats.bonusAttackDamage.ToString();
        statsInfo[2].text = playerStats.bonusAttackSpeed.ToString();
        statsInfo[3].text = (Mathf.CeilToInt(playerStats.baseSpeed / 1000)).ToString();
    }
}
