using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item 
{
    public enum ItemType
    {
        Piedra,
        Madera,
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.Madera: return ItemAssets.Instance.woodSprite;
            case ItemType.Piedra: return ItemAssets.Instance.rockSprite;
        }
    }
}
