using UnityEngine;

public class AdvancedBuilding : Building
{
    [SerializeField] private Storage[] inputStorage;
    [SerializeField] private AdvancedBuildingConfig _config;
    
    public override BuildingConfigSO Config => _config;
    
    protected override void Start()
    {
        base.Start();
        productionStrategy = new InputStorageProductionStrategy(inputStorage, _config.RequiredResources);
    }
    
}

