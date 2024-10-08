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
        productionStrategy = new InputStorageProductionStrategy(_advancedBuildingKeeper.InputStorages,_buildingConfig.RequiredResources);
    }

    public override bool IsStorageHandlerBusy()
    {
        return _outputStorageHandler.isBusy && _advancedBuildingKeeper._InputHandler.isBusy;
    }
}