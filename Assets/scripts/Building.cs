using UnityEngine;
using Zenject;

public abstract class Building : MonoBehaviour , IGameControllerTickable
{
    [SerializeField] protected Storage outputStorage;  // Вихідний склад
    [SerializeField] protected BuildingConfigSO config; // Конфігурація фабрики через ScriptableObject
    [Inject] protected GameController _gameController;
    protected IProductionStrategy productionStrategy;    // Стратегія виробництва

    public Storage OutputStorage => outputStorage;
    public BuildingConfigSO Config => config;

    private float productionTimer;

    protected virtual void Start()
    {
        productionTimer = config.ProductionTime;
        outputStorage.Init(config.ProducedResource, _gameController.PickUpAnimationTweenConfig);
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
                productionTimer = config.ProductionTime; // Скидаємо таймер
            }
        }    
    }
}