using Godot;
using System;

public partial class PlayerSpell : TextureProgressBar
{
	[Export] public double CooldownTime { get; set; }
	private double timeSpend;
	[Export] public string Button { get; set; }
	public bool IsReady { get; set; }
	public override void _Ready()
	{
		GetNode<Label>("Label2").Text = Button;
		timeSpend = CooldownTime;
		UpdateValue();
	}

	public void Cast()
	{
		timeSpend = 0;
		UpdateValue();
		IsReady = false;
	}

	public override void _Process(double delta)
	{
        if (timeSpend >= CooldownTime)
        {
            IsReady = true;
            return;
        }
        timeSpend += delta;
        UpdateValue();
	}

	public void UpdateValue()
	{
		Value = timeSpend / CooldownTime * 100;
	}
}
