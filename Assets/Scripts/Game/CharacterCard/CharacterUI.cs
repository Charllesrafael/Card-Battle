using TMPro;
using UnityEngine;

public class CharacterUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI life;
    [SerializeField] private TextMeshProUGUI damage;
    [SerializeField] private SpriteRenderer icone;

    public void Inicialize(string _life, Sprite _icone)
    {
        life.text = _life;
        icone.sprite = _icone;
    }

    public void UpdateLife(int _life)
    {
        life.text = _life.ToString();
    }

    public void UpdateDamage(float _damage)
    {
        damage.text = Mathf.CeilToInt(_damage).ToString();
    }
}
