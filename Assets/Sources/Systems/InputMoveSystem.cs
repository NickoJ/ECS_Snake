using System.Collections.Generic;
using Entitas;

public class InputMoveSystem : ReactiveSystem<InputEntity>
{

    private readonly GameContext game;
    private readonly IGroup<GameEntity> headGroup;

    public InputMoveSystem(InputContext input, GameContext game) : base(input)
    {
        this.game = game;
        headGroup = game.GetGroup(GameMatcher.AllOf(GameMatcher.SnakeHead, GameMatcher.Direction));
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return new Collector<InputEntity>(
            new IGroup<InputEntity>[] {
                context.GetGroup(InputMatcher.AnyOf(InputMatcher.UpButton, InputMatcher.RightButton,
                    InputMatcher.DownButton, InputMatcher.LeftButton)),
                context.GetGroup(InputMatcher.ButtonPressedDown)
            },
            new GroupEvent[] {
                GroupEvent.Added,
                GroupEvent.Added
            }
        );
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.isButtonPressedDown;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        if (entities.Count == 0) return;

        var head = headGroup.GetSingleEntity();
        var direction = GetDirectionFromCommand(entities[0]);
        if (!head.direction.value.IsOppositeTo(direction))
        {
            head.ReplaceDirection(direction);
            game.isGameTickForceRequest = true;
        }
    }

    private Direction GetDirectionFromCommand(InputEntity entity)
    {
        if (entity.isUpButton) return Direction.Up;
        if (entity.isRightButton) return Direction.Right;
        if (entity.isDownButton) return Direction.Down;
        return Direction.Left;
    }

}