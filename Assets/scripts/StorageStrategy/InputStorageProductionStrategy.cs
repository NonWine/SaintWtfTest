using UnityEngine;

public class InputStorageProductionStrategy : IProductionStrategy
{
    private InputStorage[] _inputStorages;

    
    public InputStorageProductionStrategy(InputStorage[] inputStorages )
    {
        this._inputStorages = inputStorages;

        
    }

    public bool CanProduce(Building building)
    {
        
        return !CheckStoragesForEmpty() && building.OutputStorage.HasSpace();
    }

    private bool CheckStoragesForEmpty()
    {
        foreach (var storage in _inputStorages)
        {
            if (storage.IsEmpty())
                return true;
        }

        return false;
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

    public void OnDestroy()
    {
        
    }
}



