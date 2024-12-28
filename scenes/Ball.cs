using BrickBraker.scripts;
using Godot;

namespace BrickBraker.scenes;

public partial class Ball : CharacterBody2D
{
    [Export] public float Speed { get; set; } = 300f;


    public override void _Ready()
    {
        Velocity = new Vector2(1, -1).Rotated(Rotation).Normalized();
    }


    public override void _PhysicsProcess(double delta)
    {
        var collision = MoveAndCollide(Velocity * (float)delta * Speed);
        if (collision != null)
        {
            Velocity = Velocity.Bounce(collision.GetNormal()).Normalized();
            if (collision.GetCollider() is IBreakable brick)
            {
                brick.ApplyEffect(this);
                brick.Hit();
            }
        }
    }
}