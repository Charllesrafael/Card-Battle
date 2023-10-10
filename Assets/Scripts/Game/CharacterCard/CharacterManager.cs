using System;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] private CharacterUI characterUI;
    [SerializeField] private Animator characterAnimator;
    [SerializeField] private Animator cardAnimator;
    [SerializeField] internal Transform pointEffect;
    [SerializeField] internal Transform pointEffectNumber;
    [SerializeField] internal Transform pointLifeNumber;
    [SerializeField] private AudioSource sound;
    
    internal Action<int> onAttack;
    internal CharacterGameData charGameData;

    private int _currentTargetid;

    public void Inicialize(Character character)
    {
        charGameData = SpawnerController.Instance.AddCharacter(this, character);
        characterUI.Inicialize(character.Life.ToString(), character.Icon);
        UpdateDamage();
    }

    public void AttackMelee(int _targetId)
    {
        _currentTargetid = _targetId;
        characterAnimator.SetTrigger(Global.GAME_TRIGGER_MELEE);
    }

    public void AttackMeleeEffect()
    {
        GameController.Instance.Hit(charGameData, _currentTargetid);
        onAttack?.Invoke(Mathf.CeilToInt(charGameData.Damage));
    }

    public void AttackCast()
    {
        characterAnimator.SetTrigger(Global.GAME_TRIGGER_CAST);
    }

    public void AttackCastEffect()
    {

    }

    public void ReceivedDamage()
    {
        characterUI.UpdateLife(charGameData.Life);
        sound.PlayOneShot(charGameData.MyCharacter.ReceivedDamageSound);
        cardAnimator.SetTrigger(Global.GAME_TRIGGER_RECEIVED_DAMAGE);
    }
    
    public void UpdateDamage()
    {
        characterUI.UpdateDamage(charGameData.Damage);
    }

    internal void UpdateLife()
    {
        characterUI.UpdateLife(charGameData.Life);
    }

    internal void StartNewEnemy()
    {
        characterAnimator.SetTrigger(Global.TRIGGER_START);
    }

    internal float GetCurrentTickAttack()
    {
        return charGameData.CurrentTickAttack;
    }

    internal int GetTargetId()
    {
        return charGameData.TargetId;
    }

    internal void Die()
    {
        sound.PlayOneShot(charGameData.MyCharacter.SoundDeath);
    }

    internal void AddListenerAttack(Action<int> _action)
    {
        onAttack += _action;
    }

    internal void RemoveListenerAttack(Action<int> _action)
    {
        onAttack -= _action;
    }
}
