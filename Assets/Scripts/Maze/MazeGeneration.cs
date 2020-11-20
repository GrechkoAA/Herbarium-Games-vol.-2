public class MazeGeneration
{
    private int _width;
    private int _height;
    private int _numberLine;

    private IAlgorithmGeneratable _generationAlgorithm;

    public MazeGeneration(int width, int height, IAlgorithmGeneratable generationAlgorithm)
    {
        _width = width;
        _height = height;
        _generationAlgorithm = generationAlgorithm;
    }

    public MazeCell[,] Generation()
    {
        return GenerationLine(_height);
    }

    public MazeCell[,] GenerationLine(int line)
    {
        var maze = GetMaze(line);

        _generationAlgorithm.FillInMaze(maze);
        _generationAlgorithm.GenerationPath(maze);

        return maze;
    }

    private MazeCell[,] GetMaze(int line)
    {
        var maze = new MazeCell[line, _width];

        for (int x = 0; x < maze.GetLength(0); x++)
        {
            for (int y = 0; y < maze.GetLength(1); y++)
            {
                maze[x, y] = new MazeCell(y, _numberLine);
            }

            _numberLine++;
        }

        return maze;
    }
}