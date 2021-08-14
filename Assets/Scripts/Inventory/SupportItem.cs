using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SupportProperty {
    Health,
    Magic,
    AttackUp,
    AttackDown,
    DefenseUp,
    DefenseDown,
	 Resurrection,
	 Composite,
	 CriticalUp,
	 DodgeUp
};

[CreateAssetMenu(fileName = "New Support Object", menuName = "Inventory/Items/Support")]
public class SupportItem : ItemObject
{
    public SupportProperty property;
	 public bool isPercentage;
    public void Awake() {
        type = ItemType.Support;
    }
}
