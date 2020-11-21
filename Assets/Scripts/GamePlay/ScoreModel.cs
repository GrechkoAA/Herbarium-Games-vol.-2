using UnityEngine;

public class ScoreModel : MonoBehaviour
{
    [SerializeField] private float _encouragementInSecond;

    private float _currentTime;
    private float _currentPoints;

    public event System.Action<float> Encouraged;

    private void Start()
    {
        Encouraged?.Invoke(_currentPoints);
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime >= 1)
        {
            _currentPoints += _encouragementInSecond;

            Encouraged?.Invoke(_currentPoints);

            _currentTime = 0;
        }
    }
}