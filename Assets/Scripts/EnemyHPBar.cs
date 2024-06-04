using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHPBar : MonoBehaviour
{
    private Slider hpSlider;
    private EntityStats es;

    void Start()
    {
        hpSlider = GetComponentInChildren<Slider>();
        es = GetComponentInParent<EntityStats>();
    }

    void Update()
    {
        hpSlider.maxValue = es.maxHp;
        hpSlider.value = es.hp;
    }
}
