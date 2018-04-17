using UnityEngine;

public class GameFeature : Feature
{
    public GameFeature(Contexts contexts, Transform root, FoodController foodPrefab, 
        SnakeSegmentController snakePrefab) 
        : base("Game Feature")
    {
        Add(new GameFieldInitSystem(contexts.game));
        Add(new SnakeInitSystem(contexts.game));
        Add(new EmitInputSystem(contexts.input));
        Add(new InputMoveSystem(contexts.input, contexts.game));
        Add(new GameTickSystem(contexts.game));
        Add(new MoveSystem(contexts.game));
        Add(new SelfEatingSystem(contexts.game));
        Add(new EatingSystem(contexts.game));
        Add(new CreateFoodSystem(contexts.game));
        Add(new CreateFoodViewSystem(contexts.game, root, foodPrefab));
        Add(new CreateSnakeViewSystem(contexts.game, root, snakePrefab));
        Add(new RenderSnakePositionSystem(contexts.game));
    }
}