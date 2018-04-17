using Entitas;

public class SelfEatingSystem : IExecuteSystem
{

    private readonly GameContext game;
    private readonly IGroup<GameEntity> headGroup;

    public SelfEatingSystem(GameContext game)
    {
        this.game = game;
        headGroup = game.GetGroup(GameMatcher.SnakeHead);
    }

    public void Execute()
    {
        if (!game.isGameTick) return;

        var headEntity = headGroup.GetSingleEntity();
        var head = headEntity.snakeHead;
        var headPos = headEntity.position.value;
        for (int i = 0; i < head.segments.Count; i++)
        {
            var segmentEntity = head.segments[i];
            if (headEntity == segmentEntity) continue;

            if (headPos == segmentEntity.position.value)
            {
                game.isPlayerLose = true;
            }
        }
    }

}