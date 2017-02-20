using System.Collections.Generic;
using System;

namespace Pathfinding
{
    public class Pathfinder
    {
        private readonly IMap map;
        public Pathfinder(IMap map)
        {
            this.map = map;
        }

        public Dictionary<ITile, ITile> TravelDic(int x, int y, int goalX, int goalY)
        {
            PriorityQueue<ITile> frontier = new PriorityQueue<ITile>();
            ITile start = map.Tiles[x, y];
            frontier.Enqueue(start, 0);
            ITile goal = map.Tiles[goalX, goalY];
            
            // <current, came_from>
            Dictionary<ITile, ITile> cameFrom = new Dictionary<ITile, ITile>();
            cameFrom[start] = null;
            Dictionary<ITile, int> costSoFar = new Dictionary<ITile, int>();
            costSoFar[start] = 0;

            while(frontier.Count > 0)
            {
                ITile current = frontier.Dequeue();
                if (current == goal)
                {
                    break;
                }
                List<ITile> neighbors = map.GetNeighbors(current.X, current.Y);
                foreach (var next in neighbors)
                {
                    int cost = costSoFar[current] + next.MovementCost;
                    if (!cameFrom.ContainsValue(next) || cost < costSoFar[next])
                    {
                        costSoFar[next] = cost;
                        int priority = cost + Heuristic(goal, next);
                        frontier.Enqueue(next, priority);
                        cameFrom[next] = current;
                        if (goal == next)
                        {
                            break;
                        }
                    }
                }
            }
            return cameFrom;
        }

        public Path GetPath(int x, int y, int goalX, int goalY)
        {
            ITile start = map.Tiles[x, y];
            ITile goal = map.Tiles[goalX, goalY];
            Dictionary<ITile, ITile> travelDic = TravelDic(x, y, goalX, goalY);
            LinkedList<ITile> path = new LinkedList<ITile>();
            ITile current = goal;
            path.AddLast(current);
            while (current != start)
            {
                current = travelDic[current];
                path.AddFirst(current);
            }
            Path finalPath = new Path(path);
            return finalPath;
        }

        private int Heuristic(ITile current, ITile goal)
        {
            return Math.Abs((int)current.X - (int)goal.X)
                + Math.Abs((int)current.Y - (int)goal.Y);
        }
    }
}