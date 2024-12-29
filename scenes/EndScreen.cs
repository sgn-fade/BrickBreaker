using Godot;
using System;

public partial class EndScreen : Control
{
	[Export] private Label _mainTextLabel;
	[Export] private TextureRect _winImageTextureRect;
	[Export] private Texture2D  _winImage;
	[Export] private Texture2D  _loseImage;
	
	public override void _Ready()
	{
		
	}

	public void SetGameEndStatus(bool gameStatus)
	{
		Visible = true;
		if (gameStatus)
		{
			_winImageTextureRect.SetTexture(_winImage);
			_mainTextLabel.SetText("YOU WIN!");
		}
		else
		{
			_winImageTextureRect.SetTexture(_loseImage);
			_mainTextLabel.SetText("YOU LOSE!");
		}
	}
	
}
