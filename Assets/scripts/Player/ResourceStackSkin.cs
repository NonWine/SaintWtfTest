using System.Collections.Generic;
using UnityEngine;

public class ResourceStackSkin : MonoBehaviour
{
    [SerializeField] private List<ResourceObj> _resourceObjs;

    public ResourceType CurrentResource { get; private set; }
    
    public ResourceObj CurrentResourceObj { get; private set; }
    
    public void SetUpResourceView(ResourceType ResourceType)
    {
        foreach (var resourceObj in _resourceObjs)
        {
            resourceObj.gameObject.SetActive(false);
            if (resourceObj.ResourceType == ResourceType)
            {
                resourceObj.gameObject.SetActive(true);
                CurrentResourceObj = resourceObj;
                CurrentResource = resourceObj.ResourceType;
            }
        }
    }
    
    
}