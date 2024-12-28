using Godot;
using System;

public partial class BrakeBrick : StaticBody2D
{
    [Export] private int _hitCount = 1;
    [Export] private Sprite2D _sprite;
    [Export] private CollisionShape2D _collisionShape;

    public void Hit()
    {
        if (_hitCount > 0)
        {
            _hitCount--;
            Break();
        }
    }

    public void Break()
    {
        if (_hitCount >= 0)
        {
            QueueFree();
        }
    }

}