using Unity.Netcode;
using UnityEngine;

public class Game : MonoBehaviour
{
    void Start()
    {
        // var abilityJson = JsonUtility.ToJson(AbilityType)

        if (Application.platform != RuntimePlatform.WindowsServer || Application.platform != RuntimePlatform.LinuxServer)
        {
            GameStart();
        }
    }

    private void GameStart()
    {
        if(NetworkManager.Singleton.StartClient())
        {
            Debug.Log("Start game");
            gameObject.AddComponent<AbilitySerializer>();
        }
        else
        {
            Debug.Log("Couldnt connect to server");
        }
    }
}
