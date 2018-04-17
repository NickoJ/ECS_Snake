using Entitas;
using Entitas.CodeGeneration.Attributes;

[Input, Unique] public class UpButtonComponent : IComponent {}
[Input, Unique] public class RightButtonComponent : IComponent {}
[Input, Unique] public class DownButtonComponent : IComponent {}
[Input, Unique] public class LeftButtonComponent : IComponent {}

[Input] public class ButtonPressedDownComponent : IComponent {}