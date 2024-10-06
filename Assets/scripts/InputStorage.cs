using System.Collections.Generic;
using UnityEngine;

public class InputStorage : MonoBehaviour , IStoragable
{
    private Dictionary<ResourceSO, int> resources = new Dictionary<ResourceSO, int>();

    private void Start()
    {
        resources = new Dictionary<ResourceSO, int>();
    }

    public void Store()
    {
        throw new System.NotImplementedException();
    }

    public GameObject TryConsume()
    {
        throw new System.NotImplementedException();
    }

    public void Consume()
    {
        throw new System.NotImplementedException();
    }

    public bool HasSpace()
    {
        throw new System.NotImplementedException();
    }
    
    public int GetResourceCount(ResourceType resourceType)
    {
        foreach (var keyValuePair in resources)
        {
            if (keyValuePair.Key.Type == resourceType)
                return keyValuePair.Value;
        }
    
        return 0;
    }
    
    public bool HasResource(ResourceSO resource, int amount)
    {
        return resources.ContainsKey(resource) && resources[resource] >= amount;
    }
}