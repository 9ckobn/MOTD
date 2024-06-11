using System;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class Inventory
{
    public List<InventorySlot> items;
}

[Serializable]
public struct InventorySlot
{
    public InventorySlot(int code)
    {
        itemCode = code;
        Avatar = null;
    }

    public Sprite Avatar;

    public int itemCode;
}