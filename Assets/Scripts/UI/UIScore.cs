using UnityEngine;

public class UIScore : MonoBehaviour
{
    [SerializeField] private ScoreModel _scoreModel;
    [SerializeField] private TMPro.TMP_Text _score;

    private void OnEnable()
    {
        _scoreModel.Encouraged += (points) => _score.text = points.ToString("F0");
    }
}