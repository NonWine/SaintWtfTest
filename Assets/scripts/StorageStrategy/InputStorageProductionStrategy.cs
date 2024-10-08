using UnityEngine;

public class InputStorageProductionStrategy : IProductionStrategy
{
    private IStoragable[] _inputStorages;
    
    public InputStorageProductionStrategy(IStoragable[] inputStorages)
    {
        this._inputStorages = inputStorages;
    }

    public bool CanProduce(Building building)
    {
        
        foreach (var storage in _inputStorages)
        {
            if (storage.IsEmpty())
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
