using UnityEngine;
using UnityEngine.UI;

public class TextureOffset : MonoBehaviour
{
    [SerializeField] private float speedTexture;
    [SerializeField] private Vector2 offsetDirection;
    [SerializeField] private Image imageTexture;

    private Vector2 offset;

    void Update()
    {
        offset.x += offsetDirection.x * speedTexture * Time.deltaTime;
        offset.y += offsetDirection.y * speedTexture * Time.deltaTime;
        imageTexture.material.mainTextureOffset = offset;
    }
}
