using UnityEngine;

public class SavingSystem : MonoBehaviour
{
    [SerializeField] private GameData _scoreData;

    private string key;

    private void Awake()
    {
        Load();
    }

    private void Load()
    {
        JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString(key), _scoreData);
    }

    private void Save()
    {
        if (key == "")
        {
            key = _scoreData.name;
        }

        string jsonData = JsonUtility.ToJson(_scoreData, true);

        PlayerPrefs.SetString(key, jsonData);
        PlayerPrefs.Save();
    }

    private void OnApplicationQuit()
    {
        Save();
    }
}