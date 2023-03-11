using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable object/Item")]
public class Item : ScriptableObject { 
    public ItemType type;

    [Header("ImageSprite")]
    public Sprite image;

    //identifies what each item is
    public enum ItemType {
         CarJack,
         Hubcap,
         Tire,
         WoodBlock
    }
}
