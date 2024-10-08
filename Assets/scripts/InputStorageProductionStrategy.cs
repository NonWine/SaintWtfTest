using UnityEngine;

public class InputStorageProductionStrategy : IProductionStrategy
{
    private StorageInput[] _inputStorages;
    private ResourceSO[] _requiredResources;
    
    public InputStorageProductionStrategy(StorageInput[] inputStorages, ResourceSO[] requiredResources)
    {
        this._inputStorages = inputStorages;
        _requiredResources = requiredResources;
    }

    public bool CanProduce(Building building)
    {
        
        foreach (var storage in _inputStorages)
        {
            if (storage.CurrentAmount == 0)
                return false;
        }
        return building.OutputStorage.HasSpace();
    }

    public void Produce(Building building)
    {
        foreach (var storage in _inputStorages)
        {
            Debug.Log("ConsumeTimeUpdate");
            storage.TryConsume();
        }
        building.OutputStorage.Store();
     }
}
