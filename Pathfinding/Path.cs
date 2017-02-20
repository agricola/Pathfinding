using System.Collections.Generic;

namespace Pathfinding
{
    public class Path
    {

        public LinkedList<ITile> Tiles { get; private set; }
        public LinkedListNode<ITile> Current { get; private set; }
        public Path(IEnumerable<ITile> tiles)
        {
            Tiles = new LinkedList<ITile>(tiles);
            Current = this.Tiles.First;
        }

        public bool Advance()
        {
            bool nextTileExists = false;
            LinkedListNode<ITile> next = Current.Next;
            if (next != null) {
                Current = next;
                nextTileExists = true;
            }
            return nextTileExists;
        }
    }
}