using System;
using System.Collections;
using UnityEngine;

public class EffectMoreDamage : CardEffect
{
    [SerializeField] private int effectDuration = 1;
    private float _addDamage;

    public override void Effect()
    {
        if(characterGameData != null)
        {
            _addDamage = characterGameData.Damage * (0.01f * effectData.Amount);
            characterGameData.Damage += _addDamage;
            characterManager.UpdateDamage();
            CreationEffect.Instance.CreateEffectNumber(effectPrefab, "+"+effectData.Amount+"%", pointEffectNumber, effectData.Color);
        }
    }
    

    public override void TickEffect(int _damage)
    {
        effectDuration--;
        if(effectDuration == 0)
        {
            if(characterGameData != null){
                characterGameData.Damage -= _addDamage;
                characterManager.UpdateDamage();
            }

            Destroy(gameObject);
        }
    }
}
