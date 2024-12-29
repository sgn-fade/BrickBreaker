using BrickBraker.scripts;
using Godot;

namespace BrickBraker.scenes;

public partial class Ball : CharacterBody2D
{
    [Export] public float Speed { get; set; } = 300f;
    public Vector2 ReflectedNormal { get; set; }


    public override void _Process(double delta)
    {
        LookAt(GlobalPosition + Velocity.Normalized());
    }

    public override void _PhysicsProcess(double delta)
    {
        var collision = MoveAndCollide(Velocity * (float)delta * Speed);
        if (collision != null)
        {
            ReflectedNormal = collision.GetNormal();
            Velocity = Velocity.Bounce(ReflectedNormal).Normalized();
            if (collision.GetCollider() is IBreakable brick)
            {
                HitBrick(brick);
            }
        }
    }
    public virtual void HitBrick(IBreakable brick)
    {
        brick.Hit();
        brick.ApplyEffect(this);
    }
}