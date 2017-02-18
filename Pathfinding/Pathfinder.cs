using System.Collections.Generic;

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
            Tile tile = map.Tiles[x, y];
            List<Tile> neighbors = new List<Tile>();
            if (map.IsWithinBounds(x - 1, y) && !(walls && map.Tiles[x - 1, y].Blocked))
            {
                neighbors.Add(map.Tiles[x - 1, y]);
            }
            if (map.IsWithinBounds(x + 1, y) && !(walls && map.Tiles[x + 1, y].Blocked))
            {
                neighbors.Add(map.Tiles[x + 1, y]);
            }
            if (map.IsWithinBounds(x, y + 1) && !(walls && map.Tiles[x, y + 1].Blocked))
            {
                neighbors.Add(map.Tiles[x, y + 1]);
            }
            if (map.IsWithinBounds(x, y - 1) && !(walls && map.Tiles[x, y - 1].Blocked))
            {
                neighbors.Add(map.Tiles[x, y - 1]);
            }
            return neighbors;
        }

        public Dictionary<Tile, Tile> TravelDic(int x, int y)
        {
            Queue<Tile> frontier = new Queue<Tile>();
            Tile start = map.Tiles[x, y];
            frontier.Enqueue(start);
            
            // <current, came_from>
            Dictionary<Tile, Tile> cameFrom = new Dictionary<Tile, Tile>();
            cameFrom[start] = null;

            while(frontier.Count > 0)
            {
                Tile current = frontier.Dequeue();
                List<Tile> neighbors = GetNeighbors(current.X, current.Y, true);
                foreach (var next in neighbors)
                {
                    if (!cameFrom.ContainsValue(next))
                    {
                        frontier.Enqueue(next);
                        cameFrom[next] = current;
                    }
                }
            }
            return cameFrom;
        }

        public Path GetPath(int x, int y, int goalX, int goalY)
        {
            Tile start = map.Tiles[x, y];
            Tile goal = map.Tiles[goalX, goalY];
            Dictionary<Tile, Tile> travelDic = TravelDic(x, y);
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
    }
}