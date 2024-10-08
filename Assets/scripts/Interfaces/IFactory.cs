using UnityEngine;

public interface IFactory<T>
{
    
    T Create(T Object, Transform transform, Quaternion rotation, Transform parent);
}