using Godot;
using System;

public partial class PlayerOne : Paddle
{
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        MoveOnKeyPress(PaddleKeyMaps.PlayerOneUp, PaddleKeyMaps.PlayerOneDown);
    }

}
