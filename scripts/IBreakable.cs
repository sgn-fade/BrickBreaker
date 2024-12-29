using BrickBraker.scenes;

namespace BrickBraker.scripts;

public interface IBreakable
{
    public void Hit();
    public void ApplyEffect(Ball ball);
}