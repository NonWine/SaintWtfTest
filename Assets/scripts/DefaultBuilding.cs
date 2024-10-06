public class DefaultBuilding : Building
{
    protected override void Start()
    {
        base.Start();
        // Використовуємо стратегію без вхідних складів
        productionStrategy = new NoInputStorageProductionStrategy();
    }
}