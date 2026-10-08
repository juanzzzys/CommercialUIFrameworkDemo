using UnityEngine;
using UnityEngine.UI;

public class BatchTest : MonoBehaviour
{
    [SerializeField] private Image imageA;
    [SerializeField] private Image imageB;

    private void Start()
    {
        Debug.Log($"A Sprite: {imageA.sprite.name}");
        Debug.Log($"B Sprite: {imageB.sprite.name}");

        Debug.Log($"A Texture: {imageA.mainTexture.name}");
        Debug.Log($"B Texture: {imageB.mainTexture.name}");

        Debug.Log(
            $"Same Texture: " +
            $"{imageA.mainTexture == imageB.mainTexture}"
        );
    }
}