using UnityEngine;

public class ShowWinnerNumber : MonoBehaviour
{
    [SerializeField] private NumberField numberField;

    void Awake()
    {
        // Optional: auto-assign if the NumberField is on the same object
        if (numberField == null)
            numberField = GetComponent<NumberField>();
    }

    void Start()
    {
        if (numberField != null)
        {
            numberField.SetNumber(WinnerData.winnerPlayerNumber);
        }
    }
}