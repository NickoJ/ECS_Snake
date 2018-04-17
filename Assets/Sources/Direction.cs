using UnityEngine;

public enum Direction { Up, Right, Down, Left }

public static class DirectionUtils
{

    public static bool IsOppositeTo(this Direction dir1, Direction dir2)
    {
        return dir1.Negate() == dir2;
    }

    public static Direction Negate(this Direction direction)
    {
        switch(direction)
        {
            case Direction.Up: return Direction.Down;
            case Direction.Right: return Direction.Left;
            case Direction.Down: return Direction.Up;
            case Direction.Left: return Direction.Right;
        }
        return default(Direction);
    }

    public static Vector2Int ToVector2Int(this Direction direction)
    {
        switch(direction)
        {
            case Direction.Up: return Vector2Int.up;
            case Direction.Right: return Vector2Int.right;
            case Direction.Down: return Vector2Int.down;
            case Direction.Left: return Vector2Int.left;
        }
        return Vector2Int.zero;
    }
}