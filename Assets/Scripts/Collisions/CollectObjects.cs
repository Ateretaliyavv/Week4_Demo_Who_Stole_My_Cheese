using TMPro;
using UnityEngine;

public class CollectObjects : MonoBehaviour
{
    [SerializeField] [Tooltip("Cheese counter UI text")]
    TextMeshProUGUI CheeseCounterText;

    [SerializeField] string triggeringTag;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(triggeringTag))
            return;

        // Get the amount of cheese from the NumberField on the cheese object
        NumberField cheeseAmount = other.GetComponentInChildren<NumberField>();

        if (cheeseAmount != null)
        {
            int amount = cheeseAmount.GetNumber();

            // Get the NumberFieldUI component on the UI text
            NumberFieldUI uiCounter = CheeseCounterText.GetComponent<NumberFieldUI>();

            if (uiCounter != null)
            {
                uiCounter.AddNumberUI(amount);
            }
        }

        // Remove the collected cheese from the scene
        Destroy(other.gameObject);
    }
}
