using BrickBraker.scripts;
using Godot;

namespace BrickBraker.scenes;

public partial class Ball : CharacterBody2D
{
    [Export] public float Speed { get; set; } = 300f;
    [Export] public CpuParticles2D fireParticles;


    public override void _Process(double delta)
    {
        LookAt(GlobalPosition + Velocity.Normalized());
    }

    public override void _PhysicsProcess(double delta)
    {
        var collision = MoveAndCollide(Velocity * (float)delta * Speed);
        if (collision != null)
        {
            Velocity = Velocity.Bounce(collision.GetNormal()).Normalized();
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

    public void FireUp()
    {
        if(fireParticles != null)
            fireParticles.Emitting = true;
    }
    public void FireDown()
    {
        if(fireParticles != null)
            fireParticles.Emitting = false;
    }
}