using UnityEngine;

public interface IStoragable
{
    void Store();

    GameObject TryConsume();

    bool HasSpace();
}