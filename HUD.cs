using Godot;
using System;

public partial class HUD : CanvasLayer
{
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {

    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }

    public void UpdatePlayerOneScore()
    {
        var playerOneScoreLabel = GetNode<Label>("LabelContainer/PlayerOneScore");
        var playerOneScore = playerOneScoreLabel.Text.ToInt();
        playerOneScore++;
        playerOneScoreLabel.Text = playerOneScore.ToString();
    }
    public void UpdatePlayerTwoScore()
    {
        var playerTwoScoreLabel = GetNode<Label>("LabelContainer/PlayerTwoScore");
        var playerTwoScore = playerTwoScoreLabel.Text.ToInt();
        playerTwoScore++;
        playerTwoScoreLabel.Text = playerTwoScore.ToString();
    }
}
