using System.Collections.Generic;

namespace Pathfinding
{
    public class Map : IMap
    {
        public int Height { get; private set; }
        public int Width { get; private set; }
        public ITile[,] Tiles { get; private set; }

        public Map(int width, int height)
        {
            Height = height;
            Width = width;
            Tiles = GenerateTiles(Width, Height);
        }

        public bool IsWithinBounds(int x, int y)
        {
            return (x < Width && y < Height && x >= 0 && y >= 0) ? true : false;
        }

        public List<ITile> GetNeighbors(int x, int y)
        {
            List<ITile> neighbors = new List<ITile>();
            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (IsWithinBounds(i, j) && !Tiles[i, j].Blocked)
                    {
                        neighbors.Add(Tiles[i, j]);
                    }
                }
            }
            neighbors.Remove(Tiles[x, y]);
            return neighbors;
        }

        private Tile[,] GenerateTiles(int width, int height)
        {
            Tile[,] tiles = new Tile[Width, Height];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Tile tile = new Tile(i, j , false);
                    tiles[i,j] = tile;
                }
            }
            return tiles;
        }
    }
}