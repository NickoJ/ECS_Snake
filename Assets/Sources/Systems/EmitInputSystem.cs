using Entitas;
using UnityEngine;

public class EmitInputSystem : IInitializeSystem, IExecuteSystem
{

    private readonly InputContext context;

    private InputEntity upButton;
    private InputEntity rightButton;
    private InputEntity downButton;
    private InputEntity leftButton;

    public EmitInputSystem(InputContext context)
    {
        this.context = context;
    }

    public void Initialize()
    {
        context.isUpButton = true;
        upButton = context.upButtonEntity;

        context.isRightButton = true;
        rightButton = context.rightButtonEntity;

        context.isDownButton = true;
        downButton = context.downButtonEntity;

        context.isLeftButton = true;
        leftButton = context.leftButtonEntity;
    }

    public void Execute()
    {
        upButton.isButtonPressedDown = Input.GetKeyDown(KeyCode.UpArrow);
        rightButton.isButtonPressedDown = Input.GetKeyDown(KeyCode.RightArrow);
        downButton.isButtonPressedDown = Input.GetKeyDown(KeyCode.DownArrow);
        leftButton.isButtonPressedDown = Input.GetKeyDown(KeyCode.LeftArrow);
    }

}