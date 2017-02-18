namespace Pathfinding
{
    public class Map
    {
        public int Height { get; private set; }
        public int Width { get; private set; }
        public Tile[,] Tiles { get; private set; }
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