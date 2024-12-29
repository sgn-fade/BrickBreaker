using Godot;
using System;
using System.Collections.Generic;
using BrickBraker.scripts;

public partial class BuffSpawner : CollisionShape2D
{
    [Export] public PackedScene[] UpgradeList { get; set; }

    public void SpawnBuff()
    {
        var upgrade = UpgradeList[(int)(GD.Randi() % UpgradeList.Length)].Instantiate<Upgrade>();
        var shape = (RectangleShape2D)Shape;
        var shapeSize = shape.Size;
        var x = GD.RandRange((double)-shapeSize.X / 2, (double)shapeSize.X / 2);
        var y = GD.RandRange((double)-shapeSize.Y / 2, (double)shapeSize.Y / 2);
        upgrade.GlobalPosition += new Vector2((float)x, (float)y);
        AddChild(upgrade);
    }
}
