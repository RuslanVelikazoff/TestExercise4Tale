using UnityEngine;
using Random = UnityEngine.Random;

public class TurnManager : MonoBehaviour
{
    [SerializeField]
    private bool turnPlayer = true;

    [Space(13)]
    
    [Header("Enemy")]
    [SerializeField] 
    private Enemy[] enemies;

    [Space(5)]
    
    [SerializeField] 
    private int minEnemyHealth;
    [SerializeField] 
    private int maxEnemyHealth;
    
    [Space(5)]
    
    [SerializeField] 
    private int minEnemyArmour;
    [SerializeField] 
    private int maxEnemyArmour;
    
    [Space(5)]
    
    [SerializeField] 
    private int minEnemyDamage;
    [SerializeField] 
    private int maxEnemyDamage;

    public void NextTurn()
    {
        if (turnPlayer)
        {
            GameManager.Instance.SelectEnemy(null);
            turnPlayer = false;
            EnemyTurn();
            EnergyManager.Instance.PlusEnergy(5);
            
            for (int i = 0; i < 5; i++)
            {
                DeckCards.Instance.TakeCard();
            }
        }
        else
        {
            turnPlayer = true;
        }
    }

    private void EnemyTurn()
    {
        Debug.Log("Enemy turn");
        for (int i = 0; i < enemies.Length; i++)
        {
            int enemyAction = Random.Range(0, 3);

            switch (enemyAction)
            {
                case 0:
                    int health = Random.Range(minEnemyHealth, maxEnemyHealth);
                    enemies[i].Health(health);
                    Debug.Log($"{i} enemy {health} health");
                    break;
                case 1:
                    int armour = Random.Range(minEnemyArmour, maxEnemyArmour);
                    enemies[i].AddArmour(armour);
                    Debug.Log($"{i} enemy {armour} armour");
                    break;
                case 2:
                    int damage = Random.Range(minEnemyDamage, maxEnemyDamage);
                    Character.Instance.DamagePlayer(damage);
                    Debug.Log($"{i} enemy {damage} damage");
                    break;
            }
        }
        
        NextTurn();
    }
}
