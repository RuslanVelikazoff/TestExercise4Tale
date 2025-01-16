using System.Collections.Generic;
using UnityEngine;

public class DeckData : MonoBehaviour
{
    [SerializeField]
    private List<Card> cards;

    public List<Card> GetCards()
    {
        return cards;
    }
}
