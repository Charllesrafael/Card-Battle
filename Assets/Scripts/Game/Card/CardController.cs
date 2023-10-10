using System;
using System.Collections;
using UnityEngine;

public class CardController : MonoBehaviour
{
    [SerializeField] private CardUI cardUI;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource sound;

    private bool _used;
    private int _idIndex = 0;
    private CardData _cardData;
    private Transform _target;
    private CharacterManager _targetEffect;
    private Transform _targetEffectTransform;
    private float _speedDistribution;
    private bool _finishedMoving;

    public void Drop()
    {
        if (_used)
            return;

        _targetEffect = GameController.Instance.GetTargetDrop(_cardData.TargetId);

        _used = true;

        sound.Play();
        Ativar();
        cardUI.DropUI();
        animator.SetBool(Global.TRIGGER_DROP, true);
        DeckManager.Instance.CardSelectedStart(this);
        StartCoroutine(UseMovement(EndDrop));
    }

    public void EndDrop()
    {
        CreationEffect.Instance.EffectCardDeath(_cardData, _cardData.TargetId);
        DeckManager.Instance.CardSelectedEnd();
        Destroy(gameObject);
    }

    public void Highlight()
    {
        _idIndex = transform.GetSiblingIndex();
        transform.SetAsLastSibling();
    }

    public void Normal()
    {
        transform.SetSiblingIndex(_idIndex);
    }

    internal IEnumerator UseMovement(Action callback)
    {
        //_targetEffectTransform
        _target = _targetEffect.transform;
        _speedDistribution = DeckManager.Instance.speedDrop;
        _finishedMoving = false;
        while (!_finishedMoving)
        {
            yield return new WaitForEndOfFrame();
        }
        callback?.Invoke();
    }

    internal IEnumerator MoveTo(RectTransform cardParent, float speedDistribution, Action callback)
    {
        _target = cardParent;
        _speedDistribution = speedDistribution;

        while (!_finishedMoving)
        {
            yield return new WaitForEndOfFrame();
        }

        transform.SetParent(_target); 
        cardUI.Active();
        callback?.Invoke();
    }
    

    internal void Initialize(CardData cardData)
    {
        _cardData = cardData;
        cardUI.Initialize(_cardData);
    }

    void Update()
    {
        if (_finishedMoving || _target == null)
            return;

        var step = _speedDistribution * Time.deltaTime; 
        transform.position = Vector3.MoveTowards(transform.position, _target.position, step);

        if (Vector3.Distance(transform.position, _target.position) < 0.001f)
        {
            _finishedMoving = true;
        }
    }

    public void Desativar()
    {
        DeckManager.Instance.Desativar();
    }

    public void Ativar()
    {
        DeckManager.Instance.Ativar();
    }
}
