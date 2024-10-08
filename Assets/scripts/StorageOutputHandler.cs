using System.Collections;
using DG.Tweening;
using UnityEngine;

public class StorageOutputHandler : StorageHandler
{
    private IStoragable _storagable;
    
    public  void Init(IStoragable storagable)
    {
        _storagable = storagable;
    }

    protected override IEnumerator AnimateResourceCollection(PlayerResourceStack player)
    {
        while (true)
        {
            if(player.HasSpace == false)
                yield break;
            
            ResourceObj resourceObj = _storagable.TryConsume();
            
            if (resourceObj == null)
            {
                yield return new WaitUntil(() => _storagable.HasSpace());
                continue;
            }
            
            player.AddResourceToStack(resourceObj);
            yield return new WaitForSeconds(0.3f); 
        }
        
        collectionCoroutine = null; 
    }


    
    
}