# Pathfinding
Pathfinding library for games

It is meant to be for turn-based, square tile games. It can work with hex grids probably, just need to make a hex based GetNeighbors method in your map class.

Made it based off A* tutorial on RedBlogGames and Roguesharp pathfinding

Currently, all movement has the same cost, including diagonals.

How to use:

    1. Setup a tile and map class that use the IMap and ITile interfaces
    
    2. Create an instance of Pathfinder and then run the GetPath method which will give you a Path instance
    
    3. Each time you call the Advance method in Path, it will return true/false if it advanced (not at end of path) and then you can call Current.Value for the current tile
