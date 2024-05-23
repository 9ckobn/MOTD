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
        }
    }


    [ClientRpc]
    private void PrepareClientRpc()
    {
        if (IsLocalPlayer && IsOwner)
            Debug.Log("Prepa part");
    }

    [ClientRpc]
    private void GetEnemyNicknameClientRpc(string nickname, ClientRpcParams clientRpc = default)
    {
        Debug.Log("enemy is " + nickname + $"\n my nickname is {myNickname}");
    }

    [ServerRpc]
    private void SetClientNameServerRpc(string nickname, ServerRpcParams serverRpc = default) { }




}
