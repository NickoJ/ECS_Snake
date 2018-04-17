using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;

public class CreateFoodViewSystem : ReactiveSystem<GameEntity>, IInitializeSystem
{

    private readonly GameContext game;
    private readonly Transform root;
    private readonly FoodController foodPrefab;

    public CreateFoodViewSystem(GameContext game, Transform root, FoodController foodPrefab) : base(game)
    {
        this.game = game;
        this.root = root;
        this.foodPrefab = foodPrefab;
    }

    public void Initialize()
    {
        Execute();
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Food);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isFood && !entity.hasFoodView;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            var foodController = Object.Instantiate(foodPrefab);
            foodController.transform.SetParent(root, false);
            var pos = new Vector3(e.position.value.x + 0.5f, e.position.value.y + 0.5f, 0f);
            foodController.transform.localPosition = pos;
            e.AddFoodView(foodController);
            foodController.gameObject.Link(e, game);
        }
    }

}