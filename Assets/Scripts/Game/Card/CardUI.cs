using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private Image icone;
    [SerializeField] private Button cardButton;


    public virtual void Initialize(CardData cardData)
    {
        title.text = cardData.Title;
        description.text = cardData.Description;
        icone.sprite = cardData.Icon;
    }

    public void Active()
    {
        canvasGroup.blocksRaycasts = true;
    }

    public void DropUI()
    {
        cardButton.interactable = false;
    }
}
