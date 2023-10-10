using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckManager : MonoBehaviour
{
    public static DeckManager Instance;

    [SerializeField] internal float speedDrop;
    [SerializeField] private float speedDistribution;
    [SerializeField] private float delayBetweenCards;

    [Space]
    [SerializeField] private int numCards;
    [SerializeField] private int maxCards;

    [SerializeField] private PackController pack;
    [SerializeField] private CardController prefabCard;
    [SerializeField] private RectTransform canvas;
    [SerializeField] private RectTransform cardParent;
    [SerializeField] private RectTransform packParent;

    [Space]
    [SerializeField] private CanvasGroup canvasGroupCards;
    [SerializeField] private ContentSizeFitter contentSizeFitter;
    [SerializeField] private HorizontalLayoutGroup horizontalLayoutGroup;

    private int _cardCount = 0;
    private bool _picking;
    private Queue<CardController> _cardsQueue;
    private Dictionary<Transform, Coroutine> _coroutineCardsMove;

    private void Awake()
    {
        Instance = this;
        _cardsQueue = new Queue<CardController>();
        _coroutineCardsMove = new Dictionary<Transform, Coroutine>();
    }

    public void DropCards()
    {
        StartCoroutine(IDropCards());
    }

    public IEnumerator IDropCards()
    {
        yield return new WaitForEndOfFrame();

        for (int i = 0; i < numCards; i++)
        {
            PickUpCard();
            yield return new WaitForSeconds(delayBetweenCards);
        }
    }

    public void PickUpCard()
    {
        if (_cardCount < maxCards && !_picking)
        {
            _picking = true;
            _cardCount++;
            canvasGroupCards.blocksRaycasts = false;

            CardController card = Instantiate(prefabCard, packParent);
            card.Initialize(pack.GetRandomCardData());
            _coroutineCardsMove.Add(
                card.transform,
                StartCoroutine(
                    card.MoveTo(
                        cardParent,
                        speedDistribution,
                        () =>
                        {
                            _picking = false;
                            _coroutineCardsMove.Remove(card.transform);
                            if (_coroutineCardsMove.Count == 0)
                                canvasGroupCards.blocksRaycasts = true;
                        }
                    ) 
                )
            );
        }
    }

    internal void CardSelectedStart(CardController card)
    {
        _cardsQueue.Enqueue(card);
        card.transform.SetParent(canvas);
    }

    internal void CardSelectedEnd()
    {
        _cardCount--;
    }

    public void Desativar()
    {
        contentSizeFitter.enabled = false;
        horizontalLayoutGroup.enabled = false;
    }

    public void Ativar()
    {
        contentSizeFitter.enabled = true;
        horizontalLayoutGroup.enabled = true;
    }
}
