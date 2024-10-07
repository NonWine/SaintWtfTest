using UnityEngine;

public class ResourceObj : MonoBehaviour
{
    [field: SerializeField] public MeshRenderer MeshRenderer { get; private set; }
    
    [field: SerializeField] public MeshFilter MeshFilter { get; private set; }

    public Vector3 MeshScale => MeshRenderer.transform.localScale;
    

}