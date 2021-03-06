﻿using UnityEngine;

public class MazeSpawner : MonoBehaviour
{
    [SerializeField] private CellPool _pool;
    [SerializeField, Min(0)] private int _maxLines;
    [SerializeField, Range(0, 100)] private byte _mazeFillPercentage;
    [SerializeField, Range(0, 100)] private byte _windingPathPercentage;
    [SerializeField, Range(0, 100)] private float _blockPathPercentage;

    private MazeGeneration _generationMaze;

    private void Awake()
    {
        var _width = 7;

        _generationMaze = new MazeGeneration(_width, _maxLines, new RandomAlgorithm(_width, _mazeFillPercentage, _windingPathPercentage, _blockPathPercentage));
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
                    _pool.Dequeue().position = GetPosition(newMaze[x, y]);
                }
            }
        }
    }

    private Vector3 GetPosition(MazeCell mazeCell)
    {
        return new Vector3(mazeCell.X, 0, mazeCell.Y);
    }

    private void OnEnable()
    {
        _pool.LineAssembled += () => Spawn(_generationMaze.GenerationLine(1));
    }
}