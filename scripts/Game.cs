using Godot;
using System;
using BrickBraker.scenes;

public partial class Game : Node
{
	public int BallsCount { set; get; }
	public static Game Instance { get; set; }
	[Export] private PackedScene _ballScene;
	[Export] private PackedScene _nyanCatBallScene;
	[Export(PropertyHint.Range, "0,1,0.01")]public double ChanceForNyanCat{ get; set; }
	
	public override void _Ready()
	{
		Instance = this;
		CreateBallAtSpawn();
	}

	public override void _Process(double delta)
	{
		GD.Print(BallsCount);
	}

	public void CreateBallAtSpawn()
	{
		var randomSpread = (float)GD.RandRange(-Mathf.Pi / 4 , Mathf.Pi / 4);
		CreateBall(new Vector2(970, 850), new Vector2(0, -1).Rotated(randomSpread));
	}
	public void CreateBall(Vector2 spawnPosition, Vector2 velocity, Ball ball = null)
	{
		ball ??= GetDefaultBall();

		ball.Position = spawnPosition;
		ball.Velocity = velocity;
		CallDeferred(nameof(SpawnBall), ball);
	}

	public Ball GetDefaultBall()
	{
		return GD.Randf() < ChanceForNyanCat? _nyanCatBallScene.Instantiate<Ball>() : _ballScene.Instantiate<Ball>();
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
			DeleteBall(ball);

			if (BallsCount == 0)
			{
				CreateBallAtSpawn();
			}
		}
	}

	public void DeleteBall(Ball ball)
	{
		ball.QueueFree();
		BallsCount--;
	}
}
