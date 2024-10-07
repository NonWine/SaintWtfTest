using UnityEngine;

public class ResourceStackSkin : MonoBehaviour
{
    [SerializeField] private MeshRenderer _meshRendererResourceView;
    [SerializeField] private MeshFilter _meshFilter;

    public GameObject ResourceBody => _meshRendererResourceView.gameObject;
    
    public void SetUpResourceView(ResourceObj resourceObj)
    {
        _meshRendererResourceView = resourceObj.MeshRenderer;
        _meshFilter.mesh = resourceObj.MeshFilter.mesh;
    }
    
}