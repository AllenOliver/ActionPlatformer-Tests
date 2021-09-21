using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon")]
public class Weapon : ScriptableObject
{
    public Sprite WeaponSprite;
    public int WeaponDamage;
    public string WeaponName;
}