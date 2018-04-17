using Entitas;
using UnityEngine;

public class CreateFoodSystem : IInitializeSystem, IExecuteSystem
{
    
    private readonly GameContext game;
    private readonly IGroup<GameEntity> foodGroup;

    public CreateFoodSystem(GameContext game)
    {
        this.game = game;
        foodGroup = game.GetGroup(GameMatcher.AllOf(GameMatcher.Food, GameMatcher.Position));
    }    

    public void Initialize()
    {
        CheckFood();
    }

    public void Execute()
    {
        CheckFood();
    }

    private void CheckFood()
    {
        var entity = foodGroup.GetSingleEntity();
        if (entity != null) return;

        var map = game.gameFieldMap.map;
        var fieldSize = game.gameField.size;
        var position = FindPosition(map, fieldSize);

        if (position.x < 0 || position.y < 0)
        {
            game.isPlayerWin = true;
            return;
        }

        entity = game.CreateEntity();
        map[position.x, position.y] = true;
        entity.AddPosition(position);
        entity.isFood = true;
    }

    private Vector2Int FindPosition(bool[,] map, Vector2Int fieldSize)
    {
        Vector2Int position = new Vector2Int(-1, -1);
        var placeFound = false;

        for (int i = 0; i < 3; i++)
        {
            int x = Random.Range(0, fieldSize.x);
            int y = Random.Range(0, fieldSize.y);
            if (map[x, y]) continue;

            position.Set(x, y);
            placeFound = true;
            break;
        }

        if(!placeFound)
        {
            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    if (map[x, y]) continue;

                    position.Set(x, y);
                    placeFound = true;
                    break;
                }
                if (placeFound) break;
            }
        }

        return position;
    }

}