using System.Collections;
using DG.Tweening;
using UnityEngine;

public class ResourceCollector : MonoBehaviour , IPlayerTriggable
{
    [SerializeField] private float animationDuration = 0.3f; 
    [SerializeField] private float delayBetweenResources = 0.3f; 
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
                Instantiate(_resourceSo.Object, resourcePosition.transform.position, Quaternion.identity);
            resourceObj.transform.localScale = resourcePosition.transform.localScale;
            AnimateSingleResource(resourceObj.transform, player);
            yield return new WaitForSeconds(delayBetweenResources); 
        }
        
        collectionCoroutine = null; 
    }

    private void AnimateSingleResource(Transform resource, Transform target)
    {
        resource.DOJump(target.position, _pickUpAnimationTween.JumpStrenght,_pickUpAnimationTween.JumpCount,animationDuration)
            .SetEase(_pickUpAnimationTween.Ease)
            .OnComplete(() => OnResourceCollected(resource));
    }

    private void OnResourceCollected(Transform resource)
    {
        
        Destroy(resource.gameObject);
    }
    

    public void OnPlayerTriggerEnter(PlayerTrigger playerContainer)
    {
        if (collectionCoroutine == null)
        {
            collectionCoroutine = StartCoroutine(AnimateResourceCollection(playerContainer.transform));
        }
    }

    public void OnPlayerTriggerExit(PlayerTrigger playerContainer)
    {
        if (collectionCoroutine != null)
        {
            StopCoroutine(collectionCoroutine);
            collectionCoroutine = null; 
        }    
    }
}