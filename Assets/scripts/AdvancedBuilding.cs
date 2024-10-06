using UnityEngine;

public class AdvancedBuilding : Building
{
    [SerializeField] protected Storage[] inputStorages; // Масив вхідних складів

    protected override void Start()
    {
        base.Start();
        // Встановлюємо стратегію, яка працює з вхідними складами
        productionStrategy = new InputStorageProductionStrategy(inputStorages);
    }
}