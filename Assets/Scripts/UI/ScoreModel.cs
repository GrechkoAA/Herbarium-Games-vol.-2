using UnityEngine;

public class ScoreModel : MonoBehaviour
{
    [SerializeField] private GameData _loadSaveData;
    [SerializeField] private float _gamePointsPerSecond;

    private float _currentTime;
    private float _currentPoints;
    private float _maxSeconds = 1;

    public event System.Action<float> Encouraged;

    private void Start()
    {
        _currentPoints = _loadSaveData.Points;
        Encouraged?.Invoke(_currentPoints);
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime >= _maxSeconds)
        {
            _currentPoints += _gamePointsPerSecond;

            Encouraged?.Invoke(_currentPoints);
            _loadSaveData.Points = _currentPoints;
            _currentTime = 0;
        }
    }
}