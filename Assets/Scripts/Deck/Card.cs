using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    [SerializeField] 
    private bool isDamageCard;
    [SerializeField] 
    private bool isHealthCard;
    [SerializeField] 
    private bool isArmourCard;

    [Space(13)]
    
    [SerializeField] 
    private string cardName;
    
    [Space(13)]
    
    [SerializeField] 
    private int amount;

    [Space(13)]
    
    [SerializeField] 
    private int cost;

    public bool IsDamageCard
    {
        get
        {
            return isDamageCard;
        }
    }
    
    public bool IsHealthCard
    {
        get
        {
            return isHealthCard;
        }
    }
    
    public bool IsArmourCard
    {
        get
        {
            return isArmourCard;
        }
    }

    public string CardName
    {
        get
        {
            return cardName;
        }
    }

    public int Amount
    {
        get
        {
            return amount;
        }
    }

    public int Cost
    {
        get
        {
            return cost;
        }
    }
}
