using System.Collections.Generic;

namespace Pathfinding
{
    public interface IMap
    {
        int Height { get; }
        int Width { get;}
        ITile[,] Tiles { get; }

        bool IsWithinBounds(int x, int y);

        List<ITile> GetNeighbors(int x, int y);
    }
}