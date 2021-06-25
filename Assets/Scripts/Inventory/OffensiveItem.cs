using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OffensiveElement {
    Red,
    Blue,
    Green
}

[CreateAssetMenu(fileName = "New Support Object", menuName = "Inventory/Items/Offensive")]
public class OffensiveItem : ItemObject
{
    public OffensiveElement element;
    private void Awake() {
        type = ItemType.Offensive;
    }
}
