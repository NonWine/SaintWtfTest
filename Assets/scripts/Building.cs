using UnityEngine;
using Zenject;

public abstract class Building : MonoBehaviour , IGameControllerTickable
{
    [SerializeField] protected Storage outputStorage;  
    [Inject] protected GameController _gameController;
    protected IProductionStrategy productionStrategy;
    private float productionTimer;
    
    public Storage OutputStorage => outputStorage;
    
    public abstract BuildingConfigSO Config { get; }

    protected virtual void Start()
    {
        productionTimer = Config.ProductionTime;
        outputStorage.Init(Config.ProducedResource, _gameController.PickUpAnimationTweenConfig);
        _gameController.RegisterInTick(this);
    }

    public void Tick()
    {
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

}