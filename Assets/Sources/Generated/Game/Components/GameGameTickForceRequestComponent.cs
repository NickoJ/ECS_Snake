//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity gameTickForceRequestEntity { get { return GetGroup(GameMatcher.GameTickForceRequest).GetSingleEntity(); } }

    public bool isGameTickForceRequest {
        get { return gameTickForceRequestEntity != null; }
        set {
            var entity = gameTickForceRequestEntity;
            if (value != (entity != null)) {
                if (value) {
                    CreateEntity().isGameTickForceRequest = true;
                } else {
                    entity.Destroy();
                }
            }
        }
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

    static readonly GameTickForceRequestComponent gameTickForceRequestComponent = new GameTickForceRequestComponent();

    public bool isGameTickForceRequest {
        get { return HasComponent(GameComponentsLookup.GameTickForceRequest); }
        set {
            if (value != isGameTickForceRequest) {
                var index = GameComponentsLookup.GameTickForceRequest;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : gameTickForceRequestComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
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

    static Entitas.IMatcher<GameEntity> _matcherGameTickForceRequest;

    public static Entitas.IMatcher<GameEntity> GameTickForceRequest {
        get {
            if (_matcherGameTickForceRequest == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.GameTickForceRequest);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherGameTickForceRequest = matcher;
            }

            return _matcherGameTickForceRequest;
        }
    }
}
