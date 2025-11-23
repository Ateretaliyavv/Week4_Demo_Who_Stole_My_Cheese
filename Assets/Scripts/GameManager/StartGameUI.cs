using UnityEngine;
using UnityEngine.EventSystems;

public class StartGameUI : MonoBehaviour
{
    [SerializeField] GameObject startPanel;

    // Movement scripts for both players
    [SerializeField] PlayerMover player1MoveScript;
    [SerializeField] PlayerMover player2MoveScript;

    void Start()
    {
        // Show the start panel and block movement at the beginning
        if (startPanel != null)
            startPanel.SetActive(true);

        SetPlayersCanMove(false);
    }

    // Called by the "OK" button
    public void OnClickOk()
    {
        if (startPanel != null)
            startPanel.SetActive(false);

        SetPlayersCanMove(true);
    }

    private void SetPlayersCanMove(bool canMove)
    {
        if (player1MoveScript != null)
            player1MoveScript.canMove = canMove;

        if (player2MoveScript != null)
            player2MoveScript.canMove = canMove;
    }
}
