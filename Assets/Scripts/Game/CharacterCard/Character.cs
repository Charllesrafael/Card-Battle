using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "Charlles/Character")]
public class Character : ScriptableObject
{
    public int Life;
    public int Damage;
    public int TargetId;
    public float TickAttack = 1;

    [Range(0, 100)]
    public int Accuracy = 100;

    [Range(0, 100)]
    public float CriticalChance = 1;

    public Sprite Icon;
    public AudioClip ReceivedDamageSound;
    public AudioClip SoundDeath;
}