using Xunit;
using System.Collections.Generic;

namespace Pathfinding.Tests
{
    public class PathfinderTests
    {
        [Fact]
        public void GetsRightNumberOfNeighbors()
        {
            Map map = new Map(5, 5);
            Pathfinder pathfinder = new Pathfinder(map);
            List<Tile> tiles = pathfinder.GetNeighbors(2, 2);
            Assert.Equal(8, tiles.Count);
        }
        
        [Fact]
        public void GetsRightNeighbors()
        {
            Map map = new Map(5, 5);
            Pathfinder pathfinder = new Pathfinder(map);
            List<Tile> tiles = pathfinder.GetNeighbors(2, 2);
            Assert.NotEqual(tiles[0], tiles[1]);
            Assert.True(tiles.Contains(map.Tiles[1, 1]));
            Assert.True(tiles.Contains(map.Tiles[3, 3]));
        }
        
        [Fact]
        public void GetsRightNeighborsWithWalls()
        {
            Map map = new Map(5, 5);
            Tile bad = map.Tiles[2, 1];
            bad.Blocked = true;
            Pathfinder pathfinder = new Pathfinder(map);
            List<Tile> tiles = pathfinder.GetNeighbors(2, 2, true);
            Assert.Equal(7, tiles.Count);
            Assert.True(!tiles.Contains(bad));
        }
        
        [Fact]
        public void GetsRightNeighborsOnEdgeOfMap()
        {
            Map map = new Map(5, 5);
            Pathfinder pathfinder = new Pathfinder(map);
            List<Tile> tiles = pathfinder.GetNeighbors(0, 0);
            Assert.Equal(3, tiles.Count);
            Assert.True(tiles.Contains(map.Tiles[0,1]));
            Assert.True(tiles.Contains(map.Tiles[1,1]));
        }
        
        [Fact]
        public void ExitsEarlyIfGoalFound()
        {
            Map map = new Map(10, 10);
            Pathfinder pathfinder = new Pathfinder(map);
            var travelDic0 = pathfinder.TravelDic(2, 2, 9, 9);
            Assert.Equal(98, travelDic0.Count);
            var travelDic1 = pathfinder.TravelDic(2, 2, 2, 1);
            Assert.Equal(7, travelDic1.Count);
        }
        
        [Fact]
        public void VisitsEveryTileThatIsntAWall()
        {
            Map map = new Map(5, 5);
            map.Tiles[0, 0].Blocked = true;
            map.Tiles[1, 0].Blocked = true;
            map.Tiles[4, 4].Blocked = true;
            Pathfinder pathfinder = new Pathfinder(map);
            var travelDic = pathfinder.TravelDic(2, 2, 4, 4);
            Assert.Equal(22, travelDic.Count);
        }
        
        [Fact]
        public void BFSNavigates()
        {
            Map map = new Map(5, 5);
            map.Tiles[1, 0].Blocked = true;
            map.Tiles[1, 1].Blocked = true;
            map.Tiles[1, 2].Blocked = true;
            map.Tiles[1, 3].Blocked = true;
            map.Tiles[3, 4].Blocked = true;
            map.Tiles[3, 3].Blocked = true;
            map.Tiles[3, 2].Blocked = true;
            map.Tiles[3, 1].Blocked = true;
            Pathfinder pathfinder = new Pathfinder(map);
            Path path = pathfinder.GetPath(0, 0, 4, 4);
            List<Tile> testPathList = new List<Tile>()
            {
                map.Tiles[0,0], map.Tiles[0,1], map.Tiles[0,2],
                map.Tiles[0,3], map.Tiles[1,4],
                map.Tiles[2,3], map.Tiles[2,2], map.Tiles[2,1],
                map.Tiles[3,0], map.Tiles[4,1], map.Tiles[4,2],
                map.Tiles[4,3], map.Tiles[4,4]
            };
            Assert.Equal(testPathList.Count, path.Tiles.Count);
            Path testPath = new Path(testPathList);
            Assert.Equal(testPath.Tiles, path.Tiles);
            path.Advance();
            Assert.Equal(map.Tiles[0, 1], path.Current.Value);
        }
    }
}