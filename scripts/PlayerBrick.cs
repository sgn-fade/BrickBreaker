using Godot;

namespace BrickBraker;
public partial class PlayerBrick : CharacterBody2D
{
    [Export] public float Speed = 100f;

    public override void _PhysicsProcess(double delta)
    {
        Velocity = Velocity with { X = Input.GetAxis("move_left", "move_right") * Speed};
        MoveAndSlide();
    }

    public void SwitchWindParticles(bool state)
    {
        GetNode<CpuParticles2D>("WIND").Emitting = state;
    }

    public void GroundParticles()
    {
        GetNode<CpuParticles2D>("GROUND").Emitting = true;

    }
}