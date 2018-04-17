using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class MoveSystem : IExecuteSystem
{

    private GameContext game;
    private IGroup<GameEntity> snakeGroup;

    public MoveSystem(GameContext game)
    {
        this.game = game;
        snakeGroup = game.GetGroup(GameMatcher.AllOf(GameMatcher.Position,
            GameMatcher.Direction, GameMatcher.SnakeHead));
    }

    public void Execute()
    {
        if (!game.isGameTick) return;
        var entities = snakeGroup.GetEntities();
        if (entities.Length == 0) return;

        var entity = entities[0];
        var velocity = entity.direction.value.ToVector2Int();
        if (velocity == Vector2Int.zero) return;

        var map = game.gameFieldMap.map;

        var head = entity.snakeHead;
        Vector2Int newPosition = entity.position.value + velocity;
        newPosition = ValidatePosition(newPosition);
        Vector2Int oldPosition;
        for (int i = 0; i < head.segments.Count; i++)
        {
            var segmentEntity = head.segments[i];
            oldPosition = segmentEntity.position.value;
            map[oldPosition.x, oldPosition.y] = false;
            segmentEntity.ReplacePosition(newPosition);
            map[newPosition.x, newPosition.y] = true;

            newPosition = oldPosition;
        }
        if (game.isSnakeGrow)
        {
            game.isSnakeGrow = false;
            GameEntity segment = game.CreateEntity();
            segment.isSnakeSegment = true;
            segment.AddPosition(newPosition);
            map[newPosition.x, newPosition.y] = true;
            head.segments.Add(segment);
        }
    }

    private Vector2Int ValidatePosition(Vector2Int position)
    {
        var size = game.gameField.size;
        for (int i = 0; i < 2; i++) position[i] = (position[i] + size[i]) % size[i];
        return position;
    }

}