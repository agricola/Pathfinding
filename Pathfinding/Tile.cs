namespace Pathfinding
{
    public class Tile : ITile
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public int MovementCost { get; private set; } = 1;
        public bool Blocked { get; set; }
        public Tile(int x, int y, bool blocked = false)
        {
            X = x;
            Y = y;
            Blocked = blocked;
        }
    }
}