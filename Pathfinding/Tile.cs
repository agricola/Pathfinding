namespace Pathfinding
{
    public class Tile
    {
        public int X { get; private set; }
        public int Y { get; private set;}
        public bool Blocked { get; set; }
        public Tile(int x, int y, bool blocked = false)
        {
            X = x;
            Y = y;
            Blocked = blocked;
        }
    }
}