using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class StorageReceiver : MonoBehaviour , IPlayerTriggable
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
            GameObject resourcePosition = _storagable.TryConsume();
            if (resourcePosition == null)
            {
                yield return new WaitUntil(() => _storagable.HasSpace());
                continue;
            }
            GameObject resourceObj =
                Instantiate(_resourceSo.Object.gameObject, resourcePosition.transform.position, Quaternion.identity);
            resourceObj.transform.localScale = resourcePosition.transform.localScale;
            AnimateSingleResource(resourceObj.transform, player);
            yield return new WaitForSeconds(0.3f); 
        }
        
        collectionCoroutine = null; 
    }

    private void AnimateSingleResource(Transform resource, Transform target)
    {
        resource.DOJump(target.position, _pickUpAnimationTween.JumpStrenght,_pickUpAnimationTween.JumpCount,_pickUpAnimationTween.Duration)
            .SetEase(_pickUpAnimationTween.Ease)
            .OnComplete(() => OnResourceCollected(resource));
    }

    private void OnResourceCollected(Transform resource)
    {
        
        Destroy(resource.gameObject);
    }
    

    public void OnPlayerTriggerEnter(PlayerContainer playerContainer)
    {
        if (collectionCoroutine == null)
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