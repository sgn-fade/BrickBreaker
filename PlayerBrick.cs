using Godot;

namespace BrickBraker;
public partial class PlayerBrick : CharacterBody2D
{
    [Export] public float Speed = 100f;

    public override void _PhysicsProcess(double delta)
    {
        Vector2 velocity = Vector2.Zero;

        if (Input.IsActionPressed("move_right"))
        {
            velocity.X += Speed;
        }
        if (Input.IsActionPressed("move_left"))
        {
            velocity.X -= Speed;
        }

        Velocity = velocity;
        
        MoveAndSlide();
    }
}