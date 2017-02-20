namespace Pathfinding
{
    public interface ITile
    {
        int X { get; }
        int Y { get;}
        bool Blocked { get; set; }
    }
}