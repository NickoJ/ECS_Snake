using UnityEngine;
using UnityEngine.UI;
using Entitas.Unity;

public class GameOverController : MonoBehaviour, IPlayerWinListener, IPlayerLoseListener
{

    public Text text;

    private void Start()
    {
        var game = Contexts.sharedInstance.game;
        var entity = game.CreateEntity();
        entity.AddPlayerWinListener(this);
        entity.AddPlayerLoseListener(this);
        gameObject.Link(entity, game);
        text.text = string.Empty;
    }

    void IPlayerWinListener.OnPlayerWin(GameEntity entity)
    {
        text.text = "You win";
    }

    void IPlayerLoseListener.OnPlayerLose(GameEntity entity)
    {
        text.text = "You lose";
    }

}