using TMPro;
using UnityEngine;

public class PackUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI packTitle;

    public void SetTitle(string _title)
    {
        packTitle.text = _title;
    }
}
