using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class RenderSnakePositionSystem : IInitializeSystem, IExecuteSystem
{

    private GameContext gameContext;
    private IGroup<GameEntity> segments;

    public RenderSnakePositionSystem(GameContext gameContext)
    {
        this.gameContext = gameContext;
        segments = gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.SnakeView,
            GameMatcher.Position));
    }

    public void Initialize()
    {
        SetupPositions();
    }

    public void Execute()
    {
        if (!gameContext.isGameTick) return;

        SetupPositions();
    }

    private void SetupPositions()
    {
        foreach (var e in segments.GetEntities())
        {
            Vector2Int intPos = e.position.value;
            var pos = new Vector3(intPos.x + 0.5f, intPos.y + 0.5f, 0f);
            e.snakeView.controller.transform.localPosition = pos;
        }
    }

}