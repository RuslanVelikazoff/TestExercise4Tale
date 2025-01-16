using TMPro;
using UnityEngine;

public class EnergyManager : MonoBehaviour
{
    public static EnergyManager Instance { get; private set; }

    [SerializeField] 
    private TextMeshProUGUI energyText;
    [SerializeField] 
    private int energy;

    private void Awake()
    {
        Instance = this;
        UpdateEnergyText();
    }

    private void UpdateEnergyText()
    {
        energyText.text = energy.ToString();
    }

    public void PlusEnergy(int amount)
    {
        energy += amount;
        UpdateEnergyText();
    }

    public void MinusEnergy(int amount)
    {
        energy -= amount;
        UpdateEnergyText();
    }

    public int GetEnergyAmount()
    {
        return energy;
    }
}
