using BrickBraker.scenes;

namespace BrickBraker.scripts;

public interface IBreakable
{
    public abstract void Hit();
    public abstract void ApplyEffect(Ball ball);
}