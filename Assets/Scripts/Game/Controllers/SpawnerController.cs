using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public static SpawnerController Instance;

    [SerializeField] private CharacterManager player;
    [SerializeField] private CharacterManager enemy;

    [Space]
    [SerializeField] private Character[] playerCharacters;
    [SerializeField] private Character[] enemyCharacters;
    

    void Awake()
    {
        Instance = this;
    }

    public void Inicialize()
    {
        player.Inicialize(playerCharacters[Random.Range(0, playerCharacters.Length)]);
        enemy.Inicialize(enemyCharacters[Random.Range(0, enemyCharacters.Length)]);
        DeckManager.Instance.DropCards();
    }

    public void NewEnemy()
    {
        enemy.StartNewEnemy();
        enemy.Inicialize(enemyCharacters[Random.Range(0,enemyCharacters.Length)]);
    }

    public void SetCharaters(CharactersPack playerCharactersPack, CharactersPack EnemyCharactersPack)
    {
        playerCharacters = playerCharactersPack.Characters;
        enemyCharacters = EnemyCharactersPack.Characters;
    }

    public CharacterGameData AddCharacter(CharacterManager characterManager, Character character)
    {
        CharacterGameData newCharacterGameData = new CharacterGameData
        {
            MyCharacter = character,
            Life = character.Life,
            Damage = character.Damage,
            TargetId = character.TargetId,
            CurrentTickAttack = character.TickAttack
        };
        characterManager.charGameData = newCharacterGameData;
        
        GameController.Instance._numberCharacters++;
        GameController.Instance.GamingBehavior(characterManager);
        
        return newCharacterGameData;
    }
}
