﻿using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using Zenject;

public class PlayerResourceStack : MonoBehaviour
{
    [Inject] private GameController _gameController;
    [Inject] private ObjectPoolResources _objectPoolResources;
    [SerializeField] private List<ResourceStackSkin> collectedResources;

    private PickUpAnimationTween _animationTween => _gameController.PickUpAnimationTweenConfig;

    public List<ResourceStackSkin> AllResources => collectedResources.FindAll(x => x.gameObject.activeSelf);
    
    public bool HasSpace => collectedResources.Find(x => x.gameObject.activeSelf == false) != null;
    

    public bool HaveResource(ResourceType resourceType)
    {
        return  AllResources.Find(x =>
            x.gameObject.activeSelf && x.CurrentResource == resourceType);
    }
    
    private void OnValidate()
    {
        collectedResources = GetComponentsInChildren<ResourceStackSkin>(true).ToList();
    }

    public void AddResourceToStack(ResourceObj resource)
    {
        ResourceObj resourceObj =
            _objectPoolResources.SpawnResource(resource, resource.transform, Quaternion.identity);
        resourceObj.gameObject.SetActive(true);
        var lastIndex = collectedResources.FindIndex(x => x.gameObject.activeSelf == false);

        
        resourceObj.transform.DOJump(collectedResources[lastIndex ].transform.position, 
            _animationTween.JumpStrenght, _animationTween.JumpCount, _animationTween.Duration)
            .OnComplete(() =>
        {
            collectedResources[lastIndex].SetUpResourceView(resourceObj.ResourceType);
            collectedResources[lastIndex].gameObject.SetActive(true);
            resourceObj.gameObject.SetActive(false);
        });
    }
    public void RemoveResourceFromStack(ResourceObj resourceObj, IStoragable storagable)
    {
        if(storagable.HasSpace() == false)
            return;
        
        var resourceindex = AllResources.FindLastIndex(x => x.CurrentResource == resourceObj.ResourceType && x.gameObject.activeSelf);
        
        ResourceObj resource =
            _objectPoolResources.SpawnResource(resourceObj,  collectedResources[resourceindex].transform, Quaternion.identity);
        resource.gameObject.SetActive(true);
        collectedResources[resourceindex].gameObject.SetActive(false);
        resource.transform.DOMove(resourceObj.transform.position, 
               _animationTween.Duration)
            .OnComplete(() =>
            {
                resource.gameObject.SetActive(false);
                storagable.Store();
            });
        
        ShiftResourcesDown(resourceindex);

    }
    
    private void ShiftResourcesDown(int startIndex)
    {
        for (int i = startIndex; i < collectedResources.Count - 1; i++)
        {
            if (!collectedResources[i + 1].gameObject.activeSelf)
                break; 
        
            collectedResources[i].SetUpResourceView(collectedResources[i + 1].CurrentResource);
            collectedResources[i].gameObject.SetActive(true);
            collectedResources[i + 1].gameObject.SetActive(false);
        }
    }
}