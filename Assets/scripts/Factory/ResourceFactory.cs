using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ResourceFactory : IFactory<ResourceObj>
{
     private DiContainer _diContainer;
     private List<ResourceObj> _resourceObjs;


     public ResourceFactory(DiContainer diContainer, List<ResourceObj> resourceObjs)
     {
         _diContainer = diContainer;
         _resourceObjs = resourceObjs;
     }
     
    public ResourceObj Create(ResourceObj Object, Transform transform, Quaternion rotation, Transform parent)
    {
        var resource = GetResource(Object.ResourceType);
        var spawnObj =
            _diContainer.InstantiatePrefabForComponent<ResourceObj>(resource, transform.position, rotation, parent);
        return spawnObj;
    }

    public ResourceObj GetResource(ResourceType resourceType)
    {
        foreach (var resourceObj in _resourceObjs)
        {
            if (resourceObj.ResourceType == resourceType)
                return resourceObj;
        }

        return null;
    }
}