using UnityEngine;

public class UIScore : MonoBehaviour
{
    [SerializeField] private ScoreModel _scoreModel;
    [SerializeField] private TMPro.TMP_Text _text;

    private void OnEnable()
    {
        _scoreModel.Encouraged += (points) => _text.text = points.ToString("F0");
    }
}