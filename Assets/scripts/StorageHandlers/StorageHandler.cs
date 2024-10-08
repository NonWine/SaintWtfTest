using System.Collections;
using UnityEngine;

public abstract class StorageHandler : MonoBehaviour, IPlayerTriggable
{
    protected Coroutine collectionCoroutine;
    
    protected abstract IEnumerator AnimateResourceCollection(PlayerResourceStack player);
    

    public  virtual void OnPlayerTriggerExit(PlayerContainer playerContainer)
    {
        if (collectionCoroutine != null)
        {
            StopCoroutine(collectionCoroutine);
            collectionCoroutine = null; 
        }       
    }
    
    public virtual void OnPlayerTriggerEnter(PlayerContainer playerContainer)
    {
        if (collectionCoroutine == null)
        {
            collectionCoroutine = StartCoroutine(AnimateResourceCollection(playerContainer.PlayerResourceStack));
        }
    }
}