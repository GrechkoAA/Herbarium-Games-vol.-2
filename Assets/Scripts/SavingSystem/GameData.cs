using UnityEngine;

[CreateAssetMenu(fileName = "NewData", menuName = "Create Data", order = 51)]
public class GameData : ScriptableObject
{
    [SerializeField] private float _points;

    public float Points
    {
        get { return _points; }
        set { _points = value; }
    }
}