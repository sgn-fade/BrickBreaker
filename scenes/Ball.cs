using Godot;

namespace BrickBraker.scenes;

public partial class Ball : CharacterBody2D
{
	[Export] private float _speed = 300f;


	public override void _Ready()
	{
		Velocity = new Vector2(1, -1).Rotated(Rotation);
	}



	public override void _PhysicsProcess(double delta)
	{
		var collision = MoveAndCollide(Velocity * (float)delta * _speed);
		if (collision != null)
		{
			Velocity = (Velocity.Bounce(collision.GetNormal())).Normalized();
		}
	}
}