using BrickBraker.scenes;
using Godot;

namespace BrickBraker.scripts;

public partial class Upgrade : StaticBody2D
{
    public virtual void UpgradeBall(Ball ball){}

    public void OnBodyEntered(Node2D body)
    {
        if (body is not Ball ball) return;
        UpgradeBall(ball);
        QueueFree();
    }

}