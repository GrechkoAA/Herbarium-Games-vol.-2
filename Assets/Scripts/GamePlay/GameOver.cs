using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private UnityEngine.Events.UnityEvent _gameOvered;

    private void OnBecameInvisible()
    {
        Time.timeScale = 0;

        _gameOvered?.Invoke();
    }
}