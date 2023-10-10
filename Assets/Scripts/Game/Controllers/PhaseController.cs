using UnityEngine;
using UnityEngine.UI;

public class PhaseController : MonoBehaviour
{
    [SerializeField] private SpawnerController spawnerController;
    [SerializeField] private Image background;
    [SerializeField] private PackController packController;
    [SerializeField] private GamePhase[] gamePhase;

    private int chosenPhase;
    
    public void Inicialize()
    {
        chosenPhase = PlayerPrefs.GetInt(Global.GAME_CHOSE_PHASE);
        background.sprite = gamePhase[chosenPhase].Background;
        packController.SetPack(gamePhase[chosenPhase].Pack);
        spawnerController.SetCharaters(gamePhase[chosenPhase].PlayerCharactersPack, gamePhase[chosenPhase].EnemyCharactersPack);
    }
}
