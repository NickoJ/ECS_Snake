using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private FoodController foodPrefab;
    [SerializeField] private SnakeSegmentController segmentPrefab;

    private Contexts contexts;
    private GameFeature gameFeature;
    private EventSystems eventFeature;

    private void Start()
    {
        contexts = Contexts.sharedInstance;
        gameFeature = new GameFeature(contexts, this.transform, foodPrefab, segmentPrefab);
        eventFeature = new EventSystems(contexts);
        gameFeature.Initialize();
        eventFeature.Initialize();
    }

    private void Update()
    {
        if (IsGameOver()) return;

        gameFeature.Execute();
        eventFeature.Execute();
        gameFeature.Cleanup();
        eventFeature.Cleanup();
    }

    private bool IsGameOver() { return contexts.game.isPlayerWin || contexts.game.isPlayerLose; }

}