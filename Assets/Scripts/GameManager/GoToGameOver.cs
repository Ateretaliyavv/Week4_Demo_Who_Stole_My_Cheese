using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToGameOver : MonoBehaviour
{
    [Header("Players cheese counters")]
    [SerializeField] NumberFieldUI player1Counter;
    [SerializeField] NumberFieldUI player2Counter;

    [Header("Cheese settings")]
    [SerializeField] string cheeseTag = "Cheese";

    [Header("Scene settings")]
    [SerializeField] string gameOverSceneName = "GameOverScene";

    private bool gameOverTriggered = false;

    void Update()
    {
        if (gameOverTriggered)
            return;

        // 1. Check if there are any cheeses left in the maze
        GameObject[] remainingCheeses = GameObject.FindGameObjectsWithTag(cheeseTag);
        if (remainingCheeses.Length > 0)
        {
            // Still at least one cheese in the maze ? no Game Over yet
            return;
        }

        // 2. No cheeses left -> check how many cheeses each player has
        int p1 = (player1Counter != null) ? player1Counter.GetNumberUI() : 0;
        int p2 = (player2Counter != null) ? player2Counter.GetNumberUI() : 0;

        // 3. If nobody reached 4 cheeses -> Game Over
        if (p1 < 4 && p2 < 4)
        {
            gameOverTriggered = true;
            SceneManager.LoadScene(gameOverSceneName);
        }
    }
}
