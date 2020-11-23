using UnityEngine;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text _timer;

    public void SetGameTime()
    {
        _timer.text = $"{Time.timeSinceLevelLoad.ToString("F0")} second";
    }
}
