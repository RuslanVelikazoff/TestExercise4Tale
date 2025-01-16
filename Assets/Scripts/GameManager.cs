using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] 
    private Enemy selectedEnemy;

    [SerializeField] 
    private int enemyAmount;
    

    private void Awake()
    {
        Instance = this;
    }

    #region Enemy

    public void SelectEnemy(Enemy enemy)
    {
        selectedEnemy = enemy;
    }

    public Enemy GetSelectedEnemy()
    {
        return selectedEnemy;
    }

    public bool EnemySelected()
    {
        if (selectedEnemy != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void KillEnemy()
    {
        enemyAmount--;

        if (enemyAmount == 0)
        {
            Debug.Log("Win");
        }
    }

    #endregion
}
