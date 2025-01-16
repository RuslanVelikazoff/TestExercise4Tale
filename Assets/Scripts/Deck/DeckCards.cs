using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DeckCards : MonoBehaviour
{
    public static DeckCards Instance { get; private set; }

    [SerializeField] 
    private List<Card> deck;

    [SerializeField] 
    private DeckData deckData;

    private void Awake()
    {
        Instance = this;
        deck = new List<Card>(deckData.GetCards());
    }

    public void TakeCard()
    {
        if (deck.Count > 0)
        {
            int randomCard = Random.Range(0, deck.Count);
            PlayerDeck.Instance.TakeCard(deck[randomCard]);
            deck.RemoveAt(randomCard);

            if (deck.Count <= 0)
            {
                KneadDeck();
            }
        }
        else
        {
            Debug.Log("You have all the existing cards in your hands!");
        }
    }

    private void KneadDeck()
    {
        deck = DiscardDeck.Instance.GetDiscardDeck();
        DiscardDeck.Instance.ClearDiscardDeck();
        Debug.Log("Knead");
    }
}
