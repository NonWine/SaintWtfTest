using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Storage : MonoBehaviour , IStoragable
{
    [SerializeField] protected List<ResourceStackSkin> _visualResources;
    
    public int CurrentAmount => _visualResources.FindAll(x => x.gameObject.activeSelf).Count;
    
    private void OnValidate()
    {
        _visualResources = GetComponentsInChildren<ResourceStackSkin>(true).ToList();
    }

    
    public List<ResourceStackSkin> FreeResourceObjPlace => _visualResources;

    public int Capacity => _visualResources.Count;
    
    public int LastVisuaEnablelResourceIndex()
    {
        int index = _visualResources.FindLastIndex(x => x.gameObject.activeSelf);
        if (index == -1)
            index = 0;

        return index;
    } 
    
    public int LastVisualDisableResourceIndex()
    {
        int index = _visualResources.FindIndex(x => x.gameObject.activeSelf == false);
        if (index == -1)
            index = _visualResources.Count - 1;

        return index;
    } 
    public void Init(ResourceSO resourceSo)
    {
        ResourceSo = resourceSo;
        
        foreach (var resourceStackSkin in _visualResources)
        {
            resourceStackSkin.SetUpResourceView(resourceSo.Type);
        }
    }
    
    public bool HasSpace()
    {
        return CurrentAmount < Capacity;
    }

    public bool IsEmpty()
    {
        return CurrentAmount == 0;
    }

    public virtual void Store()
    {
        if (!HasSpace())
            return;
        _visualResources[LastVisualDisableResourceIndex()].gameObject.SetActive(true);
    }

    public ResourceObj TryConsume()
    {
        if (CurrentAmount > 0)
        {
            var obj = _visualResources[LastVisuaEnablelResourceIndex()];
            _visualResources[LastVisuaEnablelResourceIndex()].gameObject.SetActive(false);
            return obj.CurrentResourceObj;
        }

        return null;
    }

    public ResourceSO ResourceSo { get; set; }
}