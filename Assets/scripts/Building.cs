using UnityEngine;
using Zenject;

public abstract class Building : MonoBehaviour , IGameControllerTickable
{
    [SerializeField] protected Storage outputStorage;
    [SerializeField] protected StorageOutputHandler _outputStorageHandler;
    [Inject] protected GameController _gameController;
    protected IProductionStrategy productionStrategy;
    private float productionTimer;

    public bool can;
    
    public Storage OutputStorage => outputStorage;
    
    public abstract BuildingConfigSO Config { get; }

    protected virtual void Start()
    {
        productionTimer = Config.ProductionTime;
        outputStorage.Init(Config.ProducedResource);
        _outputStorageHandler.Init(outputStorage);
        
        _gameController.RegisterInTick(this);
    }

    public void Tick()
    {
        if(can )
            return;
     //   if(IsStorageHandlerBusy())
         //   return;
        
        if (productionStrategy.CanProduce(this))
        {
            productionTimer -= Time.deltaTime;
            if (productionTimer <= 0f)
            {
                productionStrategy.Produce(this);
                productionTimer = Config.ProductionTime; // Скидаємо таймер
            }
        }    
    }

    public abstract bool IsStorageHandlerBusy();

}



