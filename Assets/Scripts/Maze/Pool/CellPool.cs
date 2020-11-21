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

    public void Enqueue(Transform cell)
    {
        cell.position = Vector3.zero;
        _wallsQueue.Enqueue(cell);
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

    private void EnqueueLine(Transform wall)
    {
        _wallsQueue.Enqueue(wall);

        if (IsNextLine(wall.position.z))
        {
            _currnetLine = wall.position.z;
            LineAssembled?.Invoke();
        }
    }

    private bool IsNextLine(float lineNumber)
    {
        return _currnetLine != lineNumber;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Wall wall))
        {
            EnqueueLine(wall.transform);
        }
    }
}