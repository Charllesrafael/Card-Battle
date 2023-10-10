using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttackController : MonoBehaviour
{
    [SerializeField] private Animator characterAnimator;


    public void Attack(enumAttackType _attackType)
    {

    }
}




public enum enumAttackType
{
    MELEE,
    CAST
}
