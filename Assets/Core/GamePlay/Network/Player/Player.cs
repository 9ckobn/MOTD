using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class Player : NetworkBehaviour
{
    private string[] randomFirstName = new string[5] { "Miha", "Stepan", "Lexa", "Vik", "Anthony" };
    private string[] randomLastName = new string[5] { "_pro", "_pro100rus", "_heh", "2000", "777pl" };

    private string myNickname = "";

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();

        if (IsOwner)
        {
            myNickname = randomFirstName[Random.Range(0, randomLastName.Length)] + randomLastName[Random.Range(0, randomFirstName.Length)];
            Debug.Log(myNickname);

            SetClientNameServerRpc(myNickname);

            HUDHandler.instance.Construct(this);
        }
    }

    #region ClientRpc

    [ClientRpc]
    private void PrepareClientRpc()
    {
        if (IsLocalPlayer && IsOwner)
        {
            HUDHandler.instance.ShowPreparePart();
            Debug.Log("Prepa part");
        }
    }

    [ClientRpc]
    private void GetEnemyNicknameClientRpc(string nickname, ClientRpcParams clientRpc = default)
    {
        Debug.Log("enemy is " + nickname + $"\n my nickname is {myNickname}");
    }

    #endregion

    #region ServerRpc

    [ServerRpc]
    private void SetClientNameServerRpc(string nickname, ServerRpcParams serverRpc = default) { }


    public void UseAbility(Ability ability)
    {
        UseAbilityServerRpc(ability.getAbilityType);
    }

    public void SelectItemInInventory(InventorySlot inventorySlot)
    {
        Debug.Log("Sele");
        SelectItemServerRpc(inventorySlot.itemCode);
    }

    [ServerRpc]
    private void SelectItemServerRpc(int type, ServerRpcParams serverRpc = default) { }


    [ServerRpc]
    private void UseAbilityServerRpc(int type, ServerRpcParams serverRpc = default) { }

    #endregion
}
