using UnityEngine;

public class ScoreModel : MonoBehaviour
{
    [SerializeField] private float _point;

    private float _currentTime;
    private float _currentPoints;
    private float _maxSeconds = 1;

    public event System.Action<float> Encouraged;

    private void Start()
    {
        Encouraged?.Invoke(_currentPoints);
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime >= _maxSeconds)
        {
            _currentPoints += _point;

            Encouraged?.Invoke(_currentPoints);

            _currentTime = 0;
        }
    }
}