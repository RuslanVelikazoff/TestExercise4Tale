using UnityEngine;

public class Character : MonoBehaviour
{
    public static Character Instance { get; private set; }

    [Header("Health")]
    [SerializeField]
    private int maxHealth;
    [SerializeField]
    private int currentHealth;
    
    [Space(13)]
    
    [Header("Armour")]
    [SerializeField]
    private int maxArmour;
    [SerializeField]
    private int currentArmour;

    [Space(13)]
    
    [SerializeField] 
    private CharacterStatsUI statsUI;

    private void Awake()
    {
        Instance = this;
        
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
                GameManager.Instance.LoseGame();
            }
        }
        else
        {
            currentArmour -= damage;
            
            if (currentArmour <= 0)
            {
                currentHealth += currentArmour;
                currentArmour = 0;
                if (currentHealth <= 0)
                {
                    currentHealth = 0;
                    Destroy(this.gameObject);
                    GameManager.Instance.KillEnemy();
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
}
