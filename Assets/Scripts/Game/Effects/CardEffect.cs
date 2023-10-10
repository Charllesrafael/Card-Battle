using UnityEngine;

public abstract class CardEffect : MonoBehaviour
{
    internal CharacterManager characterManager;
    internal CharacterGameData characterGameData;
    internal EffectData effectData;
    internal EffectNumber effectPrefab;
    internal Transform pointEffectNumber;
    

    private void Start() {
        Effect();
    }
    
    public virtual void SetTargetEffect(CharacterGameData _characterGameData, CardData _cardData, CharacterManager _characterManager)
    {
        characterGameData = _characterGameData;
        effectData = _cardData.EffectData;
        effectPrefab = _cardData.EffectPrefab;
        characterManager = _characterManager;
        pointEffectNumber = _characterManager.pointEffectNumber;
        characterManager.AddListenerAttack(TickEffect);
    }

    public virtual void Effect()
    {
    }

    public virtual void TickEffect(int _damage)
    {
    }

    public void OnDestroy()
    {
        if(characterManager != null)
            characterManager.RemoveListenerAttack(TickEffect);
    }
}
