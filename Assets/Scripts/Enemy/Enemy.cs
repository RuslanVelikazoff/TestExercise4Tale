using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [Header("Health")]
    [SerializeField]
    private int maxHealth;
    private int currentHealth;
    
    [Space(13)]
    
    [Header("Armour")]
    [SerializeField]
    private int maxArmour;
    private int currentArmour;

    [Space(13)]
    
    [SerializeField] 
    private CharacterStatsUI statsUI;

    private void Awake()
    {
        currentHealth = maxHealth;
        currentArmour = 0;
        
        statsUI.InitializeStatsUI(maxHealth, maxArmour);
    }

    public void DamagePlayer(int damage)
    {
        if (currentArmour == 0)
        {
            currentHealth -= damage;
            
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                //Kill
            }
        }
        else
        {
            if (currentArmour - damage <= 0)
            {
                currentHealth -= currentArmour - damage;
                currentArmour = 0;
                if (currentHealth <= 0)
                {
                    currentHealth = 0;
                    //Kill
                }
            }
        }
        
        statsUI.UpdateHealthBar(currentHealth);
        statsUI.UpdateArmourBar(currentArmour);
    }

    public void Health(int health)
    {
        if (currentHealth + health >= maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += health;
        }
        
        statsUI.UpdateHealthBar(currentHealth);
    }

    public void AddArmour(int armour)
    {
        if (currentArmour + armour >= maxArmour)
        {
            currentArmour = maxArmour;
        }
        else
        {
            currentArmour += armour;
        }
        
        statsUI.UpdateArmourBar(currentArmour);
    }

    public void SelectEnemy()
    {
        Button selectEnemy = GetComponent<Button>();

        if (selectEnemy != null)
        {
            selectEnemy.onClick.RemoveAllListeners();
            selectEnemy.onClick.AddListener(() =>
            {
                //SelectEnemy
            });
        }
    }
}
