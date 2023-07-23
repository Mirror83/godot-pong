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

    public void UpdatePlayerOneScore(int playerOneScore)
    {
        var playerOneScoreLabel = GetNode<Label>("LabelContainer/PlayerOneScore");
        playerOneScoreLabel.Text = playerOneScore.ToString();
    }
    public void UpdatePlayerTwoScore(int playerTwoScore)
    {
        var playerTwoScoreLabel = GetNode<Label>("LabelContainer/PlayerTwoScore");
        playerTwoScoreLabel.Text = playerTwoScore.ToString();
    }

    public void OnPlayerOneWin()
    {
        var winnerLabel = GetNode<Label>("WinnerLabel");
        winnerLabel.Text = "Player One Wins!";
    }

    public void OnPlayerTwoWin()
    {
        var winnerLabel = GetNode<Label>("WinnerLabel");
        winnerLabel.Text = "Player Two Wins!";
    }
}
