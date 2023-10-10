using UnityEngine;

public class AttackController : MonoBehaviour
{
    [SerializeField] private CharacterManager characterManager;

    public void ReceiveDamage(int damage)
    {
        //characterManager.characterGameData.ReceivedDamage();
        //GameController.Instance.ReceiveDamage(characterManager, damage);
    }
}
