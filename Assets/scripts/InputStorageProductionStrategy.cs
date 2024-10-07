using UnityEngine;

public class InputStorageProductionStrategy : IProductionStrategy
{
    private Storage[] _inputStorages;
    private ResourceSO[] _requiredResources;
    
    public InputStorageProductionStrategy(Storage[] inputStorages, ResourceSO[] requiredResources)
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
            storage.TryConsume();
        }
        building.OutputStorage.Store();
     }
}
