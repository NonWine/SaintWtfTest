using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ObjectPoolInstaller : MonoInstaller
{
    [SerializeField] private List<ResourceObj> _resourceObjs;
    
    public override void InstallBindings()
    {
        Container.Bind<ObjectPoolResources>().FromNew().AsSingle();
        Container.BindInterfacesAndSelfTo<ResourceFactory>().FromInstance(new ResourceFactory(Container,_resourceObjs)).AsSingle();
    }
}