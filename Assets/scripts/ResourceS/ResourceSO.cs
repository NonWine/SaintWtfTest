using UnityEngine;

[CreateAssetMenu(fileName = "NewResource", menuName = "Resources/Resource")]
public class ResourceSO : ScriptableObject
{
    public ResourceType Type;
    public Sprite Icon;
    public Color Color;
    public ResourceObj Object;
}