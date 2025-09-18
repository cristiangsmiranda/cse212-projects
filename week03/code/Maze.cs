/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created. The dictionary will contain the
/// following mapping:
///
/// (x,y) : [left, right, up, down]
///
/// 'x' and 'y' are integers and represents locations in the maze.
/// 'left', 'right', 'up', and 'down' are boolean are represent valid directions
///
/// If a direction is false, then we can assume there is a wall in that direction.
/// If a direction is true, then we can proceed.  
///
/// If there is a wall, then throw an InvalidOperationException with the message "Can't go that way!".  If there is no wall,
/// then the 'currX' and 'currY' values should be changed.
/// </summary>
public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    // TODO Problem 4 - ADD YOUR CODE HERE
    /// <summary>
    /// Check to see if you can move left.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveLeft()
    {
        Move(0, -1, 0);
    }

    /// <summary>
    /// Check to see if you can move right.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveRight()
    {
        Move(1, 1, 0);
    }

    /// <summary>
    /// Check to see if you can move up.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveUp()
    {
        Move(2, 0, -1);
    }

    /// <summary>
    /// Check to see if you can move down.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveDown()
    {
        Move(3, 0, 1);
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }

    private void Move(int directionIndex, int dx, int dy)
    {
        if (!_mazeMap.TryGetValue((_currX, _currY), out var walls))
        {
            Console.WriteLine($"[DEBUG] No map entry for current cell ({_currX},{_currY}).");
            throw new InvalidOperationException("Can't go that way!");
        }
    
        Console.WriteLine($"[DEBUG] At ({_currX},{_currY}) walls=[{string.Join(",", walls.Select(b => b ? "T" : "F"))}] trying dirIndex={directionIndex} (dx={dx},dy={dy})");

        if (!walls[directionIndex])
        {
            Console.WriteLine($"[DEBUG] Blocked: walls[{directionIndex}] is false at ({_currX},{_currY}).");
            throw new InvalidOperationException("Can't go that way!");
        }

        int newX = _currX + dx;
        int newY = _currY + dy;

        if (!_mazeMap.ContainsKey((newX, newY)))
        {
            Console.WriteLine($"[DEBUG] Destination ({newX},{newY}) does not exist in map.");
            throw new InvalidOperationException("Can't go that way!");
        }

        Console.WriteLine($"[DEBUG] Moving ({_currX},{_currY}) -> ({newX},{newY}).");
        _currX = newX;
        _currY = newY;
    }
}