using UnityEngine;

public class CellPool : MonoBehaviour
{
    [SerializeField] private Transform _cellTemplate;
    [SerializeField] private Transform _parentWall;

    private float _currnetLine;
    private System.Collections.Generic.Queue<Transform> _list = new System.Collections.Generic.Queue<Transform>();

    public event System.Action LineAssembled;

    private void Start()
    {
        FillQueue(50);
    }

    public Transform Dequeue()
    {
        if (_list.Count == 0)
        {
            FillQueue(5);
        }

        return _list.Dequeue();
    }

    public void Enqueue(Transform cell)
    {
        cell.position = Vector3.zero;
        _list.Enqueue(cell);
    }

    private void FillQueue(int number)
    {
        for (int i = 0; i < number; i++)
        {
            Transform newWall = Instantiate(_cellTemplate);
            newWall.SetParent(_parentWall);

            _list.Enqueue(newWall);
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
            _list.Enqueue(wall.transform);

            if (IsNextLine(wall.transform.position.z))
            {
                _currnetLine = wall.transform.position.z;
                LineAssembled?.Invoke();
            }
        }
    }
}