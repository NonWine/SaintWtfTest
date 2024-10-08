using System;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public abstract class Building : MonoBehaviour , IGameControllerTickable
{
    [SerializeField] protected OutputStorage _OutputStorage;
    [SerializeField] protected StorageOutputHandler _OutputStorageHandler;
    [Inject] protected GameController _GameController;
    protected IProductionStrategy _ProductionStrategy;
    private float _productionTimer;
    
    public Storage OutputStorage => _OutputStorage;
    
    public abstract BuildingConfigSO Config { get; }

    protected virtual void Start()
    {
        _productionTimer = Config.ProductionTime;
        _OutputStorage.Init(Config.ProducedResource);
        _OutputStorageHandler.Init(_OutputStorage);
        _GameController.RegisterInTick(this);
    }

    private void OnValidate()
    {
        _OutputStorage = GetComponentInChildren<OutputStorage>();
    }

    public void Tick()
    {
        if (_ProductionStrategy.CanProduce(this))
        {
            _productionTimer -= Time.deltaTime;
            if (_productionTimer <= 0f)
            {
                _ProductionStrategy.Produce(this);
                _productionTimer = Config.ProductionTime; // Скидаємо таймер
            }
        }    
    }

}



