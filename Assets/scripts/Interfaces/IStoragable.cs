using System.Collections.Generic;

public interface IStoragable
{
    void Store();
    bool HasSpace();

    bool IsEmpty();
    
    ResourceObj TryConsume();
    
    public ResourceSO ResourceSo { get; set; }

    public List<ResourceStackSkin> FreeResourceObjPlace { get; }
}