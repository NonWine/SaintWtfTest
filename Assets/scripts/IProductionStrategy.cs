public interface IProductionStrategy
{
    bool CanProduce(Building building);
    void Produce(Building building);
}