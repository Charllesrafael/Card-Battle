using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private float _time;
    [SerializeField] private Toggle[] phaseToggles;
    private int _chosenPhase;

    void Awake()
    {
        _chosenPhase = PlayerPrefs.GetInt(Global.GAME_CHOSE_PHASE);
        phaseToggles[_chosenPhase].isOn = true;
    }

    void Start()
    {
        StartCoroutine(ShowMenu());
    }

    private IEnumerator ShowMenu()
    {
        float step = 1 / _time;
        while (_canvasGroup.alpha < 1)
        {
            _canvasGroup.alpha += Time.deltaTime/ _time;
            yield return new WaitForEndOfFrame();
        }
        _canvasGroup.alpha = 1;
        _canvasGroup.interactable = true;
    }

    public void StartGame()
    {
        SceneController.LoadScene(Global.SCENE_GAME);
    }

    public void ChangePhase(int _phase)
    {
        _chosenPhase = _phase;
        PlayerPrefs.SetInt(Global.GAME_CHOSE_PHASE, _chosenPhase);
    }

    public void DeleteAllSave()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        phaseToggles[0].isOn = true;
        phaseToggles[1].isOn = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
