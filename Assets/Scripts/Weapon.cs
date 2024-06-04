using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon")]
public class Weapon : ScriptableObject
{
    public float weaponDamage;
    public float weaponSpeed;
    public float weaponLifeSpan;
    public float weaponRange;
    public Sprite weaponIcon;
    public string weaponName;
    public int weaponValue;
}
