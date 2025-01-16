using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardPrefab : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI cardNameText;
    [SerializeField] 
    private TextMeshProUGUI costText;
    [SerializeField]
    private TextMeshProUGUI amountText;

    private int cardIndex;
    private Card card;

    public void SpawnPrefab(Card card, int cardIndex)
    {
        this.card = card;
        this.cardIndex = cardIndex;
        
        if (EnergyManager.Instance.GetEnergyAmount() >= card.Cost)
        {
            this.gameObject.GetComponent<Button>().interactable = true;
            this.gameObject.GetComponent<CanvasGroup>().alpha = 1f;
        }
        else
        {
            this.gameObject.GetComponent<Button>().interactable = false;
            this.gameObject.GetComponent<CanvasGroup>().alpha = .5f;
        }

        cardNameText.text = card.CardName;
        costText.text = card.Cost.ToString();
        amountText.text = card.Amount.ToString();

        SetCard();
    }

    private void SetCard()
    {
        Button cardButton = GetComponent<Button>();

        if (cardButton != null)
        {
            cardButton.onClick.RemoveAllListeners();
            cardButton.onClick.AddListener(() =>
            {
                CardAction();
            });
        }
    }

    private void CardAction()
    {
        if (card.IsArmourCard)
        {
            Character.Instance.AddArmour(card.Amount);
            EnergyManager.Instance.MinusEnergy(card.Cost);
            PlayerDeck.Instance.OutCard(cardIndex);
        }

        if (card.IsDamageCard)
        {
            if (GameManager.Instance.EnemySelected())
            {
                GameManager.Instance.GetSelectedEnemy().DamageEnemy(card.Amount);
                EnergyManager.Instance.MinusEnergy(card.Cost);
                PlayerDeck.Instance.OutCard(cardIndex);
            }
            else
            {
                Debug.Log("Tap on the opponent to select him, then tap on the card!");
            }
        }

        if (card.IsHealthCard)
        {
            Character.Instance.Health(card.Amount);
            EnergyManager.Instance.MinusEnergy(card.Cost);
            PlayerDeck.Instance.OutCard(cardIndex);
        }
    }
}
