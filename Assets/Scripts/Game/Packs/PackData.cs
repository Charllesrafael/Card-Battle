using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PackData", menuName = "Charlles/Pack Data")]
public class PackData : ScriptableObject
{
    public string TitlePack;
    public List<CardData> Cards;

    public CardData GetRandomCardData()
    {
        return Cards[Random.Range(0, Cards.Count)];
    }
}
