using Godot;
using System;

public partial class Hp : Node2D
{
	private int _hpCount = 3;
	[Export] private AnimationPlayer _animationPlayer;
	
	private void TakeDamage()
	{
		_hpCount--;
		_animationPlayer.Play("main");
		if (_hpCount == 0)
		{
			//Todo: End game
		}
	}
}
