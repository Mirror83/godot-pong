using Godot;
using System;

public partial class Main : Node
{
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }

    public void OnBallExitRight()
    {
        GetNode<HUD>("HUD").UpdatePlayerOneScore();
        GetNode<Ball>("Ball").ResetPosition();
    }

    public void OnBallExitLeft()
    {
        GetNode<HUD>("HUD").UpdatePlayerTwoScore();
        GetNode<Ball>("Ball").ResetPosition();
    }

}