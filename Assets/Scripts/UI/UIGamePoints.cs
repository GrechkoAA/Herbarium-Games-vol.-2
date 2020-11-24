using UnityEngine;

public class UIGamePoints : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text _score;
    [SerializeField] private GameData _gameData;

    private void Start()
    {
        _score.text = _gameData.Points.ToString("F0");
    }

    private void OnEnable()
    {
        _gameData.PointsChanged += (currentPoints) => _score.text = currentPoints.ToString("F0");
    }
}