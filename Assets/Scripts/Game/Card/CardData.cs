using UnityEngine;

[CreateAssetMenu(fileName = "CardData",menuName = "Charlles/Card Data")]
public class CardData : ScriptableObject
{
    public int TargetId;
    public string Title;
    [TextArea]
    public string Description;
    
    public Sprite Icon;
    public CardEffect UseEffect;
    public EffectNumber EffectPrefab;
    public EffectData EffectData;
}