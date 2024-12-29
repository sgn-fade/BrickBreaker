using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using BrickBraker;

public partial class PlayerSpells : Control
{
    [Export] public PlayerBrick Player { get; set; }
    [Export] public PlayerSpell[] Spells { get; set; }

    public override void _Input(InputEvent @event)
    {
        for (int i = 0; i < Spells.Length; i++)
        {
            var spell = Spells[i];
            if (Input.IsActionJustPressed(spell.Button) && spell.IsReady)
            {
                spell.Cast();
                switch (i)
                {
                    case 0:
                        SpeedPlayerUp();
                        break;
                    case 1:
                        ExpandPlayer();
                        break;
                    case 2:
                        SpeedUpBalls();
                        break;
                }
            }
        }
    }

    public void SpeedPlayerUp()
    {
        Player.Speed += 200;
        GetTree().CreateTimer(5).Timeout += () => Player.Speed -= 200;
    }

    public void ExpandPlayer()
    {
        Player.Scale = Player.Scale with { X = Player.Scale.X * 2 };
        GetTree().CreateTimer(5).Timeout += () => Player.Scale = Player.Scale with { X = Player.Scale.X / 2 };
    }

    public void SpeedUpBalls()
    {
    }
}