using System.Collections.Generic;
using UnityEngine;

public class DiscardDeck : MonoBehaviour
{
    public static DiscardDeck Instance { get; private set; }

    [SerializeField] 
    private List<Card> deckDiscard = new List<Card>();

    private void Awake()
    {
        Instance = this;
        
    }

    public void CardToDiscard(Card card)
    {
        deckDiscard.Add(card);
    }

    public List<Card> GetDiscardDeck()
    {
        return deckDiscard;
    }

    public void ClearDiscardDeck()
    {
        deckDiscard.Clear();
    }
}
