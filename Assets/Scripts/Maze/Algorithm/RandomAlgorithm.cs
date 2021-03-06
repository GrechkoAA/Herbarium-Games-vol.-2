﻿using UnityEngine;

public class RandomAlgorithm : IAlgorithmGeneratable
{
    private Vector2 _path;
    private int _widht;

    private byte _mazeFillPercentage;
    private byte _windingPathPercentage;
    private float _blockPathPercentage;

    private bool _isLeftCorner = false;
    private bool _isRightCorner = false;

    public RandomAlgorithm(int width, byte mazeFillPercentage, byte windingPathPercentage, float blockPathPercentage)
    {
        _widht = width;
        _path = new Vector2(_widht / 2, 0);

        _mazeFillPercentage = mazeFillPercentage;
        _windingPathPercentage = windingPathPercentage;
        _blockPathPercentage = blockPathPercentage;
    }

    public void FillMaze(MazeCell[,] maze)
    {
        for (int x = 0; x < maze.GetLength(0); x++)
        {
            for (int y = 0; y < maze.GetLength(1); y++)
            {
                maze[x, y].IsFull = Random.Range(0, 100) < _mazeFillPercentage;
            }
        }
    }

    public void GenerationPath(MazeCell[,] maze)
    {
        for (int x = 0; x < maze.GetLength(0); x++)
        {
            for (int y = 0; y < maze.GetLength(1); y++)
            {
                if ((IsPathBlocked() == true) && (_path.x == maze[x, y].X))
                {
                    maze[x, y].IsFull = false;

                    MakeStep(maze, x, y);
                }
            }
        }
    }

    private bool IsPathBlocked()
    {
        return Random.Range(0, 100) > _blockPathPercentage;
    }

    private void MakeStep(MazeCell[,] maze, int x, int y)
    {
        bool isStepLeft;
        bool isStepRight;

        if (_isLeftCorner == false)
        {
            isStepLeft = Random.Range(0, 100) < _windingPathPercentage;

            if ((isStepLeft) && (maze[x, y].X > 0))
            {
                _path.x--;
                maze[x, y - 1].IsFull = false;
                _isLeftCorner = maze[x, y].X == 1 ? true : false;
            }
        }

        if (_isRightCorner == false)
        {
            isStepRight = Random.Range(0, 100) < _windingPathPercentage;

            if ((isStepRight) && (maze[x, y].X < _widht - 1))
            {
                _path.x++;
                maze[x, y + 1].IsFull = false;
                _isRightCorner = maze[x, y].X == _widht - 2 ? true : false;
            }
        }

        if (_path.x == _widht / 2)
        {
            _isLeftCorner = false;
            _isRightCorner = false;
        }
    }
}