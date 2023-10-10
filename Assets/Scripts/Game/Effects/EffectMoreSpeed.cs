using System.Collections;
using UnityEngine;

public class EffectMoreSpeed : CardEffect
{
    [SerializeField] private int effectDuration = 1;
    private float _addSpeed;

    public override void Effect()
    {
        if(characterGameData != null)
        {
            _addSpeed = characterGameData.CurrentTickAttack * (0.01f * effectData.Amount);
            characterGameData.CurrentTickAttack -= _addSpeed;
            CreationEffect.Instance.CreateEffectNumber(effectPrefab, "+"+effectData.Amount+"%", pointEffectNumber, effectData.Color);
        }
    }

    public override void TickEffect(int _damage)
    {
        effectDuration--;
        if(effectDuration == 0)
        {
            if(characterGameData != null)
                characterGameData.CurrentTickAttack += _addSpeed;
            Destroy(gameObject);
        }
    }
}
