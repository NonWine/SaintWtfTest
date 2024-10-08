using UnityEngine;

[RequireComponent(typeof(AdvancedBuildingKeeper))]
public class AdvancedBuilding : Building
{
    [SerializeField] private AdvancedBuildingConfig _buildingConfig;
    [SerializeField] private AdvancedBuildingKeeper _advancedBuildingKeeper;
    public override BuildingConfigSO Config => _buildingConfig;

    protected override void Start()
    {
        base.Start();
        _advancedBuildingKeeper.Init(_buildingConfig.RequiredResources);
        _ProductionStrategy = new InputStorageProductionStrategy(_advancedBuildingKeeper.InputStorageses);
    }
    
}