using Godot;
using System;
using BrickBraker.scenes;
using BrickBraker.scripts;

public partial class BombUpgrade : Upgrade
{
    [Export] private PackedScene _bomb;
    public override void UpgradeBall(Ball ball)
    {
        Game.Instance.CreateBall(ball.GlobalPosition, ball.Velocity, _bomb.Instantiate<Ball>());
        Game.Instance.DeleteBall(ball);
    }
}
