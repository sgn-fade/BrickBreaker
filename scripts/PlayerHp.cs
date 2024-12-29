using Godot;
using System;

public partial class PlayerHp : Control
{
	public int HP { get; set; } = 3;
	[Export] private AnimatedSprite2D _sprite;
	public override void _Ready()
	{
		_sprite.Frame = 0;
	}

	public bool TryKillPlayer()
	{
		HP--;
		UpdateView();
		return HP <= 0;
	}

	public void UpdateView()
	{
		_sprite.Frame++;
	}
}
