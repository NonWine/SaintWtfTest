using System;
using UnityEngine;

public class ResourceObj : MonoBehaviour
{
    [field: SerializeField] public MeshRenderer MeshRenderer { get; private set; }
    
    [field: SerializeField] public MeshFilter MeshFilter { get; private set; }

    [field: SerializeField]   public ResourceType ResourceType { get; private set; }
    
    public Vector3 MeshScale => MeshRenderer.transform.localScale;
    
    public bool InStorage { get;  set; }

    private void OnEnable()
    {
        InStorage = true;
    }

    private void OnDisable()
    {
        InStorage = false;
    }
}