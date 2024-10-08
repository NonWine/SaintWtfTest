using System.Collections.Generic;
using UnityEngine;

public class StorageInput : MonoBehaviour, IStoragable
{
    [SerializeField] protected List<ResourceObj> _visualResources;
    
    public int CurrentAmount => _visualResources.FindAll(x => x.gameObject.activeSelf).Count;
    
    public int Capacity => _visualResources.Count;
    

    public int LastVisualResourceIndex()
    {
        int index = _visualResources.FindIndex(x => x.gameObject.activeSelf == false);
        if (index == -1)
            index = _visualResources.Count -1;

        return index;
    } 
    
    public int LastVisuaEnablelResourceIndex()
    {
        int index = _visualResources.FindLastIndex(x => x.gameObject.activeSelf == true);
        if (index == -1)
            index = _visualResources.Count - 1;

        return index;
    }
        

    
    public void Init(ResourceSO resourceSo)
    {
        ResourceSo = resourceSo;
    }
    
    public bool HasSpace()
    {
        Debug.Log(CurrentAmount + "On HasSpace");
        return CurrentAmount < Capacity;
    }
    

    public virtual void Store()
    {
        _visualResources[LastVisualResourceIndex() ].gameObject.SetActive(true);
    }
    
    
    public ResourceObj TryConsume()
    {
        
        if (CurrentAmount > 0)
        {
            var obj = _visualResources[LastVisuaEnablelResourceIndex()];
            _visualResources[LastVisuaEnablelResourceIndex()].gameObject.SetActive(false);
            _visualResources[LastVisuaEnablelResourceIndex()].InStorage = false;
            Debug.Log("Consume");

            return obj;
        }

        return null;
    }
    

    public List<ResourceObj> ResourceObjs => _visualResources.FindAll(x => x.gameObject.activeSelf == false);

    
    public ResourceSO ResourceSo { get; set; }
}