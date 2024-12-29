using BrickBraker.scenes;
using Godot;

namespace BrickBraker.scripts;

public partial class SizeUp : Upgrade
{
    [Export(PropertyHint.Range, "0,1,0.01")]public double ChanceForMush{ get; set; }
    [Export] private Texture2D _mushroom;

    public override void UpgradeBall(Ball ball)
    {
        ball.Scale *= 1.5f;
    }

    public override void _Ready()
    {
        if (GD.Randf() <= ChanceForMush)
        {
            GetNode<Sprite2D>("Icon").Texture = _mushroom;
        }
    }
}