using Godot;
using System;

public partial class BossGun : Node2D
{
    public void Shoot()
    {
        GetNode<CpuParticles2D>("s").Emitting = true;
    }
}
