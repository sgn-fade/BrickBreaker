using Godot;
using System;

public partial class Alien : Node2D
{
	[Export(PropertyHint.Range, "0,1,0.01")]public double ChanceForAlien{ get; set; }

	public void TryToFly()
	{
		if (GD.Randf() <= ChanceForAlien)
		{
			GetNode<AnimationPlayer>("AnimationPlayer").Play("main");
		}
	}
}
