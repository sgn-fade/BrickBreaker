using Godot;
using System;
using BrickBraker.scenes;

public partial class Game : Node
{
	public int BallsCount { set; get; }
	public static Game Instance { get; set; }
	[Export] private PackedScene _ballScene;
	[Export] private PackedScene _nyanCatBallScene;
	[Export] private PackedScene _alarmScene;
	[Export(PropertyHint.Range, "0,1,0.01")]public double ChanceForNyanCat{ get; set; }
	
	public override void _Ready()
	{
		Instance = this;
		CreateBallAtSpawn();
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
		GD.Print(ball.GlobalPosition);
		GD.Print(ball.Velocity);
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
			if (BallsCount == 1)
			{
				CreateAlarmScene();
			}
			if (BallsCount == 0)
			{
				GetNode<Control>("Control").Visible = true;
			}
		}
	}

	public void ReloadGame()
	{
		GetTree().ReloadCurrentScene();
	}
	public void CreateAlarmScene()
	{
		var alarmObject = _alarmScene.Instantiate<Node2D>();
		GD.Print(1111);
		AddChild(alarmObject);
	}
	public void DeleteBall(Ball ball)
	{
		ball.QueueFree();
		BallsCount--;
	}
}
