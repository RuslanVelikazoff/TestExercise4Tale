using System.Collections.Generic;
using UnityEngine;

public class PlayerDeck : MonoBehaviour
{
    public static PlayerDeck Instance { get; private set; }

    [SerializeField]
    private GameObject cardPrefab;

    [SerializeField] 
    private List<GameObject> cardsObjects = new List<GameObject>();
    [SerializeField] 
    private List<Card> cards = new List<Card>();

    [SerializeField] 
    private Canvas canvas;

    private void Awake()
    {
        Instance = this;
    }

    private void SpawnCards()
    {
        ResetCards();
        for (int i = 0; i < cards.Count; i++)
        {
            var prefab = Instantiate(cardPrefab, transform.position, Quaternion.identity);
            prefab.transform.SetParent(canvas.transform);
            prefab.transform.localScale = new Vector3(1, 1, 1);
            prefab.transform.SetParent(this.gameObject.transform);
            cardsObjects.Add(prefab);
            prefab.GetComponent<CardPrefab>().SpawnPrefab(cards[i], i);
        }
    }

    public void TakeCard(Card card)
    {
        cards.Add(card);
        SpawnCards();
    }

    public void OutCard(int index)
    {
        cards.RemoveAt(index);
        SpawnCards();
    }

    private void ResetCards()
    {
        if (cardsObjects.Count != 0)
        {
            for (int i = 0; i < cardsObjects.Count; i++)
            {
                Destroy(cardsObjects[i]);
                cardsObjects.RemoveAt(i);
                ResetCards();
            }
        }
    }
}
