using UnityEngine;
using TMPro;

public class LifeDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthText;

    public void LifeUpdate(int playerHealth)
    {
        healthText.text = $"Lives: {playerHealth}";
    }
}
