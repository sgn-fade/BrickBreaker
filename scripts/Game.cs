using Godot;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BrickBraker.scenes;

public partial class Game : Node
{
    public static Game Instance { get; set; }
    [Export] private PackedScene _ballScene;
    [Export] private PackedScene _nyanCatBallScene;
    [Export] private PackedScene _alarmScene;
    [Export] private EndScreen _gameStatusScreen;
    [Export] private PlayerHp _playerHp;
    [Export] private PackedScene _brickLvl;
    [Export] private PackedScene _bossLvl;
    private Node2D lvl;
    public List<Ball> Balls { get; set; }
    private bool bossActive;

    [Export(PropertyHint.Range, "0,1,0.01")]
    public double ChanceForNyanCat { get; set; }

    public override void _Ready()
    {
        Engine.SetTimeScale(1);
        lvl = _brickLvl.Instantiate<Node2D>();
        AddChild(lvl);
        Balls = new List<Ball>();
        Instance = this;
        CreateBallAtSpawn();
    }

    public override void _Process(double delta)
    {
        if (lvl.GetChildCount() == 1)
        {
            lvl.QueueFree();
            bossActive = true;
            lvl = _bossLvl.Instantiate<Node2D>();
            AddChild(lvl);
        }
    }

    public void CreateBallAtSpawn()
    {
        var randomSpread = (float)GD.RandRange(-Mathf.Pi / 4, Mathf.Pi / 4);
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
        return GD.Randf() < ChanceForNyanCat ? _nyanCatBallScene.Instantiate<Ball>() : _ballScene.Instantiate<Ball>();
    }

    public void SpawnBall(Ball ball)
    {
        AddChild(ball);
        Balls.Add(ball);
    }

    public void DestroyDrop(Node2D body)
    {
        if (body is Ball ball)
        {
            DeleteBall(ball);
        }
    }

    public void ReloadGame()
    {
        GetTree().ReloadCurrentScene();
    }

    public void CreateAlarmScene()
    {
        var alarmObject = _alarmScene.Instantiate<Node2D>();
        AddChild(alarmObject);
    }

    public void DeleteBall(Ball ball)
    {
        ball.QueueFree();
        CallDeferred(nameof(DeferredBallDeleting), ball);

    }

    public void DeferredBallDeleting(Ball ball)
    {
        Balls.Remove(ball);
        if (Balls.Count == 1)
        {
            CreateAlarmScene();
        }

        if (Balls.Count == 0 || bossActive)
        {
            if (_playerHp.TryKillPlayer()) _gameStatusScreen.SetGameEndStatus(false);
            else CreateBallAtSpawn();
        }
    }

    public void WinGame()
    {
        _gameStatusScreen.SetGameEndStatus(true);
    }
}