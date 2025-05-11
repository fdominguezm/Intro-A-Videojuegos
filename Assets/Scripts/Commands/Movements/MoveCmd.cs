using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCommand : ICommand
{
    private readonly IMovable _movable;
    private readonly IRotatable _rotatable;
    private readonly Vector2 _direction;

    public MovementCommand(IMovable movable, IRotatable rotatable, Vector2 direction)
    {
        _movable = movable;
        _rotatable = rotatable;
        _direction = direction.normalized;
    }

    public void Execute()
    {
        _movable.Move(_direction);
        _rotatable.FaceDirection(_direction);
    }
}