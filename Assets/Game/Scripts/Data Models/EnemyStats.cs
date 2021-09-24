using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats", menuName = "EnemyStats/ New Enemy Data")]
public class EnemyStats : ScriptableObject
{
    public string Name;
    public int MaxHealth;
    public ITEM_TYPE[] Droppables;
    public float DropRate;
}