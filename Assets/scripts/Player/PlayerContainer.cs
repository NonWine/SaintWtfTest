using System;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class PlayerContainer : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private Transform _body;
    [SerializeField] private Animator _player;
    [SerializeField] private PlayerStats _playerStats;
    
    [field: SerializeField] public PlayerResourceStack PlayerResourceStack { get; private set; }
    
    [Inject] private Joystick _joystick;
    private Vector3 _direction;

    public Vector3 Direction
    {
        get;
        set;
    }

    public PlayerStats PlayerStats => _playerStats;
    
    public NavMeshAgent Agent => _navMeshAgent;
 
    public Transform Body => _body;

    public Joystick Joystick => _joystick;

    public Animator Animator => _player;

}
[System.Serializable]
public class PlayerStats
{
    public float RotateSpeed;
    public float MoveSpeed;
}