using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameController : MonoBehaviour
{
    [SerializeField] private PlayerContainer _playerContainerPrefab;
    [SerializeField] private CameraFollowing _cameraFollowing;
    [SerializeField] private Transform _spawnPoint;
    private List<IGameControllerTickable> _tickables = new List<IGameControllerTickable>();
    private DiContainer _diContainer;
    private PlayerContainer _playerContainer;
    private PlayerController _player;
    
    [field: SerializeField] public PickUpAnimationTween PickUpAnimationTweenConfig { get; private set; }

    [Inject]
    public void Construct( DiContainer diContainer)
    {
        _diContainer = diContainer;
    }

    private void Awake()
    {
        _playerContainer = _diContainer.InstantiatePrefabForComponent<PlayerContainer>(_playerContainerPrefab, _spawnPoint.transform.position, Quaternion.identity, null);
        _diContainer.BindInstance(_playerContainer).AsSingle().Lazy();

        _player = new PlayerController
        (
            new PlayerMoving(_playerContainer),
            new PlayerRotating(_playerContainer),
            new PlayerAnimator(_playerContainer)
        );

        _cameraFollowing.Init(_playerContainer.transform);
    }

    private void Update()
    {
        _player.Tick();
        _tickables.ForEach(x => x.Tick());
    }

    public void RegisterInTick(IGameControllerTickable gameControllerTickable)
    {
        _tickables.Add(gameControllerTickable);
    }
}

public interface IGameControllerTickable
{
    void Tick();
}