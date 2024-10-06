using UnityEngine;

public class Building2 : Building
{
    [SerializeField] private Storage inputStorage; // Вхідний склад

    protected override void Start()
    {
        base.Start();
        // Передаємо вхідний склад у стратегію виробництва
        productionStrategy = new NoInputStorageProductionStrategy();
    }
}