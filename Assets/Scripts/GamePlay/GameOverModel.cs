using UnityEngine;

public class GameOverModel : MonoBehaviour
{
    [SerializeField] private UnityEngine.Events.UnityEvent _gameOvered;

    private void OnBecameInvisible()
    {
        _gameOvered?.Invoke();
    }
}