using Godot;
using System;

public partial class Main : Node
{
    public int PlayerOneScore { get; set; } = 0;
    public int PlayerTwoScore { get; set; } = 0;
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
        PlayerOneScore++;
        GetNode<HUD>("HUD").UpdatePlayerOneScore(PlayerOneScore);
        GetNode<Ball>("Ball").ResetPosition();
    }

    public void OnBallExitLeft()
    {
        PlayerTwoScore++;
        GetNode<HUD>("HUD").UpdatePlayerTwoScore(PlayerTwoScore);
        GetNode<Ball>("Ball").ResetPosition();
    }

}
