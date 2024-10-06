using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Storage : MonoBehaviour , IStoragable
{
    [SerializeField] private List<Transform> _visualResources;
    [SerializeField] private ResourceCollector _resourceCollector;
    public int CurrentAmount => _visualResources.FindAll(x => x.gameObject.activeSelf).Count;
    
    public int Capacity => _visualResources.Count;
    
    public int LastResourceIndex => _visualResources.FindLastIndex(x => x.gameObject.activeSelf);

    public void Init(ResourceSO resourceSo, PickUpAnimationTween pickUpAnimationTween)
    {
        _resourceCollector.Init(this,resourceSo, pickUpAnimationTween);
    }
    
    public bool HasSpace()
    {
        return CurrentAmount < Capacity;
    }

    public void Store()
    {
        if (!HasSpace())
            return;
        _visualResources[LastResourceIndex + 1].gameObject.SetActive(true);
    }

    public GameObject TryConsume()
    {
        if (CurrentAmount > 0)
        {
            var obj = _visualResources[LastResourceIndex].gameObject;
            _visualResources[LastResourceIndex].gameObject.SetActive(false);
            return obj;
        }

        return null;
    }

}