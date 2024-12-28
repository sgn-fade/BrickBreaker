using System;
using BrickBraker.scenes;
using Godot;

namespace BrickBraker.scripts;

public partial class IceBrick : StaticBody2D, IBreakable
{
    [Export] public int Factor {get; set;}
    [Export] public int SpreadAngle {get; set;}
    [Export] private AnimationPlayer _animationPlayer;
    public void Hit()
    {
        _animationPlayer.Play("break");
    }

    public void ApplyEffect(Ball ball)
    {
        var rand = new Random();
        for (var i = 0; i < Factor; i++)
        {
            var randomSpread = (float)(rand.NextDouble() - 0.5) * Mathf.DegToRad(SpreadAngle);
            Game.Instance.CreateBall(ball.Position, ball.Velocity);
        }
    }
}