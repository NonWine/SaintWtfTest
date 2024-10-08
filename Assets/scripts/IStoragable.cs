using System.Collections.Generic;

public interface IStoragable
{
    void Store();

    ResourceObj TryConsume();

    bool HasSpace();
    

    
    public ResourceSO ResourceSo { get; set; }
    
    public int Capacity { get; }
    
    public int CurrentAmount { get; }



    public List<ResourceObj> ResourceObjs { get; }
}