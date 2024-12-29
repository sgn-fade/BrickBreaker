using BrickBraker.scenes;
using Godot;

namespace BrickBraker.scripts;

public partial class BombBall : Ball
{
    public override void HitBrick(IBreakable brick)
    {
        Game.Instance.CreateBall(GlobalPosition, Velocity);
        Velocity = Vector2.Zero;
        GetNode<AnimationPlayer>("AnimationPlayer").Play("explode");
    }

    public void DeleteSelf()
    {
        Game.Instance.DeleteBall(this);
    }
    public void BodyOnExplodeArea(Node2D body)
    {
        if (body is IBreakable brick)
        {
            brick.Hit();
        }
    }
}