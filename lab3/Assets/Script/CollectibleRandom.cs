using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleRandom : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private int randomNumber;
    [SerializeField] private SpriteRenderer spriteRenderer;
    public CollectibleType color;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        randomNumber = Random.Range(0, sprites.Length);

        switch (randomNumber)
        {
            case 0:
                color = CollectibleType.Yellow;
                break;
            case 1:
                color = CollectibleType.Green;
                break;
            case 2:
                color = CollectibleType.Red;
                break;
        }
        spriteRenderer.sprite = sprites[randomNumber];
    }
}
