using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Storage : MonoBehaviour , IStoragable
{
    [SerializeField] protected List<ResourceObj> _visualResources;
    

    public int CurrentAmount => _visualResources.FindAll(x => x.gameObject.activeSelf).Count;


    public List<ResourceObj> ResourceObjs => _visualResources;

    public int Capacity => _visualResources.Count;
    
    public int LastVisualResourceIndex()
    {
        int index = _visualResources.FindLastIndex(x => x.gameObject.activeSelf);
        if (index == -1)
            index = 0;

        return index;
    } 
    
    public int FirstDisabledIndex()
    {
        int index = _visualResources.FindIndex(x => x.gameObject.activeSelf == false);
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
        return CurrentAmount < Capacity;
    }

    public virtual void Store()
    {
        if (!HasSpace())
            return;
        _visualResources[FirstDisabledIndex()].gameObject.SetActive(true);
    }

    public ResourceObj TryConsume()
    {
        if (CurrentAmount > 0)
        {
            var obj = _visualResources[LastVisualResourceIndex()];
            _visualResources[LastVisualResourceIndex()].gameObject.SetActive(false);
            return obj;
        }

        return null;
    }

    public ResourceSO ResourceSo { get; set; }
}