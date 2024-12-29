using Godot;
using System;
using BrickBraker.scenes;

public partial class KirbyArea : Node2D
{

	[Export] private PackedScene _kirby;
	private Vector2 _position;

	private void OnBodyEntered(Node2D body)
	{
		if (body is Ball ball)
		{
			var position = ball.GlobalPosition;
			var kirby = _kirby.Instantiate<Node2D>();
			kirby.GlobalPosition = position;
			AddChild(kirby);
		}
	}
}
