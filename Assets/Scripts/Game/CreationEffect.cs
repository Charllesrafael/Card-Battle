using UnityEngine;

public class CreationEffect : MonoBehaviour
{
    public static CreationEffect Instance;

    [SerializeField] private EffectNumber effectNumberPrefab;
    [SerializeField] private EffectNumber[] effectLifePrefab;
    

    void Awake()
    {
        Instance = this;
    }
    
    public void CreateEffectNumber(EffectNumber _effectrefab, string _number, Transform _parent, Color color)
    {
        EffectNumber effectNumber = Instantiate(_effectrefab, _parent);        
        effectNumber.SetNumber(_number, color);
    }

    public void CreateEffectNumber(string _number, Transform _parent, Color color)
    {
        EffectNumber effectNumber = Instantiate(effectNumberPrefab, _parent);        
        effectNumber.SetNumber(_number, color);
    }

    public void CreateLifeNumber(string _number, Transform _parent, int target)
    {
        EffectNumber effectNumber = Instantiate(effectLifePrefab[target], _parent);
        effectNumber.SetNumber(_number, Color.red);
    }

    public void EffectCardDeath(CardData _cardData, int  _targetId)
    {
        CharacterManager _targetEffect = GameController.Instance.GetTargetDrop(_targetId);
        if(_cardData.UseEffect != null && _targetEffect != null && _targetEffect.pointEffect != null)
        {
            CardEffect cardEffect = Instantiate( _cardData.UseEffect, _targetEffect.pointEffect.position, _cardData.UseEffect.transform.rotation);
            cardEffect.transform.parent = _targetEffect.pointEffect;
            cardEffect.SetTargetEffect(_targetEffect.charGameData, _cardData, _targetEffect);
        }
    }
}
