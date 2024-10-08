using System.Collections;
using UnityEngine;

public abstract class StorageHandler : MonoBehaviour, IPlayerTriggable
{
    
    protected Coroutine collectionCoroutine;

    public bool isBusy;


    protected abstract IEnumerator AnimateResourceCollection(PlayerResourceStack player);
    

    public  virtual void OnPlayerTriggerExit(PlayerContainer playerContainer)
    {
        if (collectionCoroutine != null)
        {
            isBusy = false;
            StopCoroutine(collectionCoroutine);
            collectionCoroutine = null; 
        }       
    }
    
    public virtual void OnPlayerTriggerEnter(PlayerContainer playerContainer)
    {
        if (collectionCoroutine == null)
        {
            isBusy = true;

            collectionCoroutine = StartCoroutine(AnimateResourceCollection(playerContainer.PlayerResourceStack));
        }
    }
}