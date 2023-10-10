using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private GameObject panelWin;
    [SerializeField] private GameObject panelGameOver;
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private Button[] buttonsRestart;
    [SerializeField] private Button[] buttonsMenu;


    internal void GameOver()
    {
        panelGameOver.SetActive(true);
    }

    internal void Win()
    {
        panelWin.SetActive(true);
    }

    internal void AddListenerRestart(Action _action)
    {
        foreach (var restart in buttonsRestart)
        {
            restart.onClick.AddListener(new UnityAction(_action));
        }
    }

    internal void AddListenerMenu(Action _action)
    {
        foreach (var menu in buttonsMenu)
        {
            menu.onClick.AddListener(new UnityAction(_action));
        }
    }

    internal void UpdateScore(string _score)
    {
        score.text = _score;
    }
}
