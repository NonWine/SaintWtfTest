using UnityEngine;

public class ResourceStackSkin : MonoBehaviour
{
    [SerializeField] private MeshRenderer _meshRendererResourceView;
    [SerializeField] private MeshFilter _meshFilter;
    private ResourceObj _resourceObj;
    public GameObject ResourceBody => _meshRendererResourceView.gameObject;

    public ResourceObj ResourceObj => _resourceObj;
    
    public void SetUpResourceView(ResourceObj resourceObj)
    {
        _meshRendererResourceView = resourceObj.MeshRenderer;
        _meshFilter.mesh = resourceObj.MeshFilter.mesh;
        _resourceObj = resourceObj;
    }
    
}