using System;
using BrickBraker.scenes;
using Godot;

namespace BrickBraker.scripts;

public partial class IceBrick : StaticBody2D, IBreakable
{
    [Export] public int Factor {get; set;}
    [Export] private AnimationPlayer _animationPlayer;
    public void Hit()
    {
        _animationPlayer.Play("break");
    }

    public void ApplyEffect(Ball ball)
    {
        for (var i = 0; i < Factor; i++)
        {
            float randomSpread = (float)GD.RandRange(-Mathf.Pi / 4 , Mathf.Pi / 4);
            Game.Instance.CreateBall(ball.Position, ball.Velocity.Rotated(randomSpread));
        }
    }
}