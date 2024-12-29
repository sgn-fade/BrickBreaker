using Godot;
using System;

public partial class BossGun : Node2D
{
    public void Shoot()
    {
        GetNode<CpuParticles2D>("s").Emitting = true;
        var randomSpread = (float)GD.RandRange(-Mathf.Pi / 4, Mathf.Pi / 4);
        Game.Instance.CreateBall(GlobalPosition, new Vector2(0, 1).Rotated(randomSpread));

    }
}
