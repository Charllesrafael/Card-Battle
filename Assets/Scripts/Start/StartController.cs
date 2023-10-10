using UnityEngine;

public class StartController : MonoBehaviour
{
    [SerializeField] private float _delay;
    public void Load()
    {
        WaitSystem.Wait(_delay, () =>
        {
            SceneController.LoadScene(Global.SCENE_MENU);
        });
    }
}
