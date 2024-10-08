using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class StorageInputHandler : StorageHandler 
{

    private IStoragable[] _storagables;

    
    public  void Init(IStoragable[] storagable)
    {
        _storagables = storagable;
    }

    protected override IEnumerator AnimateResourceCollection(PlayerResourceStack player)
    {
        
            foreach (var storagable in _storagables)
            {
                if(player.HaveResource(storagable.ResourceSo.Type) && storagable.ResourceObjs.Count > 0)
                    foreach (var resource in storagable.ResourceObjs)
                    {

                            player.RemoveResourceFromStack(resource, storagable);
                            yield return new WaitForSeconds(0.1f);
                      
                            if(!player.HaveResource(storagable.ResourceSo.Type))
                                break;
                                
                            yield return new WaitUntil(() => storagable.ResourceObjs.Count > 0);
                    }

               

                yield return null;
            }

            isBusy = false;
            collectionCoroutine = null; 
    }



    
}
