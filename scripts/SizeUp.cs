using BrickBraker.scenes;

namespace BrickBraker.scripts;

public partial class SizeUp : Upgrade
{
    public override void UpgradeBall(Ball ball)
    {
        ball.Scale *= 1.5f;
    }
}