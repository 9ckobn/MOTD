using System;
using System.Text;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class AbilitySerializer : MonoBehaviour
{
    public static AbilitySerializer instance;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(instance);
        }

        instance = this;
    }

    public async UniTask<Abilityes> GetAbilityesAsync()
    {
        var json = await DownloadFile("https://storage.yandexcloud.net/sfc-bucket/MOTDDATA/abilities.json");

        return JsonUtility.FromJson<Abilityes>(json);
    }

    async UniTask<string> DownloadFile(string url)
    {
        UnityWebRequest request = UnityWebRequest.Get(url);
        await request.SendWebRequest();
        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Error: " + request.error);
        }
        else
        {
            return ASCIIEncoding.UTF8.GetString(request.downloadHandler.data);
        }

        return null;
    }
}