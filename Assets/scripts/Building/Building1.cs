using UnityEngine;

public class Building1 : Building
{
    [SerializeField] private BuildingConfigSO _buildingConfig;
    
    public override BuildingConfigSO Config => _buildingConfig;

    protected override void Start()
    {
        base.Start();
        _ProductionStrategy = new NoInputStorageProductionStrategy();
    }
}