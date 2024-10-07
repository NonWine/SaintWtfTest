﻿using System.Collections;
using DG.Tweening;
using UnityEngine;

public class ResourceCollector : MonoBehaviour , IPlayerTriggable
{

    private Coroutine collectionCoroutine;
    private IStoragable _storagable;
    private ResourceSO _resourceSo;
    private PickUpAnimationTween _pickUpAnimationTween;
    
    public void Init(IStoragable storagable, ResourceSO resourceSo, PickUpAnimationTween pickUpAnimationTween)
    {
        _storagable = storagable;
        _resourceSo = resourceSo;
        _pickUpAnimationTween = pickUpAnimationTween;
    }
    
    private IEnumerator AnimateResourceCollection(Transform player)
    {
        while (true)
        {
            if(player.GetComponent<PlayerResourceStack>().HasSpace == false)
                yield break;
            
            GameObject resourcePosition = _storagable.TryConsume();
            if (resourcePosition == null)
            {
                yield return new WaitUntil(() => _storagable.HasSpace());
                continue;
            }


            ResourceObj resourceObj =
                Instantiate(_resourceSo.Object, resourcePosition.transform.position, Quaternion.identity);
          //  resourceObj.transform.localScale = resourcePosition.transform.localScale;
            AnimateSingleResource(resourceObj, player);
            yield return new WaitForSeconds(0.3f); 
        }
        
        collectionCoroutine = null; 
    }

    private void AnimateSingleResource(ResourceObj resource, Transform target)
    {
        target.GetComponent<PlayerResourceStack>().AddResourceToStack(resource);
    }

    // private void OnResourceCollected(PlayerResourceStack resource)
    // {
    //     resource.AddResourceToStack();
    // }
    

    public void OnPlayerTriggerEnter(PlayerContainer playerContainer)
    {
        if (collectionCoroutine == null && playerContainer.PlayerResourceStack.HasSpace)
        {
            collectionCoroutine = StartCoroutine(AnimateResourceCollection(playerContainer.transform));
        }
    }

    public void OnPlayerTriggerExit(PlayerContainer playerContainer)
    {
        if (collectionCoroutine != null)
        {
            StopCoroutine(collectionCoroutine);
            collectionCoroutine = null; 
        }    
    }
}