using System.Collections.Generic;
using UnityEngine;

// public class InputStorage :  Storage, IStoragable
// {
//     
//     public int LastVisualResourceIndex => Mathf.Max(0, _visualResources.FindLastIndex(x => x.gameObject.activeSelf));
//
//
//     public override void Store()
//     {
//         if (!HasSpace())
//             return;
//         _visualResources[LastVisualResourceIndex + 1].gameObject.SetActive(true);
//         
//     }
//
//     private void Start()
//     {
//         _resources = _visualResources;
//     }
//
//     public void AddToStoreManually()
//     {
//
//         _resources[LastResourceIndex + 1].InStorage = true;
//     }
//
//     public ResourceObj TryConsume()
//     {
//         if (CurrentAmount > 0)
//         {
//             var obj = _visualResources[LastResourceIndex];
//             _visualResources[LastResourceIndex].gameObject.SetActive(false);
//             _resources[LastResourceIndex].InStorage = false;
//             return obj;
//         }
//         return null;
//
//     }
//
//     public bool HasSpace()
//     {
//         return CurrentAmount < Capacity;
//     }
//
//     public ResourceObj AvaiablePlace()
//     {
//         return _resources[LastResourceIndex];
//     }
//
//     public ResourceSO ResourceSo { get; set; }
//     public int Capacity { get; }
//     public int CurrentAmount { get; }
// }