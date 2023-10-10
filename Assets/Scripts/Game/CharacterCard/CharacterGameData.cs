
using System;
using UnityEngine;

[System.Serializable]
public class CharacterGameData
{
    public Character MyCharacter;
    private int currentLife;
    public float CurrentTickAttack;
    private float damage;
    public int TargetId;

    public int Life { 
        get => currentLife;
        set {
            currentLife = value;
        }
    }

    public float Damage { 
        get => damage;
        set {
            damage = value; 
        } 
    }
}
