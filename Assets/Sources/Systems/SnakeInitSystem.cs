using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class SnakeInitSystem : IInitializeSystem
{
 
    private GameContext gameContext;
    private Direction direction;
    private int snakeLength;

    public SnakeInitSystem(GameContext gameContext)
    {
        this.gameContext = gameContext;
        this.direction = Direction.Left;
        this.snakeLength = 3;
    }

    public void Initialize()
    {
        Vector2Int bottomLeft = Vector2Int.zero;
        Vector2Int topRight = gameContext.gameField.size;

        switch(direction)
        {
            case Direction.Up: bottomLeft.y += snakeLength; break;
            case Direction.Right: bottomLeft.x += snakeLength; break;
            case Direction.Down: topRight.y -= snakeLength; break;
            case Direction.Left: topRight.x -= snakeLength; break;
        }

        Vector2Int headPos = VectorUtils.Range(bottomLeft, topRight);
        GameEntity head = gameContext.CreateEntity();
        head.AddDirection(direction);
        var segmentsList = new List<GameEntity>();
        segmentsList.Add(head);
        head.AddSnakeHead(segmentsList);

        Vector2Int pos = headPos;
        Vector2Int directionVector = direction.Negate().ToVector2Int();
        var map = gameContext.gameFieldMap.map;

        for (int i = 0; i < snakeLength; i++)
        {
            if (segmentsList.Count == i) segmentsList.Add(gameContext.CreateEntity());
            GameEntity segment = segmentsList[i];
            segment.isSnakeSegment = true;

            segment.AddPosition(pos);
            map[pos.x, pos.y] = true;
            pos = pos + directionVector;
        }
    }

}