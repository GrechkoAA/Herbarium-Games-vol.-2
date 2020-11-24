using UnityEngine;

public class ScoreModel : MonoBehaviour
{
    [SerializeField] private GamePointData _loadSaveData;
    [SerializeField] private float _gamePointsPerSecond;

    private float _currentTime;
    private float _currentPoints;
    private float _maxSeconds = 1;

    private void Start()
    {
        _currentPoints = _loadSaveData.Points;
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime >= _maxSeconds)
        {
            _currentPoints += _gamePointsPerSecond;

            _loadSaveData.Points = _currentPoints;
            _currentTime = 0;
        }
    }
}