using Godot;
using System;

public partial class EndScreen : Control
{
	[Export] private Label _mainTextLabel;
	[Export] private TextureButton _winImageTextureRect;
	[Export] private AnimatedSprite2D  _winSprite;
	[Export] private Sprite2D  _loseSprite;

	[Export] private AudioStreamPlayer _soundPlayer;
	[Export] private AudioStream _winPlayer;
	[Export] private AudioStream _losePlayer;
	
	public override void _Ready()
	{
		
	}

	public void SetGameEndStatus(bool gameStatus)
	{
		if (Visible) return;
		Visible = true;
		if (gameStatus)
		{
			_winSprite.Visible = true;
			_mainTextLabel.SetText("YOU WIN!");
			_soundPlayer.Stream = _winPlayer;
			Engine.SetTimeScale(0);
		}
		else
		{
			_loseSprite.Visible = true;
			_mainTextLabel.SetText("YOU LOSE!");
			_soundPlayer.Stream = _losePlayer;
			Engine.SetTimeScale(0);
		}
	}

	public void OnImagePressed()
	{
		_soundPlayer.Play();
	}
	
}
