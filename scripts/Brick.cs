using Godot;
using System;
using BrickBraker.scenes;
using BrickBraker.scripts;

public partial class Brick : StaticBody2D, IBreakable
{
    private Color[] Colors =
    {
        Godot.Colors.Red,
        Godot.Colors.Yellow,
        Godot.Colors.Green,
        Godot.Colors.Blue,
        Godot.Colors.Cyan,
    };

    [Export] private int _hitCount = 1;
    [Export] private AnimationPlayer _animationPlayer;

    public override void _Ready()
    {
        Modulate = Colors[GD.Randi() % Colors.Length];
    }

    public void Hit()
    {
        _hitCount--;
        if (_hitCount == 0)
        {
            _animationPlayer.Play("break");
        }
    }

    public void ApplyEffect(Ball ball)
    {
        ball.Speed += 100;
    }
}