using UnityEngine;

[CreateAssetMenu(fileName = "NewBuildingConfig", menuName = "Buildings/BuildingConfig")]
public class BuildingConfigSO : ScriptableObject
{
    public ResourceSO ProducedResource;
    public int ProductionAmount = 1;
    public float ProductionTime = 1f;
    public int StorageCapacity = 10;
}