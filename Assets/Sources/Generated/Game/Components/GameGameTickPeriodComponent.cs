//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity gameTickPeriodEntity { get { return GetGroup(GameMatcher.GameTickPeriod).GetSingleEntity(); } }
    public GameTickPeriodComponent gameTickPeriod { get { return gameTickPeriodEntity.gameTickPeriod; } }
    public bool hasGameTickPeriod { get { return gameTickPeriodEntity != null; } }

    public GameEntity SetGameTickPeriod(float newValue) {
        if (hasGameTickPeriod) {
            throw new Entitas.EntitasException("Could not set GameTickPeriod!\n" + this + " already has an entity with GameTickPeriodComponent!",
                "You should check if the context already has a gameTickPeriodEntity before setting it or use context.ReplaceGameTickPeriod().");
        }
        var entity = CreateEntity();
        entity.AddGameTickPeriod(newValue);
        return entity;
    }

    public void ReplaceGameTickPeriod(float newValue) {
        var entity = gameTickPeriodEntity;
        if (entity == null) {
            entity = SetGameTickPeriod(newValue);
        } else {
            entity.ReplaceGameTickPeriod(newValue);
        }
    }

    public void RemoveGameTickPeriod() {
        gameTickPeriodEntity.Destroy();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public GameTickPeriodComponent gameTickPeriod { get { return (GameTickPeriodComponent)GetComponent(GameComponentsLookup.GameTickPeriod); } }
    public bool hasGameTickPeriod { get { return HasComponent(GameComponentsLookup.GameTickPeriod); } }

    public void AddGameTickPeriod(float newValue) {
        var index = GameComponentsLookup.GameTickPeriod;
        var component = CreateComponent<GameTickPeriodComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceGameTickPeriod(float newValue) {
        var index = GameComponentsLookup.GameTickPeriod;
        var component = CreateComponent<GameTickPeriodComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveGameTickPeriod() {
        RemoveComponent(GameComponentsLookup.GameTickPeriod);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherGameTickPeriod;

    public static Entitas.IMatcher<GameEntity> GameTickPeriod {
        get {
            if (_matcherGameTickPeriod == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.GameTickPeriod);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherGameTickPeriod = matcher;
            }

            return _matcherGameTickPeriod;
        }
    }
}
