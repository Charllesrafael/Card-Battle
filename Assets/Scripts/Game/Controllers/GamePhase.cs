using UnityEngine;

[CreateAssetMenu(fileName = "GamePhase", menuName = "Charlles/Game Phase", order = 0)]
public class GamePhase : ScriptableObject {
    public PackData Pack;
    public Sprite Background;
    public CharactersPack PlayerCharactersPack;
    public CharactersPack EnemyCharactersPack;
}
