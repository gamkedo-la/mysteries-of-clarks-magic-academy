using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Support,
    Offensive
}

public abstract class ItemObject : ScriptableObject
{
    public string itemName;
    public ItemType type;
    [TextArea(15, 20)] public string description;
    public bool multiTarget;
    public int itemUseValue;
    public int price;
}
