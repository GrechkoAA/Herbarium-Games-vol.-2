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

    public void OnSave()
    {
        if (key == "")
        {
            key = _scoreData.name;
        }

        string jsonData = JsonUtility.ToJson(_scoreData, true);

        PlayerPrefs.SetString(key, jsonData);
        PlayerPrefs.Save();
    }

    private void OnApplicationPause(bool pause)
    {
        OnSave();
    }
}