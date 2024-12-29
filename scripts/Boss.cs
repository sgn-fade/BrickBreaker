using Godot;
using System;
using System.Collections;
using BrickBraker.scenes;
using BrickBraker.scripts;

public partial class Boss : CharacterBody2D, IBreakable
{
    [Export] public int Speed { get; set; }
    [Export] public BossGun[] Guns;
    [Export] public int HP { get; set; } = 10;
    private int currentHP;

    public override void _Ready()
    {
        currentHP = HP;
        Velocity = Vector2.Right * Speed;
        GD.Print(Velocity);
    }

    public void Shoot()
    {
        Guns[GD.Randi() % Guns.Length].Shoot();
    }
    public override void _PhysicsProcess(double delta)
    {
        var collision = MoveAndCollide(Velocity * (float)delta * Speed);
        if (collision != null)
        {
            Velocity = Velocity with { Y = 0, X = Velocity.Bounce(collision.GetNormal()).Normalized().X};
        }
    }

    public void Hit()
    {
        currentHP--;
        if(currentHP == HP /2) RageMode();
        if (currentHP <= 0)
        {
            Game.Instance.WinGame();
            QueueFree();
        }
    }

    private void RageMode()
    {
        GetNode<AnimatedSprite2D>("s").Play("Rage");
        Speed *= 2;
        GetNode<Timer>("Timer").WaitTime /= 2;
    }
    public void ApplyEffect(Ball ball)
    {
    }
}