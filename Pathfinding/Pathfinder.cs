using System.Collections.Generic;
using System.Linq;

namespace Pathfinding
{
    public class Pathfinder
    {
        private readonly Map map;
        public Pathfinder(Map map)
        {
            this.map = map;
        }

        // TODO: improve
        public List<Tile> GetNeighbors(int x, int y, bool walls = false)
        {
            List<Tile> neighbors = new List<Tile>();
            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (map.IsWithinBounds(i, j)
                    && !(walls && map.Tiles[i, j].Blocked))
                    {
                        neighbors.Add(map.Tiles[i, j]);
                    }
                }
            }
            neighbors.Remove(map.Tiles[x, y]);
            return PrioritizeDiagonals(neighbors, x, y);
        }

        public Dictionary<Tile, Tile> TravelDic(int x, int y, int goalX, int goalY)
        {
            Queue<Tile> frontier = new Queue<Tile>();
            Tile start = map.Tiles[x, y];
            frontier.Enqueue(start);
            Tile goal = map.Tiles[goalX, goalY];
            bool found = false;
            
            // <current, came_from>
            Dictionary<Tile, Tile> cameFrom = new Dictionary<Tile, Tile>();
            cameFrom[start] = null;

            while(frontier.Count > 0)
            {
                Tile current =
                    !found ? frontier.Dequeue()
                    : frontier.Where(t => t == goal).First();
                if (current == goal)
                {
                    break;
                }
                List<Tile> neighbors = GetNeighbors(current.X, current.Y, true);
                foreach (var next in neighbors)
                {
                    if (!cameFrom.ContainsValue(next))
                    {
                        frontier.Enqueue(next);
                        cameFrom[next] = current;
                        if (next == goal)
                        {
                            found = true;
                            break;
                        }
                    }
                }
            }
            return cameFrom;
        }

        public Path GetPath(int x, int y, int goalX, int goalY)
        {
            Tile start = map.Tiles[x, y];
            Tile goal = map.Tiles[goalX, goalY];
            Dictionary<Tile, Tile> travelDic = TravelDic(x, y, goalX, goalY);
            LinkedList<Tile> path = new LinkedList<Tile>();
            Tile current = goal;
            path.AddLast(current);
            while (current != start)
            {
                current = travelDic[current];
                path.AddFirst(current);
            }
            Path finalPath = new Path(path);
            return finalPath;
        }

        private List<Tile> PrioritizeDiagonals(List<Tile> tiles, int x, int y)
        {
            List<Tile> newTiles = new List<Tile>();
            var groups = tiles
                .GroupBy(t => t.X != x && t.Y != y)
                .OrderBy(g => g.Key == true)
                .Select(g => g.ToList());
            if (groups.Count() > 1)
            {
                newTiles = groups.ElementAt(1).Concat(groups.ElementAt(0)).ToList();
                return newTiles;
            }
            else
            {
                return tiles;
            }

        }
    }
}