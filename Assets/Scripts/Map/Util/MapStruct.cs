public struct Pos
{
    public Pos(int x, int y)
    {
        X = x;
        Y = y;
    }

    public static Pos operator +(Pos pos1, Pos pos2)
    {
        return new Pos(pos1.X + pos2.X, pos1.Y + pos2.Y);
    }
    public static Pos operator -(Pos pos1, Pos pos2)
    {
        return new Pos(pos1.X - pos2.X, pos1.Y - pos2.Y);
    }
    public int X { get; private set; }
    public int Y { get; private set; }
}