using UnityEngine;

public class AdvancedBuildingKeeper : MonoBehaviour
{
    [SerializeField] private StorageInput[] inputStorage;
    [SerializeField] private StorageInputHandler _storageInputHandler;

    public StorageInputHandler _InputHandler;
    
    public StorageInput[] InputStorages => inputStorage;
    
    public void Init(ResourceSO[] resourceSos)
    {
        int i = 0;
        foreach (var storage in inputStorage)
        {
            storage.Init(resourceSos[i]);
            i++;
        }

        _storageInputHandler.Init(inputStorage);
    }


}

