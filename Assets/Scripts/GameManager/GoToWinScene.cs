using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToWinScene : MonoBehaviour
{
    [SerializeField] NumberFieldUI player1Counter;
    [SerializeField] NumberFieldUI player2Counter;

    [SerializeField] string winSceneName = "Win-Scene";

    void Update()
    {
        if (player1Counter.GetNumberUI() >= 4)
        {
            WinnerData.winnerPlayerNumber = 1;
            SceneManager.LoadScene(winSceneName);
        }

        if (player2Counter.GetNumberUI() >= 4)
        {
            WinnerData.winnerPlayerNumber = 2;
            SceneManager.LoadScene(winSceneName);
        }
    }
}
