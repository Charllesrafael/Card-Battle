using TMPro;
using UnityEngine;

public class EffectNumber : MonoBehaviour
{
    [SerializeField] private TextMeshPro effectNumber;
    
    public void SetNumber(string _damageText, Color color)
    {
        effectNumber.text = _damageText;
        effectNumber.color = color;
    }

    public void DestroyEffect()
    {
        Destroy(this.gameObject);
    }
}
