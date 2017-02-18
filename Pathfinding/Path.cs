using System.Collections.Generic;

namespace Pathfinding
{
    public class Path
    {

        public LinkedList<Tile> Tiles { get; private set; }
        public LinkedListNode<Tile> Current { get; private set; }
        public Path(IEnumerable<Tile> tiles)
        {
            Tiles = new LinkedList<Tile>(tiles);
            Current = this.Tiles.First;
        }

        public Tile Advance()
        {
            LinkedListNode<Tile> next = Current.Next;
            if (next == null) {
                throw new System.Exception();
            }
            Current = next;
            return next.Value;
        }

    }
}