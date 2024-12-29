using Godot;
using System;
using BrickBraker.scenes;
using BrickBraker.scripts;

public partial class Boss : CharacterBody2D, IBreakable
{
    [Export] public int Speed { get; set; }
    [Export] public BossGun[] Guns;
    [Export] public int HP { get; set; } = 10;

    public override void _Ready()
    {
        Velocity = Vector2.Right * Speed;
    }

    public void Shoot()
    {
        foreach (var gun in Guns)
        {
            gun.Shoot();
        }
    }
    public override void _PhysicsProcess(double delta)
    {
        var collision = MoveAndCollide(Velocity * (float)delta * Speed);
        if (collision != null)
        {
            Velocity = Velocity.Bounce(collision.GetNormal()).Normalized();
            Velocity = Velocity with { Y = 0 };
        }
    }

    public void Hit()
    {
        HP--;
    }

    public void ApplyEffect(Ball ball)
    {
    }
}