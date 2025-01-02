using Godot;
using System;
using BrickBraker.scenes;

public partial class KirbyArea : Node2D
{
    [Export(PropertyHint.Range, "0,1,0.01")]
    private float _kirbyChance;

    [Export] private PackedScene _kirby;
    private Vector2 _position;

    private void OnBodyEntered(Node2D body)
    {
        if (body is Ball ball)
        {
            if (GD.Randf() <= _kirbyChance)
            {
                var position = ball.GlobalPosition;
                var kirby = _kirby.Instantiate<Kirby>();
                AddChild(kirby);
                kirby.GlobalPosition = position;
                kirby.Rotation = 0;
                kirby.Scale = new Vector2(3, 3);
                Game.Instance.DeleteBall(ball);
            }
        }
    }
}