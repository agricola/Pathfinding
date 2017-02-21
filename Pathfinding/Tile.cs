namespace Pathfinding
{
    public class Tile : ITile
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int MovementCost { get; private set; }
        public bool Blocked { get; set; }
        public Tile(int x, int y, bool blocked = false, int cost = 1)
        {
            X = x;
            Y = y;
            Blocked = blocked;
            MovementCost = cost;
        }
    }
}