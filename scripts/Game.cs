using Godot;
using System;
using BrickBraker.scenes;

public partial class Game : Node
{
	private int BallsCount { set; get; }
	public static Game Instance { get; set; }
	[Export] private PackedScene _ballScene;
	
	public override void _Ready()
	{
		Instance = this;
		CreateBall(new Vector2(970, 850), new Vector2(0, -1));
	}

	public void CreateBall(Vector2 spawnPosition, Vector2 velocity)
	{
		var ball = _ballScene.Instantiate<Ball>();
		ball.Position = spawnPosition;
		ball.Velocity = velocity;
		CallDeferred(nameof(SpawnBall), ball);
	}

	public void SpawnBall(Ball ball)
	{
		AddChild(ball);
		BallsCount++;
	}
	public void DestroyDrop(Node2D body)
	{
		if (body is Ball ball)
		{
			BallsCount--;
			ball.QueueFree();

			if (BallsCount == 0)
				CreateBall(new Vector2(970, 850), new Vector2(0, -1));
		}
	}
}
