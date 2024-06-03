using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    private EntityStats playerStats;
    public Slider hpBar;
    void Start()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<EntityStats>();
    }

    void Update()
    {
        PlayerHp();
    }

    void PlayerHp()
    {
        hpBar.maxValue = playerStats.maxHp;
        hpBar.value = playerStats.hp;
    }
}
