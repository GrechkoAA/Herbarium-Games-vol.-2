using UnityEngine;

public class SavingSystem : MonoBehaviour
{
    [SerializeField] private System.Collections.Generic.List<Data> _listData;

    private void Awake()
    {
        Load();
    }

    private void Load()
    {
        foreach (var data in _listData)
        {
            JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString(data.name), data);
        }
    }

    public void OnSave()
    {
        foreach (var data in _listData)
        {
            string jsonData = JsonUtility.ToJson(data, true);

            PlayerPrefs.SetString(data.name, jsonData);
            PlayerPrefs.Save();
        }
    }

    private void OnApplicationPause(bool pause)
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            OnSave();
        }
    }

    private void OnApplicationQuit()
    {
        OnSave();
    }
}