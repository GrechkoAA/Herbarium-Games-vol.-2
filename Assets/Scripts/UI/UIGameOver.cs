using UnityEngine;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text _time;

    public void SetGameTime()
    {
        _time.text = $"{Time.timeSinceLevelLoad.ToString("F0")} second";
    }
}
