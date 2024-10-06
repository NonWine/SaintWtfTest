using System;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public class PlayerController 
{ 
    private IMoveable _moveable;
    private IRotateable _rotateable;
    private IEntityAnimateable _entityAnimateable;
    
    public  PlayerController(IMoveable moveable,
        IRotateable rotateable,
        IEntityAnimateable entityAnimateable
        )
{
        _entityAnimateable = entityAnimateable;
        _moveable = moveable;
        _rotateable = rotateable;
    }

    public void Tick()
    {
        _moveable.Move();
        _rotateable.Rotate();
        _entityAnimateable.UpdateAnimator();
    }
}