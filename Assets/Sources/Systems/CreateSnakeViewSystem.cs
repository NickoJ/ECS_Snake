using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;

public class CreateSnakeViewSystem : ReactiveSystem<GameEntity>, IInitializeSystem
{

    private GameContext gameContext;
    private Transform root;
    private SnakeSegmentController segmentPrefab;

    public CreateSnakeViewSystem(GameContext context, Transform root, SnakeSegmentController segmentPrefab)
        : base(context)
    {
        this.gameContext = context;
        this.root = root;
        this.segmentPrefab = segmentPrefab;
    }

    public void Initialize()
    {
        Execute();
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.SnakeSegment);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isSnakeSegment && !entity.hasSnakeView;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            var segmentController = Object.Instantiate(segmentPrefab);
            segmentController.transform.SetParent(root, false);
            e.AddSnakeView(segmentController);
            segmentController.gameObject.Link(e, gameContext);
            segmentController.IsHead = e.hasSnakeHead;
        }
    }

}