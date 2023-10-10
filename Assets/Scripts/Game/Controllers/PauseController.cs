using UnityEngine;

public class PauseController : MonoBehaviour
{
    [SerializeField] private GameObject panelPause;
    public void Pause()
    {
        Time.timeScale = 0;
        panelPause.SetActive(true);
    }

    public void UnPause()
    {
        Time.timeScale = 1;
        panelPause.SetActive(false);
    }
}
