using System;
using UnityEngine;

public class InventryButton : BaseButton
{
    [SerializeField] private InventorySlot inventorySlot;

    public void SetAction(Action<InventorySlot> onSelect)
    {
        _button.onClick.AddListener(() =>
        {
            onSelect?.Invoke(inventorySlot);
            Debug.Log("USING");
        });
    }
}