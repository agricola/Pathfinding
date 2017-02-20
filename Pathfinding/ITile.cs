namespace Pathfinding
{
    public interface ITile
    {
        int X { get; }
        int Y { get; }
        int MovementCost { get; }
        bool Blocked { get; set; }
    }
}