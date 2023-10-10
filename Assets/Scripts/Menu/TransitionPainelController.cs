using UnityEngine;

public class TransitionPainelController : MonoBehaviour {

    [SerializeField] private GameObject panelMenu;
    [SerializeField] private GameObject panelInstruction;
    [SerializeField] private GameObject panelSelectStage;
    
    public void SelectStage(bool Show)
    {
        TransitionPanel(panelSelectStage, panelMenu, Show);
    }

    public void ShowInstruction(bool Show)
    {
        TransitionPanel(panelInstruction, panelMenu, Show);
    }

    private void TransitionPanel(GameObject firtPanel, GameObject secondPanel, bool show)
    {
        firtPanel.SetActive(show);
        secondPanel.SetActive(!show);
    }
}
