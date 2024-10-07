using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using Zenject;

public class PlayerResourceStack : MonoBehaviour
{
    [Inject] private GameController _gameController;

    [SerializeField] private List<ResourceStackSkin> collectedResources;

    private PickUpAnimationTween _animationTween => _gameController.PickUpAnimationTweenConfig;

    public bool HasSpace => collectedResources.Find(x => x.gameObject.activeSelf == false) != null;
    
    private void OnValidate()
    {
        collectedResources = GetComponentsInChildren<ResourceStackSkin>(true).ToList();
    }

    public void AddResourceToStack(ResourceObj resource)
    {
        var lastIndex = collectedResources.FindIndex(x => x.gameObject.activeSelf == false);
       // if (lastIndex == -1)
         //   lastIndex = 0;
        
        resource.transform.DOJump(collectedResources[lastIndex ].transform.position, 
            _animationTween.JumpStrenght, _animationTween.JumpCount, _animationTween.Duration)
            .OnComplete(() =>
        {
            resource.gameObject.SetActive(false);
            collectedResources[lastIndex].SetUpResourceView(resource);
            collectedResources[lastIndex].gameObject.SetActive(true);
        });
    }

    // // Метод для видалення ресурсу з стека (наприклад, під час використання або доставки)
    // public GameObject RemoveResourceFromStack()
    // {
    //     if (collectedResources.Count > 0)
    //     {
    //         return collectedResources.Pop();
    //     }
    //     return null;
    // }
}