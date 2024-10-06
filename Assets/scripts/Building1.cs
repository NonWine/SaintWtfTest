public class Building1 : Building
{
    protected override void Start()
    {
        base.Start();
        productionStrategy = new NoInputStorageProductionStrategy();
    }
}