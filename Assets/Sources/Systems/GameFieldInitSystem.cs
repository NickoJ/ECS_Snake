using Entitas;
using UnityEngine;

public class GameFieldInitSystem : IInitializeSystem
{

    private GameContext gameContext;

    public GameFieldInitSystem(GameContext gameContext)
    {
        this.gameContext = gameContext;
    }

    public void Initialize()
    {
        var entity = gameContext.CreateEntity();
        var size = new Vector2Int(20, 10);
        entity.AddGameField(size);
        var map = new bool[size.x, size.y];
        entity.AddGameFieldMap(map);
    }

}