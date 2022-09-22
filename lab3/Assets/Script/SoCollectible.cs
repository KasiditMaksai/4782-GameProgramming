using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Collectibles", fileName = "New Collectible")]
public class SoCollectible : ScriptableObject
{
    [SerializeField] private CollectibleItem collectibleType;
    [SerializeField] private Sprite sprite;
    [SerializeField] private Sprite outlineSprite;
    [SerializeField] private bool respawnable;
    public Sprite GetSprite() => sprite;
    public CollectibleItem GetCollectibleItem() => collectibleType;
    public Sprite GetOutlineSprite() => outlineSprite;
    public bool GetRespawnable() => respawnable;
}
