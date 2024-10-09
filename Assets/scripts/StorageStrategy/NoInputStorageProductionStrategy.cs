public class NoInputStorageProductionStrategy : IProductionStrategy
{
    
    public bool CanProduce(Building building)
    {
        return building.OutputStorage.HasSpace();
    }

    public void Produce(Building building)
    {
        building.OutputStorage.Store();
    }
    
}