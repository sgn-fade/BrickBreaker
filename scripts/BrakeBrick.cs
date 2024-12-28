using Godot;
using System;

public partial class BrakeBrick : StaticBody2D
{
    private Color[] Colors =
    {
        new Color(1, 0, 0),
        new Color(1, 1, 0),
        new Color(0, 1, 0),
        new Color(0, 0, 1),
        new Color(1, 0.75f, 0.8f)
    };

    [Export] private int _hitCount = 1;
    [Export] private Sprite2D _sprite;
    [Export] private CollisionShape2D _collisionShape;

    private Color GetRandomColor()
    {
        Random random = new Random();
        int index = random.Next(Colors.Length);
        return Colors[index];
    }

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