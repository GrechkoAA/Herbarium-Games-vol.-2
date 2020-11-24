using UnityEngine;

[CreateAssetMenu(fileName = "NewGamePointData", menuName = "Create Data/New Game Point Data", order = 51)]
public class GamePointData : Data
{
    [SerializeField] private float _points;

    public event System.Action<float> PointsChanged;

    public float Points
    {
        get { return _points; }
        set 
        {
            _points = value;

            PointsChanged?.Invoke(_points);
        }
    }
}