public class MazeCell
{
    public readonly int X;
    public readonly int Y;

    public bool IsFull;

    public MazeCell(int x, int y)
    {
        X = x;
        Y = y;
    }
}