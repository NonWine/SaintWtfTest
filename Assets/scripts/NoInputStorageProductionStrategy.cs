public class NoInputStorageProductionStrategy : IProductionStrategy
{
    public bool CanProduce(Building building)
    {
        // Перевіряємо лише наявність місця у вихідному складі
        return building.OutputStorage.HasSpace();
    }

    public void Produce(Building building)
    {
        // Виробляємо ресурс без використання вхідних ресурсів
        building.OutputStorage.Store();
    }
}