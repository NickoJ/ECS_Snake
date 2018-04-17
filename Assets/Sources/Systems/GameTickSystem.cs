using Entitas;
using UnityEngine;

public class GameTickSystem : IInitializeSystem, IExecuteSystem, ICleanupSystem
{

    private GameContext game;

    public GameTickSystem(GameContext game)
    {
        this.game = game;
    }

    public void Initialize()
    {
        var entity = game.CreateEntity();
        entity.AddGameTickPeriod(1.5f);
        entity.AddGameTimer(0f);
    }

    public void Execute()
    {
        var timer = game.gameTimer.value;
        timer += Time.deltaTime;
        var period = game.gameTickPeriod.value;
        if (game.isGameTickForceRequest || timer >= period)
        {
            timer = 0f;
            game.isGameTick = true;
        }
        game.ReplaceGameTimer(timer);
    }

    public void Cleanup()
    {
        if (game.isGameTick) game.isGameTick = false;
        if (game.isGameTickForceRequest) game.isGameTickForceRequest = false;
    }

}