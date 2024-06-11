using System;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;


//todo Система выбора юнитов
public class PreparePartHUD : BaseScreen
{
    #region Ability
    [SerializeField] private AbilityButton abilityButtonPrefab;
    [SerializeField] private RectTransform abilityParentRect;

    public Action<Ability> onAbility;

    [SerializeField] private Abilityes abilityes;
    #endregion

    #region Inventory

    [SerializeField] private RectTransform InventoryLayout;
    [SerializeField] private InventryButton inventorySlotPrefab;

    public Action<InventorySlot> onSelectItem;

    [SerializeField] private Inventory inventory;
    #endregion

    public override async void Open()
    {
        base.Open();

        await SetupAbilities();
        SetupInventory();
    }

    private void SetupInventory()
    {
        foreach (var item in inventory.items)
        {
            var go = Instantiate(inventorySlotPrefab, InventoryLayout);
            go.SetAction(() => onSelectItem?.Invoke(new InventorySlot(444)));
        }
    }

    private async UniTask SetupAbilities()
    {
        SetupDefaultAbilities();

        abilityes = await AbilitySerializer.instance.GetAbilityesAsync();

        foreach (var item in abilityes.abilities)
        {
            var go = Instantiate(abilityButtonPrefab, abilityParentRect);
            go.SetAction(() => onAbility?.Invoke(item));
        }
    }

    private void SetupDefaultAbilities()
    {
        var buyUnitButton = Instantiate(abilityButtonPrefab, abilityParentRect);
        buyUnitButton.SetAction(() => onAbility?.Invoke(new Ability(AbilityConstants.BuyUnit)));

        var sellUnit = Instantiate(abilityButtonPrefab, abilityParentRect);
        sellUnit.SetAction(() => onAbility?.Invoke(new Ability(AbilityConstants.SellUnit)));
    }
}
