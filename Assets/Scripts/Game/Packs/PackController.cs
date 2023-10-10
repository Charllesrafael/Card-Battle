using UnityEngine;

public class PackController : MonoBehaviour
{
    [SerializeField] private PackData packData;
    [SerializeField] private PackUI packUI;

    void Start()
    {
        packUI.SetTitle(packData.TitlePack);
    }

    public void SetPack(PackData _packData)
    {
        packData = _packData;
        packUI.SetTitle(packData.TitlePack);
    }

    public CardData GetRandomCardData()
    {
        return packData.GetRandomCardData();
    }
}
