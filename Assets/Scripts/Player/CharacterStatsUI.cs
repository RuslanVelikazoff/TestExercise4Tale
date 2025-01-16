using UnityEngine;
using UnityEngine.UI;

public class CharacterStatsUI : MonoBehaviour
{
    [SerializeField] 
    private Slider healthSlider;
    [SerializeField]
    private Slider armourSlider;
    [SerializeField] 
    private GameObject armour;

    public void InitializeStatsUI(int maxHealth, int maxArmour)
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;

        armourSlider.maxValue = maxArmour;
        UpdateArmourBar(0);

    }

    public void UpdateHealthBar(int currentHealth)
    {
        healthSlider.value = currentHealth;
    }

    public void UpdateArmourBar(int currentArmour)
    {
        armourSlider.value = currentArmour;
        if (currentArmour <= 0)
        {
            armour.SetActive(false);
        }
        else
        {
            armour.SetActive(true);
        }
    }
}
