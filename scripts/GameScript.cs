using Godot;
using System;
using BrickBraker.scenes;

public partial class GameScript : Node
{

	private int BallsCount { set; get; } = 0;
	[Export] private PackedScene _ballScene;
	
	public override void _Ready()
	{
		SpawnBall();
	}

	public void SpawnBall()
	{
		Ball ball = _ballScene.Instantiate<Ball>();
		ball.Position = new Vector2(970f, 655f);
		// ball.Rotation = new Vector2(0f, -1f).Angle();
		AddChild(ball);
		BallsCount++;
	}

	public void DestroyDrop(Node2D body)
	{
		if (body is Ball ball)
		{
			BallsCount--;
			ball.QueueFree();
		}

		if (BallsCount == 0)
			SpawnBall();
	}
}
