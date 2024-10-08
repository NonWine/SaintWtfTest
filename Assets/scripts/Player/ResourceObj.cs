using System;
using UnityEngine;

public class ResourceObj : MonoBehaviour
{
    [field: SerializeField]   public ResourceType ResourceType { get; private set; }

    public ObjectPoolResources PoolResources { get; set; }
}