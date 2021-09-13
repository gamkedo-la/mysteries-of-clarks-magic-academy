using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Inventory", menuName ="Inventory/Inventory")]
public class InventoryObject : ScriptableObject
{
    public List<InventorySlot> Container = new List<InventorySlot>();
    public void AddItem(ItemObject _item, int _amount) {
        for (int i = 0; i < Container.Count; i++)
        {
            if(Container[i].item == _item) {
                Container[i].AddAmount(_amount);
                return;
            }
        }
        Container.Add(new InventorySlot(_item, _amount));
    }

    public void RemoveItem(int index){
        Container.RemoveAt(index);
    }
}

[System.Serializable]
public class InventorySlot
{
    public ItemObject item;
    public int amount;

    public InventorySlot (ItemObject _item, int _amount) {
        item = _item;
        amount = _amount;
    }

    public void AddAmount (int value) {
        amount += value;
    }

    public bool RemoveAmount (int value) {
        amount -= value;
        return amount == 0; // if 0 it needs to be removed.
    }
}
