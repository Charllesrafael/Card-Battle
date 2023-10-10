public class EffectHeal : CardEffect
{
    public override void Effect()
    {
        if(characterGameData != null){
            characterGameData.Life += (int)effectData.Amount;
            characterManager.UpdateLife();
            CreationEffect.Instance.CreateEffectNumber(effectPrefab, "+"+effectData.Amount, pointEffectNumber, effectData.Color);
        }
    }
    
    public override void SetTargetEffect(CharacterGameData _characterGameData, CardData _cardData, CharacterManager _characterManager)
    {
        characterGameData = _characterGameData;
        effectData = _cardData.EffectData;
        effectPrefab = _cardData.EffectPrefab;
        characterManager = _characterManager;
        pointEffectNumber = _characterManager.pointLifeNumber;
        characterManager.AddListenerAttack(TickEffect);
    }
}
