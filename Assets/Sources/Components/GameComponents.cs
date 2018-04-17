using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game, Unique, Event(false)] public class PlayerWinComponent : IComponent {}
[Game, Unique, Event(false)] public class PlayerLoseComponent : IComponent {}

[Game] public class SnakeSegmentComponent : IComponent {}

[Game]
public class SnakeHeadComponent : IComponent
{
    public List<GameEntity> segments;
}

[Game, Unique]
public class SnakeGrowComponent : IComponent {}

[Game]
public class PositionComponent : IComponent
{
    public Vector2Int value;
}

[Game]
public class DirectionComponent : IComponent
{
    public Direction value;
}

[Game]
public class FoodComponent : IComponent {}

[Game]
public class FoodViewComponent : IComponent
{
    public FoodController controller;
}

[Game]
public class SnakeViewComponent : IComponent 
{
    public SnakeSegmentController controller;
}

[Game, Unique]
public class GameFieldComponent : IComponent 
{
    public Vector2Int size;
}

[Game, Unique]
public class GameFieldMapComponent : IComponent
{
    public bool[,] map;
}

[Game, Unique]
public class GameTickForceRequestComponent : IComponent {}

[Game, Unique]
public class GameTickComponent : IComponent {}

[Game, Unique]
public class GameTickPeriodComponent : IComponent
{
	public float value;
}

[Game, Unique]
public class GameTimerComponent : IComponent
{
	public float value;
}