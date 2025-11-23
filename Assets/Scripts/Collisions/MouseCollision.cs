using TMPro;
using UnityEngine;

public class MouseCollision : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Cheese counter UI text")]
    TextMeshProUGUI CheeseCounterText;

    [SerializeField]
    [Tooltip("Traps counter UI text")]
    TextMeshProUGUI TrapCounterText;

    [SerializeField] string triggeringTag;
    [SerializeField] int CheeseKgToSub = 1;
    [SerializeField] int TrapsToSub = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(triggeringTag))
            return;

        // Get the NumberFieldUI component on the UI text
        NumberFieldUI uiCounter = CheeseCounterText.GetComponent<NumberFieldUI>();
        NumberFieldUI uiTrapCounter = TrapCounterText.GetComponent<NumberFieldUI>();

        if (uiTrapCounter.GetNumberUI() > 0)
        {
            uiTrapCounter.SetNumberUI(uiTrapCounter.GetNumberUI() - TrapsToSub);
        }
        else
        {
            if (uiCounter.GetNumberUI() != 0)
            {
                int numberToSub = uiCounter.GetNumberUI() - CheeseKgToSub;
                uiCounter.SetNumberUI(numberToSub);
            }
        }
    }
}
