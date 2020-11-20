using UnityEngine;

public class MazeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _wallsTemplate;
    [SerializeField, Min(0)] private int _wallId;
    [SerializeField, Min(3)] private int _width;
    [SerializeField] private int _height;
    [SerializeField, Range(0, 100)] private byte _mazeFillPercentage;
    [SerializeField, Range(0, 100)] private byte _windingPathPercentage;
    [SerializeField, Range(0, 100)] private float _blockPathPercentage;

    private MazeGeneration _generationMaze;

    private void Awake()
    {
        _generationMaze = new MazeGeneration(_width, _height, new RandomAlgorithm(_width, _mazeFillPercentage, _windingPathPercentage, _blockPathPercentage));
    }

    private void Start()
    {
        Spawn(_generationMaze.Generation());
    }

    private void Spawn(MazeCell[,] maze)
    {
        var newMaze = maze;

        for (int x = 0; x < newMaze.GetLength(0); x++)
        {
            for (int y = 0; y < newMaze.GetLength(1); y++)
            {
                if (newMaze[x, y].IsFull)
                {
                    GameObject newWall = Instantiate(_wallsTemplate[_wallId], GetPosition(newMaze[x, y]), Quaternion.identity);
                    newWall.transform.SetParent(transform);
                }
            }
        }
    }

    private Vector3 GetPosition(MazeCell mazeCell)
    {
        return new Vector3(mazeCell.X, 0, mazeCell.Y);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Spawn(_generationMaze.GenerationLine(1));
        }
    }
}