using Godot;
using System;

public partial class EndScreen : Control
{
	[Export] private Label _mainTextLabel;
	[Export] private TextureButton _winImageTextureRect;
	[Export] private Texture2D  _winImage;
	[Export] private Texture2D  _loseImage;
	[Export] private CpuParticles2D _particles;
	
	[Export] private AudioStreamPlayer _soundPlayer;
	[Export] private AudioStream _winPlayer;
	[Export] private AudioStream _losePlayer;
	
	public override void _Ready()
	{
		
	}

	public void SetGameEndStatus(bool gameStatus)
	{
		Visible = true;
		if (gameStatus)
		{
			_winImageTextureRect.TextureNormal = _winImage;
			_mainTextLabel.SetText("YOU WIN!");
			_soundPlayer.Stream = _winPlayer;
		}
		else
		{
			_winImageTextureRect.TextureNormal = _loseImage;
			_mainTextLabel.SetText("YOU LOSE!");
			_soundPlayer.Stream = _losePlayer;
		}
	}

	public void OnImagePressed()
	{
		_particles.SetEmitting(true);
		_soundPlayer.Play();
	}
	
}
