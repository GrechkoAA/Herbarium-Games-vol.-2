using UnityEngine;

public class CellPool : MonoBehaviour
{
    [SerializeField] private Transform _walls;
    [SerializeField] private Transform _parentWall;
    
    private float _currnetLine;
    private System.Collections.Generic.Queue<Transform> _wallsQueue = new System.Collections.Generic.Queue<Transform>();

    public event System.Action LineAssembled;

    private void Start()
    {
        FillQueue(50);
    }

    public Transform Dequeue()
    {
        if (_wallsQueue.Count == 0)
        {
            FillQueue(5);
        }

        return _wallsQueue.Dequeue();
    }

    private void FillQueue(int number)
    {
        for (int i = 0; i < number; i++)
        {
            Transform newWall = Instantiate(_walls);
            newWall.SetParent(_parentWall);

            _wallsQueue.Enqueue(newWall);
        }
    }

    private void Enqueue(Collider other)
    {
        _wallsQueue.Enqueue(other.transform);

        if (IsNextLine(other.transform.position.z))
        {
            _currnetLine = other.transform.position.z;
            LineAssembled?.Invoke();
        }
    }

    private bool IsNextLine(float lineNumber)
    {
        return _currnetLine != lineNumber;
    }

    private void OnTriggerEnter(Collider other)
    {
        Enqueue(other);
    }
}