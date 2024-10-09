using System;
using UnityEngine;
using UnityEngine.Serialization;

public class AdvancedBuildingKeeper : MonoBehaviour
{
    [SerializeField] private InputStorage[] _inputStorages;
    [SerializeField] private StorageInputHandler _storageInputHandler;
    
    public InputStorage[] InputStorageses => _inputStorages;
    
    public void Init(ResourceSO[] resourceSos)
    {
        int i = 0;
        foreach (var storage in _inputStorages)
        {
            storage.Init(resourceSos[i]);
            i++;
        }

        _storageInputHandler.Init(_inputStorages);
    }

    private void OnValidate()
    {
        _inputStorages = GetComponentsInChildren<InputStorage>();
    }
}

