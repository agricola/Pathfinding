using Xunit;
using System.Collections.Generic;

namespace Pathfinding.Tests
{
    public class Tests
    {
        [Fact]
        public void TileConstructorWorks() 
        {
            Tile tile = new Tile(5, 10);
            Assert.True(tile.X == 5);
            Assert.True(tile.Y == 10);
            Assert.True(tile.Y != 15);
        }

        [Fact]
        public void PathConstructorWorks() 
        {
            Tile tile0 = new Tile(5, 10);
            Tile tile1 = new Tile(0, 15);
            Path path = new Path(new List<Tile>() {tile0, tile1});
            Assert.True(path.Tiles != null);
            Assert.True(path.Tiles.Count == 2);
        }

        [Fact]
        public void MapConstructorWorks()
        {
            TileMap map = new TileMap(5, 5);
            Assert.True(map.Tiles.Length == 25);
        }

        [Fact]
        public void TilesAreNotNull()
        {
            TileMap map = new TileMap(5, 5);
            Assert.True(map.Tiles[0, 0] != null);  
            Assert.True(map.Tiles[4, 4] != null);  
        }

        [Fact]
        public void CanBlockTiles()
        {
            TileMap map = new TileMap(5, 5);
            Assert.True(map.Tiles[0, 0].Blocked == false);
            map.Tiles[0, 0].Blocked = true;
            Assert.True(map.Tiles[0, 0].Blocked == true);
            map.Tiles[4, 4].Blocked = true;
            Assert.True(map.Tiles[4, 4].Blocked == true);
            map.Tiles[4, 4].Blocked = false;
            Assert.True(map.Tiles[4, 4].Blocked == false);
        }

        [Fact]
        public void ChecksTileAreWithinMapBoundsProperly()
        {
            TileMap map = new TileMap(5, 5);
            Assert.True(map.IsWithinBounds(5, 5) == false);
            Assert.True(map.IsWithinBounds(1, 1) == true);
        }
    }
}
