//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public PlayerWinListenerComponent playerWinListener { get { return (PlayerWinListenerComponent)GetComponent(GameComponentsLookup.PlayerWinListener); } }
    public bool hasPlayerWinListener { get { return HasComponent(GameComponentsLookup.PlayerWinListener); } }

    public void AddPlayerWinListener(System.Collections.Generic.List<IPlayerWinListener> newValue) {
        var index = GameComponentsLookup.PlayerWinListener;
        var component = CreateComponent<PlayerWinListenerComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplacePlayerWinListener(System.Collections.Generic.List<IPlayerWinListener> newValue) {
        var index = GameComponentsLookup.PlayerWinListener;
        var component = CreateComponent<PlayerWinListenerComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemovePlayerWinListener() {
        RemoveComponent(GameComponentsLookup.PlayerWinListener);
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

    static Entitas.IMatcher<GameEntity> _matcherPlayerWinListener;

    public static Entitas.IMatcher<GameEntity> PlayerWinListener {
        get {
            if (_matcherPlayerWinListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.PlayerWinListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherPlayerWinListener = matcher;
            }

            return _matcherPlayerWinListener;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public void AddPlayerWinListener(IPlayerWinListener value) {
        var listeners = hasPlayerWinListener
            ? playerWinListener.value
            : new System.Collections.Generic.List<IPlayerWinListener>();
        listeners.Add(value);
        ReplacePlayerWinListener(listeners);
    }

    public void RemovePlayerWinListener(IPlayerWinListener value, bool removeComponentWhenEmpty = true) {
        var listeners = playerWinListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemovePlayerWinListener();
        } else {
            ReplacePlayerWinListener(listeners);
        }
    }
}
