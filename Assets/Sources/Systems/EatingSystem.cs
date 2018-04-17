using Entitas;
using Entitas.Unity;

public class EatingSystem : IExecuteSystem
{

    private GameContext game;
    private IGroup<GameEntity> headGroup;
    private IGroup<GameEntity> foodGroup;

    public EatingSystem(GameContext game)
    {
        this.game = game;
        this.headGroup = game.GetGroup(GameMatcher.AllOf(GameMatcher.SnakeHead, GameMatcher.Position));
        this.foodGroup = game.GetGroup(GameMatcher.AllOf(GameMatcher.Food, GameMatcher.Position));
    }

    public void Execute()
    {
        if (!game.isGameTick) return;

        var head = headGroup.GetSingleEntity();
        var food = foodGroup.GetSingleEntity();

        if (head.position.value != food.position.value) return;
        //TODO: Destroy food in system
        game.isSnakeGrow = true;
        food.foodView.controller.gameObject.Unlink();
        UnityEngine.Object.Destroy(food.foodView.controller.gameObject);
        food.Destroy();

    }

}