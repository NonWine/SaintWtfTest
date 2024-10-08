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
                if(player.HaveResource(storagable.ResourceSo.Type) && storagable.FreeResourceObjPlace.Count > 0)
                    foreach (var resource in storagable.FreeResourceObjPlace)
                    {
                        player.RemoveResourceFromStack(resource.CurrentResourceObj, storagable);
                      
                        if(!player.HaveResource(storagable.ResourceSo.Type))
                            break;
                                
                        yield return new WaitForSeconds(0.1f);
                        yield return new WaitUntil(() => storagable.FreeResourceObjPlace.Count > 0);
                    }

                yield return null;
            }
            collectionCoroutine = null; 
    }



    
}
