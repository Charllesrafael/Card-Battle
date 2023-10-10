using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameController : MonoBehaviour
{
    public static GameController Instance;    
    [SerializeField] private  int maxEnemy;
    [SerializeField] private  GameUI gameUI;   
    [SerializeField] private  PhaseController phaseController;   
    [SerializeField]  private CharacterManager[] charManager;

    internal int _numberCharacters;
    private int _enemiesDefeated;
    private bool _lockInput = false;
    private int currentScore;

    void Start()
    {
        currentScore = PlayerPrefs.GetInt(Global.GAME_SCORE);
        gameUI.UpdateScore(currentScore.ToString(Global.GAME_MASK_SCORE));
        
        phaseController.Inicialize();
        SpawnerController.Instance.Inicialize();
        charManager[0].onAttack += OnAttack;
    }

    private void OnAttack(int point)
    {
        currentScore += point;
        gameUI.UpdateScore(currentScore.ToString(Global.GAME_MASK_SCORE));
    }

    void Awake()
    {
        Instance = this;
        gameUI.AddListenerMenu(LoadMenu);
        gameUI.AddListenerRestart(RestartGame);
    }

    private void LoadMenu()
    {
        if(_lockInput)
            return;

        _lockInput = true;

        Time.timeScale = 1;
        PlayerPrefs.SetInt(Global.GAME_SCORE, currentScore);
        SceneController.LoadScene(Global.SCENE_MENU);
    }

    private void RestartGame()
    {
        if(_lockInput)
            return;
            
        _lockInput = true;

        Time.timeScale = 1;
        PlayerPrefs.SetInt(Global.GAME_SCORE, currentScore);
        WaitSystem.Wait(0.1f, ()=>{
            SceneController.Restart();
        });
    }

    internal void Hit(CharacterGameData _charGameData, int _targetId)
    {
        ReceiveDamage(_targetId, Mathf.CeilToInt(_charGameData.Damage));
    }

    internal void ReceiveDamage(int target, int damage)
    {
        if(target >= _numberCharacters)
            return;
        
        CharacterGameData _charGameData = charManager[target].charGameData;

        if (_charGameData.Life - damage > 0)
        {
            _charGameData.Life -= damage;
        }
        else
        {
            _charGameData.Life = 0;
            charManager[target].Die();
        }
        charManager[target].ReceivedDamage();
        
        CreationEffect.Instance.CreateLifeNumber("-"+damage, charManager[target].pointLifeNumber, target);

        if (charManager[target].charGameData.Life == 0)
            UpdateArena(target);
    }

    private void UpdateArena(int target)
    {
        _numberCharacters--;
        if (target > 0)
        {
            _enemiesDefeated++;
            if(_enemiesDefeated < maxEnemy)
                SpawnerController.Instance.NewEnemy();
            else
            {
                StopAllCoroutines();
                gameUI.Win();
            }
        }
        else
        {
            StopAllCoroutines();
            gameUI.GameOver();
        }
    }

    internal void GamingBehavior(CharacterManager _charManager)
    {
        StartCoroutine(IGamingBehavior(_charManager));
    }

    private IEnumerator IGamingBehavior(CharacterManager _character)
    {
        while (_character.charGameData.Life > 0)
        {
            yield return new WaitForSeconds(_character.GetCurrentTickAttack());
            if(_numberCharacters > 1)
                _character.AttackMelee(_character.GetTargetId());
        }
    }

    public CharacterManager GetTargetDrop(int id)
    {
        return charManager[id];
    }
}
