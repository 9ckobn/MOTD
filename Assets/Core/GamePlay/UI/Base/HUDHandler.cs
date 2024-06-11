using UnityEngine;

public class HUDHandler : MonoBehaviour
{
    [SerializeField] private PreparePartHUD preparePartHUDprefab;

    private PreparePartHUD preparePartGameObject;

    private Player _player;

    public static HUDHandler instance;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(instance);
        }

        instance = this;
    }

    public void Construct(Player player)
    {
        _player = player;
    }

    public void ShowPreparePart()
    {
        if (preparePartGameObject == null)
        {
            preparePartGameObject = Instantiate(preparePartHUDprefab);
            preparePartGameObject.onAbility = _player.UseAbility;
            preparePartHUDprefab.onSelectItem = _player.SelectItemInInventory;
            preparePartGameObject.Open();
        }
        else
        {
            preparePartGameObject.onAbility = _player.UseAbility;
            preparePartHUDprefab.onSelectItem = _player.SelectItemInInventory;
            preparePartGameObject.Open();
        }

    }
}