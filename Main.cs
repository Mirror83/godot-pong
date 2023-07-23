using Godot;
using System;

public partial class Main : Node
{
    // TODO: Add new game functionality
    public int PlayerOneScore { get; set; } = 0;
    public int PlayerTwoScore { get; set; } = 0;
    private const int MAX_SCORE = 3;

    /// <summary>
    ///  This signal is emitted whenever player one or two scores exceed <cref>MAX_SCORE</cref>
    /// </summary> 
    [Signal]
    public delegate void GameOverEventHandler();
    [Signal]
    public delegate void PlayerOneWinEventHandler();
    [Signal]
    public delegate void PlayerTwoWinEventHandler();
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
        if (PlayerOneScore == MAX_SCORE)
        {
            EmitSignal(SignalName.GameOver);
            EmitSignal(SignalName.PlayerOneWin);
        }

    }

    public void OnBallExitLeft()
    {
        PlayerTwoScore++;
        GetNode<HUD>("HUD").UpdatePlayerTwoScore(PlayerTwoScore);
        GetNode<Ball>("Ball").ResetPosition();
        if (PlayerTwoScore == MAX_SCORE)
        {
            EmitSignal(SignalName.GameOver);
            EmitSignal(SignalName.PlayerTwoWin);
        }


    }

}
