//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputContext {

    public InputEntity downButtonEntity { get { return GetGroup(InputMatcher.DownButton).GetSingleEntity(); } }

    public bool isDownButton {
        get { return downButtonEntity != null; }
        set {
            var entity = downButtonEntity;
            if (value != (entity != null)) {
                if (value) {
                    CreateEntity().isDownButton = true;
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
public partial class InputEntity {

    static readonly DownButtonComponent downButtonComponent = new DownButtonComponent();

    public bool isDownButton {
        get { return HasComponent(InputComponentsLookup.DownButton); }
        set {
            if (value != isDownButton) {
                var index = InputComponentsLookup.DownButton;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : downButtonComponent;

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
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherDownButton;

    public static Entitas.IMatcher<InputEntity> DownButton {
        get {
            if (_matcherDownButton == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.DownButton);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherDownButton = matcher;
            }

            return _matcherDownButton;
        }
    }
}
