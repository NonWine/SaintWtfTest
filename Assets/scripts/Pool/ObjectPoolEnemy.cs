using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ObjectPoolResources
{
    [Inject] private IFactory<ResourceObj> _resorucesFactory;
    public  List<ResourceObj> _InActiveUnits = new List<ResourceObj>();
    
    public  void ClearPool() => _InActiveUnits.Clear();
    
    private ResourceObj TryResetFromPool(ResourceType resourceType)
    {
        foreach (var resourceObj in _InActiveUnits)
        {
            if (resourceObj.gameObject.activeSelf == false && resourceObj.ResourceType == resourceType)
            {
                return resourceObj;
            }
        }
    
        return null;
    }
    
    
    
    public ResourceObj SpawnResource(ResourceObj resourceObj, Transform pos, Quaternion rotation)
    {
        var NewUnit = TryResetFromPool(resourceObj.ResourceType);
        if (NewUnit != null)
        {
            NewUnit.transform.position = pos.position;
            NewUnit.transform.rotation = rotation;
            NewUnit.transform.localScale = new Vector3(1f, 1f, 1f);
            return NewUnit;
        }
    
        NewUnit = _resorucesFactory.Create(resourceObj, pos, rotation, null);
        _InActiveUnits.Add(NewUnit);
    
        NewUnit.PoolResources = this;
        return NewUnit;
    }

}