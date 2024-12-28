using Godot;

namespace BrickBraker.scenes;

public partial class Ball : CharacterBody2D
{
    [Export] private float _speed = 300f;


    public override void _Ready()
    {
        Velocity = new Vector2(1, -1).Rotated(Rotation).Normalized();
    }


    public override void _PhysicsProcess(double delta)
    {
        var collision = MoveAndCollide(Velocity * (float)delta * _speed);
        if (collision != null)
        {
            Velocity = Velocity.Bounce(collision.GetNormal()).Normalized();
            if (collision.GetCollider() is Brick brick) brick.Hit();
        }
    }
}