using UnityEngine;

public class SavingSystem : MonoBehaviour
{
    [SerializeField] private GameData _gameData;

    private string key;

    private void Awake()
    {
        Load();
    }

    private void Load()
    {
        JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString(key), _gameData);
    }

    private void Save()
    {
        if (key == "")
        {
            key = _gameData.name;
        }

        string jsonData = JsonUtility.ToJson(_gameData, true);

        PlayerPrefs.SetString(key, jsonData);
        PlayerPrefs.Save();
    }

    private void OnApplicationPause(bool pause)
    {
       // Save();
    }

    private void OnApplicationQuit()
    {
        Save();
    }
}