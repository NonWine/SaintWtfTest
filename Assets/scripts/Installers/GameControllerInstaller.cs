﻿using UnityEngine;
using Zenject;

public class GameControllerInstaller : MonoInstaller
{
    [SerializeField] private GameController _gameController;
    
    public override void InstallBindings()
    {
        Container.BindInstance(_gameController).AsSingle().NonLazy();
    }
}